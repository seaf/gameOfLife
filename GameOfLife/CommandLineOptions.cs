using CommandLine;

namespace GameOfLife.Console
{
    internal class CommandLineOptions
    {
        [Option('f', "file", Default = null, HelpText = "Initial input file", Required = false)]
        public string InputFile { get; set; }
    }
}
