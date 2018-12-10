using System;
using Fclp;
using CommandLineUtil.Command;

namespace CommadLineUtil
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new FluentCommandLineParser();

            SetupCommandOne(parser);
            SetupCommandTwo(parser);
            SetupHelp(parser);

            parser.Parse(args);

            Console.Write("press any key to exit...");
            Console.ReadKey();
        }

        private static void SetupCommandOne(FluentCommandLineParser parser)
        {
            var commandOne = 
                parser
                    .SetupCommand<CommandOneArguments>("commandone")
                    .OnSuccess(CommandOne.Execute);

            commandOne.Setup(a => a.Message)
                .As('m', "message")
                .SetDefault("Hello, World!");
        }

        private static void SetupCommandTwo(FluentCommandLineParser parser)
        {
            var commandTwo =
                parser
                    .SetupCommand<CommandTwoArguments>("commandtwo")
                    .OnSuccess(CommandTwo.Execute);

            commandTwo.Setup(a => a.Path)
                .As('p', "path")
                .SetDefault(Environment.CurrentDirectory);

            commandTwo.Setup(a => a.ShowDirectory)
                .As('d', "include-dir")
                .SetDefault(false);
        }

        private static void SetupHelp(FluentCommandLineParser parser)
        {
            parser
                .SetupHelp("?", "help")
                .Callback(txt =>
                {
                    var friendlyName = AppDomain.CurrentDomain.FriendlyName;
                    Console.WriteLine();
                    Console.WriteLine("Command line parameters usage: ");
                    Console.WriteLine($"{friendlyName} [/?|-?] [commandone|commandtwo] [command specific parameters]");
                    Console.WriteLine();
                    Console.WriteLine("To display usage help:");
                    Console.WriteLine($"{friendlyName} [-?|/?]");
                    Console.WriteLine();
                    Console.WriteLine("Coommand specific examples:");
                    Console.WriteLine();
                    Console.WriteLine($"{friendlyName} {CommandOne.Moniker} {CommandOne.Help}");
                    Console.WriteLine($"{friendlyName} {CommandTwo.Moniker} {CommandTwo.Help}");
                    Console.WriteLine();
                });
        }
    }
}
