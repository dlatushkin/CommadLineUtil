using System;

namespace CommandLineUtil.Command
{
    public class CommandOne
    {
        public static readonly string Moniker = "commandone";

        public static readonly string Help = "[-m|--message] [MESSAGE]";

        public static void Execute(CommandOneArguments arguments)
        {
            Console.WriteLine($"{nameof(CommandOne)}");
            Console.WriteLine("======================================");
            Console.WriteLine($"{arguments.Message}");
            Console.WriteLine("======================================");
        }
    }
}
