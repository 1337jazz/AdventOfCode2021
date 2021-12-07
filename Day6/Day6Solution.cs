using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Day6
{
    public class Day6Solution : SolutionBase
    {
        public override string Part1()
        {
            var data = Read()[0];

            var initialFish = new List<int>();
            var newFish = new List<int>();

            foreach (var item in data.Split(","))
            {
                initialFish.Add(int.Parse(item));
            }

            // Console.WriteLine($"Intial state: {string.Join(",", initialFish.ToArray())}");

            for (int i = 0; i < 80; i++)
            {
                foreach (var f in initialFish)
                {
                    if (f == 0)
                    {
                        newFish.Add(6);
                        newFish.Add(8);
                    }
                    else
                    {
                        newFish.Add(f - 1);
                    }
                }

                initialFish = new List<int>(newFish);
                newFish = new List<int>();
            }


            return initialFish.Count().ToString();
        }

        public override string Part2()
        {
            var data = Read()[0].Split(',')
            .Select(int.Parse)
            // don't keep track of each fish individually
            // only keep track of how many of each age
            .GroupBy(x => x)
            .ToDictionary(g => g.Key, g => (long)g.Count());

            for (int i = 0; i < 256; i++)
            {
                data = DayCycle(data);
            }

            return data.Values.Sum().ToString();
        }

        static Dictionary<int, long> DayCycle(Dictionary<int, long> fish) =>
             new()
             {
                // all of the 0 ages go to 8 as new fish
                [8] = fish.GetValueOrDefault(0),
                 [7] = fish.GetValueOrDefault(8),
                // 0 ages go to 6, along with 7 ages
                [6] = fish.GetValueOrDefault(0) + fish.GetValueOrDefault(7),
                 [5] = fish.GetValueOrDefault(6),
                 [4] = fish.GetValueOrDefault(5),
                 [3] = fish.GetValueOrDefault(4),
                 [2] = fish.GetValueOrDefault(3),
                 [1] = fish.GetValueOrDefault(2),
                 [0] = fish.GetValueOrDefault(1),
             };
    }
}