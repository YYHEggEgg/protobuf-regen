// See https://aka.ms/new-console-template for more information
using System.Collections.Concurrent;
using System.Diagnostics;
using ProtobufRegen;
using ProtobufRegen.Localization;
using ProtobufRegen.RegenOutput;
using YYHEggEgg.Logger;
using YYHEggEgg.ProtoParser;

// Change if U need.
const string ProtoPackage = "miHomo.Protos";

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
string path = Console.ReadLine();

Log.Info(localizer["please_give_output_path"]);
string outputpath = Console.ReadLine();

#region Invoke proto2json
Log.Info(localizer["invoking_proto2json"], "Go-Proto2json");
Stopwatch pinvokewatch = Stopwatch.StartNew();
var protojsons = await ProtoParser.ParseFromDirectoryAsync(path);
Log.Info(string.Format(localizer["proto2json_exited_elapsed_{0}"], pinvokewatch.Elapsed), "Go-Proto2json");
#endregion

string pre_license = File.ReadAllText("pre_license.txt");

Log.Info(string.Format(localizer["para_resolved_generating_to_{0}"], outputpath));
try { Directory.Delete(outputpath, true); } catch { }

Directory.CreateDirectory($"{outputpath}/Protos");
ConcurrentDictionary<string, int> cmdidlist = new();
Parallel.ForEach(protojsons.Values, analyzeResult =>
{
    foreach (var message in analyzeResult.MessageBodys)
    {
        BasicCodeWriter fi = PreGenerate(outputpath, $"{message.MessageName}.proto");
        SortedSet<string> imports = new();
        RegenOutputMessage.OutputMessage(ref fi, ref imports, message);
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
        var cmdidenum = message.EnumFields.Find(enumResult => enumResult.EnumName == "CmdId");
        if (cmdidenum != null)
        {
            var cmdid_tuple = cmdidenum.EnumNodes.Find(enumNodeTuple => enumNodeTuple.name == "CMD_ID");
            if (cmdid_tuple.name == "CMD_ID") cmdidlist.TryAdd(message.MessageName, cmdid_tuple.number);
        }
    }
    foreach (var enumResult in analyzeResult.EnumBodys)
    {
        BasicCodeWriter fi = PreGenerate(outputpath, $"{enumResult.EnumName}.proto");
        RegenOutputEnum.OutputEnum(ref fi, enumResult);
        fi.Dispose();
    }
});

Log.Info(localizer["exporting_cmdid"]);
var lines = from pair in cmdidlist
            orderby pair.Key
            select $"{pair.Key},{pair.Value}";
File.WriteAllLines(Path.Combine(outputpath, "cmdid.csv"), lines);

Log.Info(localizer["gen_succ"]);

BasicCodeWriter PreGenerate(string basedir, string fileName)
{
    BasicCodeWriter fi = new(Path.Combine(basedir, "Protos", fileName));
    fi.WriteLine(pre_license);
    fi.WriteLine();
    fi.WriteLine("syntax = \"proto3\";");
    fi.WriteLine();
    fi.WriteLine($"package {ProtoPackage};");
    fi.WriteLine();
    return fi;
}