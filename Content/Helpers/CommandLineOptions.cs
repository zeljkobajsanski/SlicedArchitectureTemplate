using CommandLine;

namespace StarterWebApplication.Helpers
{
    public class CommandLineOptions
    {
        [Option('m', "migrate", Required = false, HelpText = "Migrate database on startup")]
        public bool MigrateDatabase { get; set; }
    }
}