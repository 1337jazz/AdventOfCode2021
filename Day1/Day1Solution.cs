using System.Linq;

namespace AdventOfCode2021.Day1
{
    public class Day1Solution : SolutionBase
    {
        public override string Part1()
        {
            var numberIncreased = 0;
            var data = ReadAsInt().ToArray();

            for (int i = 0; i < data.Length; i++)
            {
                if (i > 0 && (data[i - 1] < data[i]))
                {
                    numberIncreased++;
                }
            }

            return numberIncreased.ToString();
        }

        public override string Part2()
        {
            var numberIncreased = 0;
            var data = ReadAsInt().ToArray();

            for (int i = 0; i < data.Length; i++)
            {
                if (i == data.Length - 3)
                {
                    break;
                }

                var m1 = data[i];
                var m2 = data[i + 1];
                var m3 = data[i + 2];
                var m4 = data[i + 3];

                var window1 = (m1 + m2 + m3);
                var window2 = (m2 + m3 + m4);

                if (window1 < window2) { numberIncreased++; }
            }

            return numberIncreased.ToString();
        }
    }
}