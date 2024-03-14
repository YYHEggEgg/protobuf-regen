using CommandLine;
using YYHEggEgg.ProtoParser;

namespace ProtobufRegen.Proto2json;

public class RegenOptions
{
    [Value(0, Required = true, HelpText = "The proto regen path")]
    public string ProtoPath { get; set; }
    [Option('o', "output", Required = true, HelpText = "The result output path")]
    public string OutputPath { get; set; }
}

internal static class Program
{
    public static async Task Main(string[] args)
    {
        RegenOptions? opt = null;
        Parser.Default.ParseArguments<RegenOptions>(args)
            .WithNotParsed(err => Environment.Exit(1))
            .WithParsed(o => opt = o);
        if (opt == null) Environment.Exit(1);

        await ProtoParser.ParseFromDirectoryAsync(opt.ProtoPath, opt.OutputPath);
    }
}
