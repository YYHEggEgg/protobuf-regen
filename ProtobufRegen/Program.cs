// See https://aka.ms/new-console-template for more information
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Globalization;
using CsvHelper;
using ProtobufRegen;
using ProtobufRegen.Localization;
using ProtobufRegen.RegenOutput;
using YYHEggEgg.Logger;
using YYHEggEgg.ProtoParser;

// Change if U need.
const string? ProtoPackage = "miHomo.Protos";

StartupWorkingDirChanger.ChangeToDotNetRunPath(new LoggerConfig(
    max_Output_Char_Count: 16 * 1024,
    use_Console_Wrapper: false,
    use_Working_Directory: true,
#if DEBUG
    global_Minimum_LogLevel: LogLevel.Verbose,
    console_Minimum_LogLevel: LogLevel.Information,
#else
    global_Minimum_LogLevel: LogLevel.Information,
    console_Minimum_LogLevel: LogLevel.Information,
#endif
    debug_LogWriter_AutoFlush: false,
    is_PipeSeparated_Format: false,
    enable_Detailed_Time: false
));
LocaleManager localizer = new("interacting");

Log.Info(localizer["please_set_pre_license"]);

#if FORBID_ENUM_CMDID
Log.Warn(localizer["enabled_forbid_enum_cmdid_notice"]);
#endif
#if ENABLE_ENUM_FIELDNAME_MIDDLEWARE
Log.Warn(localizer["enabled_enum_fieldname_standardlize_notice"]);
#endif
Log.Info(localizer["please_type_protobuf_path"]);
string path = Console.ReadLine()!;

#if GENERATE_SINGLE_FILE
Log.Info(localizer["please_give_output_file"]);
#else
Log.Info(localizer["please_give_output_path"]);
#endif
string outputpath = Console.ReadLine();

#region Invoke proto2json
Log.Info(localizer["invoking_proto2json"], "Go-Proto2json");
Stopwatch pinvokewatch = Stopwatch.StartNew();
var protojsons = await ProtoParser.ParseFromDirectoryAsync(path);
Log.Info(string.Format(localizer["proto2json_exited_elapsed_{0}"], pinvokewatch.Elapsed), "Go-Proto2json");
#endregion

string pre_license = File.ReadAllText("pre_license.txt");

#if GENERATE_SINGLE_FILE
Log.Info(string.Format(localizer["para_resolved_generating_to_{0}_file"], outputpath));
BasicCodeWriter fi = PreGenerate(outputpath);
#else
Log.Info(string.Format(localizer["para_resolved_generating_to_{0}"], outputpath));
try { Directory.Delete(outputpath, true); } catch { }
Directory.CreateDirectory($"{outputpath}/Protos");
#endif

ConcurrentBag<EnetRpcAttributes> enetRpcs = [];
#if GENERATE_SINGLE_FILE
foreach (var analyzeResult in protojsons.Values)
#else
Parallel.ForEach(protojsons.Values, analyzeResult =>
#endif
{
    foreach (var message in analyzeResult.MessageBodys)
    {
#if !GENERATE_SINGLE_FILE
        BasicCodeWriter fi = PreGenerate(outputpath, $"{message.MessageName}.proto");
#endif
        SortedSet<string> imports = new();
        RegenOutputMessage.OutputMessage(ref fi, ref imports, message);
#if !GENERATE_SINGLE_FILE
        var external_imports = from importorigin in imports
                               let nestedIdentifier = importorigin.IndexOf('.')
                               let importfile = (nestedIdentifier < 0)
                                   ? importorigin
                                   : importorigin.Substring(0, nestedIdentifier)
                               where importfile != message.MessageName
                               where !message.MessageFields.Any(field => field.MessageName == importfile)
                               where !message.EnumFields.Any(field => field.EnumName == importfile)
                               orderby importfile
                               select importfile;
        if (external_imports.Any()) fi.WriteLine();
        foreach (var importfile in external_imports)
        {
            fi.WriteLine($"import \"{importfile}.proto\";");
        }
        fi.Dispose();
#else
        fi.WriteLine();
#endif
        var cmdidenum = message.EnumFields.Find(enumResult => enumResult.EnumName == "CmdId");
        if (cmdidenum != null)
        {
            var nodes = cmdidenum.EnumNodes;
            enetRpcs.Add(new(
                message.MessageName,
                nodes.Where(x => x.name == "CMD_ID").Select(x => x.number.ToString()).SingleOrDefault(),
                nodes.Where(x => x.name == "ENET_CHANNEL_ID").Select(x => x.number.ToString()).SingleOrDefault(),
                nodes.Where(x => x.name == "ENET_IS_RELIABLE").Select(x => x.number.ToString()).SingleOrDefault(),
                nodes.Where(x => x.name == "IS_ALLOW_CLIENT").SingleOrDefault().number == 1,
                nodes.Where(x => x.name == "TARGET_SERVICE").Select(x => x.number.ToString()).SingleOrDefault()
            ));
        }
    }
    foreach (var enumResult in analyzeResult.EnumBodys)
    {
#if !GENERATE_SINGLE_FILE
        BasicCodeWriter fi = PreGenerate(outputpath, $"{enumResult.EnumName}.proto");
#endif
        RegenOutputEnum.OutputEnum(ref fi, enumResult);
#if !GENERATE_SINGLE_FILE
        fi.Dispose();
#else
        fi.WriteLine();
#endif
    }
#if GENERATE_SINGLE_FILE
}
#else
});
#endif

Log.Info(localizer["exporting_cmdid"]);
var lines = from rpc in enetRpcs
            orderby rpc.MessageName
            select $"{rpc.MessageName},{rpc.CmdId}";
#if GENERATE_SINGLE_FILE
File.WriteAllLines(Path.Combine(Directory.GetParent(outputpath).FullName, "cmdid.csv"), lines);
using StreamWriter writer = new(Path.Combine(Directory.GetParent(outputpath).FullName, "cmdid.ex.csv"));
#else
File.WriteAllLines(Path.Combine(outputpath, "cmdid.csv"), lines);
using StreamWriter writer = new(Path.Combine(outputpath, "cmdid.ex.csv"));
#endif
using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
csv.WriteRecords(enetRpcs.OrderBy(x => x.MessageName));

Log.Info(localizer["gen_succ"]);

#if GENERATE_SINGLE_FILE
BasicCodeWriter PreGenerate(string outputPath)
{
    BasicCodeWriter fi = new(outputPath);
#else
BasicCodeWriter PreGenerate(string basedir, string fileName)
{
    BasicCodeWriter fi = new(Path.Combine(basedir, "Protos", fileName));
#endif
    fi.WriteLine(pre_license);
    fi.WriteLine();
    fi.WriteLine("syntax = \"proto3\";");
    if (ProtoPackage != null)
    {
        fi.WriteLine();
        fi.WriteLine($"package {ProtoPackage};");
    }
    fi.WriteLine();
    return fi;
}

record EnetRpcAttributes(string MessageName, string CmdId,
    string EnetChannelId, string EnetIsReliable, bool IsAllowClient,
    string TargetService);
