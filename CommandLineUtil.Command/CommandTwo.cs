using System;
using System.Collections.Generic;
using System.IO;

namespace CommandLineUtil.Command
{
    public class CommandTwo
    {
        public static readonly string Moniker = "commandtwo";

        public static readonly string Help = "[-p|--path] [PATH_TO_DIRECTORY] [-d|--include-dir]";

        public static void Execute(CommandTwoArguments arguments)
        {
            Console.WriteLine($"{nameof(arguments.ShowDirectory)}: {arguments.ShowDirectory}");

            Console.WriteLine($"{nameof(CommandTwo)} with path='{arguments.Path}'");
            Console.WriteLine("======================================");

            var entries = new List<string>();
            if (arguments.ShowDirectory)
            {
                var directories = Directory.GetDirectories(arguments.Path);
                entries.AddRange(directories);
            }

            var fileNames = Directory.GetFiles(arguments.Path);
            entries.AddRange(fileNames);

            foreach (var entry in entries)
            {
                var entryInfo = new FileInfo(entry);
                Console.WriteLine($"{entryInfo.Name}");
            }

            Console.WriteLine("======================================");
        }
    }
}
