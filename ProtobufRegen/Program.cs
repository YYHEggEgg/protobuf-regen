// See https://aka.ms/new-console-template for more information
using System.Collections.Concurrent;
using ProtobufRegen;
using YYHEggEgg.Logger;

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
    enable_Detailed_Time: true
));

Log.Info($"请将所需的前缀置于 pre_license.txt.");

Log.Info($"请输入 protobuf 路径：");
string path = Console.ReadLine();

Log.Info($"手动编译。完成后输入路径：");
string compiled_path = Console.ReadLine();

string pre_license = File.ReadAllText("pre_license.txt");

ConcurrentBag<MessageResult> messages = new();
ConcurrentBag<EnumResult> enums = new();
var protojsons = Directory.EnumerateFiles(path);
Parallel.ForEach(protojsons, path =>
{
    ProtoJsonResult analyzeResult = JsonAnalyzer.AnalyzeProtoJson(File.ReadAllText(path));
    foreach (var message in analyzeResult.messageBodys)
    {
        messages.Add(message);
    }
    foreach (var enumResult in analyzeResult.enumBodys)
    {
        enums.Add(enumResult);
    }
});



