using CommandLine;

namespace GameOfLife.Console
{
    /// <summary>
    /// Representation of the program's supported command-line arguments.
    /// </summary>
    internal class CommandLineOptions
    {
        [Option('f', "file", Default = null, HelpText = "Path to initial input file", Required = false)]
        public string InputFile { get; set; }
    }
}
