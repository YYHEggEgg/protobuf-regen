﻿// See https://aka.ms/new-console-template for more information
using System.Collections.Concurrent;
using System.Diagnostics;
using ProtobufRegen;
using ProtobufRegen.RegenOutput;
using YYHEggEgg.Logger;
using YYHEggEgg.ProtoParser;

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

Log.Info($"请将所需的前缀置于 pre_license.txt.");

Log.Info($"请输入 protobuf 路径：");
#if FORBID_ENUM_CMDID
Log.Warn($"本次生成将剥离 Proto/CmdId 枚举；可在 .csproj 中取消 FORBID_ENUM_CMDID 并重新生成来取消。");
#endif
#if ENABLE_ENUM_FIELDNAME_MIDDLEWARE
Log.Warn($"本次生成将对枚举字段名作标准化处理，但可能导致问题（如 GCG 无法使用）。如果确认您的 proto 不来自于 GIO 或其不存在问题，可在 .csproj 中取消 ENABLE_ENUM_FIELDNAME_MIDDLEWARE 并重新生成来取消。");
#endif
string path = Console.ReadLine();

Log.Info("请输入输出存放路径（其内容将被完全覆盖）：");
string outputpath = Console.ReadLine();

#region Invoke proto2json
Log.Info("Start invoking go-proto2json (Wrapped by EggEgg.CSharp-ProtoParser). Please wait patiently...", "Go-Proto2json");
Stopwatch pinvokewatch = Stopwatch.StartNew();
var protojsons = await ProtoParser.ParseFromDirectoryAsync(path);
Log.Info($"proto2json exited. Total execute time is {pinvokewatch.Elapsed}.", "Go-Proto2json");
#endregion

string pre_license = File.ReadAllText("pre_license.txt");

Log.Info($"参数解析完成。结果将会生成在 '{outputpath}' 文件夹中。");
try { Directory.Delete(outputpath, true); } catch { }

Directory.CreateDirectory(outputpath);
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

Log.Info($"protobuf 解析生成完毕。正在导出 CMD_ID 至 cmdid.csv...");
var lines = from pair in cmdidlist
            orderby pair.Key
            select $"{pair.Key},{pair.Value}";
File.WriteAllLines(Path.Combine(outputpath, "../cmdid.csv"), lines);

Log.Info($"生成成功！");

BasicCodeWriter PreGenerate(string basedir, string fileName)
{
    BasicCodeWriter fi = new(Path.Combine(basedir, fileName));
    fi.WriteLine(pre_license);
    fi.WriteLine();
    fi.WriteLine("syntax = \"proto3\";");
    fi.WriteLine();
    fi.WriteLine("package miHomo.Protos;");
    fi.WriteLine();
    return fi;
}

void CopyDir(string source, string target)
{
    Directory.CreateDirectory(target);
    CopyFilesRecursively(Path.GetFullPath(source), Path.GetFullPath(target));
}

// .net - Copy the entire contents of a directory in C#
// https://stackoverflow.com/questions/58744/copy-the-entire-contents-of-a-directory-in-c-sharp
void CopyFilesRecursively(string sourcePath, string targetPath)
{
    //Now Create all of the directories
    foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
    {
        Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));
    }

    //Copy all the files & Replaces any files with the same name
    foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
    {
        File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);
    }
}