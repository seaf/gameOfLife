using System;
using System.Collections.Generic;

namespace GameOfLife
{
    class Program
    {
        private const string INPUT_DONE = "done";

        static void Main(string[] args)
        {
            // TODO: Consider reading from a file for easier editing of large input and providing set complex input
            var inputCoords = new HashSet<Tuple<ulong, ulong>>();
            while (true)
            {
                Console.WriteLine("Enter coordinates (as 64-bit integers) of a living cell, separated by a comma (e.g. x,y). Enter \"done\" to finish:");
                var line = Console.ReadLine().Trim().ToLowerInvariant();
                if (line == INPUT_DONE)
                {
                    break;
                }

                var coords = line.Split(',');
                if (coords.Length != 2)
                {
                    Console.WriteLine("Coordinates must be of the form \"x,y\".");
                    continue;
                }

                if (!ulong.TryParse(coords[0], out ulong x) || !ulong.TryParse(coords[1], out ulong y))
                {
                    Console.WriteLine($"Unable to parse coordinates. x: {coords[0]}, y: {coords[1]}.");
                    continue;
                }

                inputCoords.Add(Tuple.Create(x, y));
            }

            // For now, just echo input.
            Console.WriteLine("Provided input:");
            foreach (var pair in inputCoords)
            {
                Console.WriteLine(pair);
            }

            Console.WriteLine("Hit ENTER to exit.");
            Console.ReadLine();
        }
    }
}
