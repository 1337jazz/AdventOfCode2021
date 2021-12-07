using System;
using System.Linq;

namespace AdventOfCode2021.Day7
{
    public class Day7Solution : SolutionBase
    {
        public override string Part1()
        {
            var positions = Read()[0].Split(",");

            int lowest = int.MaxValue;

            for (int i = 0; i < positions.Length; i++)
            {
                int current = int.Parse(positions[i]);
                var sum = 0;

                for (int j = 0; j < positions.Length; j++)
                {
                    int test = int.Parse(positions[j]);
                    sum += Math.Abs(current - test);
                }

                if (sum < lowest)
                {
                    lowest = sum;
                };
            }

            Console.WriteLine(lowest);

            return null;
        }

        public override string Part2()
        {
            var positions = Read()[0].Split(",");

            var max = positions.Select(int.Parse).ToArray().Max();

            int lowest = int.MaxValue;

            for (int i = 0; i < max + 1; i++)
            {
                var test = i;
                var sum = 0;

                for (int j = 0; j < positions.Length; j++)
                {
                    var current = int.Parse(positions[j]);

                    var distance = Math.Abs(test - current);

                    var fuelRequired = (distance * (distance + 1)) / 2;

                    sum += fuelRequired;

                }

                if (sum < lowest)
                {
                    lowest = sum;
                };

            }

            return lowest.ToString();
        }
    }
}