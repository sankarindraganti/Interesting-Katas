using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace SafestPlaceInGalaxy
{
    public class Program
    {
        public List<Attempt> ReadData(string inputFilePath)
        {
            var result = new List<Attempt>();
            // ReSharper disable once CollectionNeverQueried.Local
            var locations = new List<int>();
            using (var streamReader = new StreamReader(inputFilePath))
            {
                var noOfTestCases = int.Parse(streamReader.ReadLine());
                Console.WriteLine(noOfTestCases);

                while (!streamReader.EndOfStream)
                {
                    var bombs = streamReader.ReadLine();
                    if (!string.IsNullOrEmpty(bombs))
                         locations.AddRange(bombs.Split(' ').Where(x=> !string.IsNullOrEmpty(x)).Select(int.Parse).ToList());
                }
            }

            while (locations.Count > 0)
            {
                var resultantAttempt = new Attempt();

                var numberOfLocations = locations.First();
                var coordinates = locations.Skip(1).Take(numberOfLocations*3).ToList();

                resultantAttempt.NumberOfLocations = numberOfLocations;
                resultantAttempt.Locations = new List<Location>();

                for (var i = 0; i < coordinates.Count; i += 3)
                {
                    var location = new Location
                    {
                        X = coordinates[i],
                        Y = coordinates[i + 1],
                        Z = coordinates[i + 2]
                    };
                    resultantAttempt.Locations.Add(location);
                }

                result.Add(resultantAttempt);

                locations.RemoveRange(0,numberOfLocations * 3+1);
            }

            return result;
        }

        private static void Main()
        {
            var p = new Program();
            const string input = "input.txt";
            var attempts = p.ReadData(input);
            foreach (var attempt in attempts)
            {
                Console.WriteLine(attempt.GetSafestDistance());
            }
            Console.Read();
        }
    }
}
