using System;

namespace WMPio.sample
{
    internal static class Program
    {
        private static int Main(string[] args)
        {
            bool error = false;

            //Show help
            if (args.Length == 0 || args.Contains("-h") || args.Contains("--help"))
            {
                Console.WriteLine($"Usage: {AppDomain.CurrentDomain.FriendlyName} options | inputfile [outputfile] ");
                Console.WriteLine($"Options:");
                Console.WriteLine($"-h, --help   Show help");

                return 0;
            }

            string inFile = args[0];
            Map map = new Map();
            Console.WriteLine($"Importing {inFile}...");
            Console.WriteLine();
            if (map.Parse(inFile)) //read map
            {
                Console.WriteLine(Formatter.FormatStatistics(map));
                Console.WriteLine();

                if (args.Length == 2)
                {
                    string outFile = args[1];
                    Console.WriteLine($"Exporting {outFile}...");
                    if (!map.Export(outFile)) //write map
                    {
                        Console.WriteLine($"Output file {outFile} cannot be written");
                        error = true;
                    }
                }
            }
            else
            {
                Console.WriteLine($"Input file {inFile} cannot be read");
                error = true;
            }

            if (error)
            {
                Console.WriteLine($"{AppDomain.CurrentDomain.FriendlyName} exited with error.");
                return -1;
            }

            return 0;
        }

    }
}
