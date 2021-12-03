using System;
using System.Collections.Generic;
using System.Linq;


// #######################################################################
//                 WARNING: VERY UGLY CODE - BEFORE REFACTOR
// #######################################################################

namespace AdventOfCode2021.Day3
{
    public class Day3Solution : SolutionBase
    {
        public override string Part1()
        {
            var gamma = new List<int>();
            var epsilon = new List<int>();

            int numOf0 = 0, numOf1 = 0;

            for (int i = 0; i < 12; i++)
            {
                foreach (var num in Read())
                {
                    if (num[i].ToString() == "0")
                    {
                        numOf0++;
                    }
                    else if (num[i].ToString() == "1")
                    {
                        numOf1++;
                    }
                    else
                    {
                        throw new System.Exception("fail");
                    }
                }

                var mostCommon = numOf0 > numOf1 ? 0 : 1;
                var leastCommon = mostCommon == 0 ? 1 : 0;

                gamma.Add(mostCommon);
                epsilon.Add(leastCommon);

                numOf0 = 0;
                numOf1 = 0;
            }

            var gJoin = string.Join("", gamma.Select(x => x.ToString()).ToArray());
            var gDec = Convert.ToInt32(gJoin, 2);

            var eJoin = string.Join("", epsilon.Select(x => x.ToString()).ToArray());
            var eDec = Convert.ToInt32(eJoin, 2);

            return (gDec * eDec).ToString();

        }

        public override string Part2()
        {
            var oxygen = string.Empty;
            var co2 = string.Empty;

            var data = Read();

            var numbersWithMostCommon = data.ToArray();
            var numbersWithLeastCommon = data.ToArray();

            // Oxygen
            for (int i = 0; i < 12; i++)
            {
                var mostCommon = CommonAtPosition(Common.Most, numbersWithMostCommon, i);
                var temp = numbersWhereBitIs(numbersWithMostCommon, i, mostCommon);

                if (temp.Count() == 1)
                {
                    oxygen = temp[0];
                    break;
                }

                numbersWithMostCommon = temp.ToArray();
            }

            // CO2 (why be DRY when you can be WET?)
            for (int i = 0; i < 12; i++)
            {
                var leastCommon = CommonAtPosition(Common.Least, numbersWithLeastCommon, i);
                var temp = numbersWhereBitIs(numbersWithLeastCommon, i, leastCommon);

                if (temp.Count() == 1)
                {
                    co2 = temp[0];
                    break;
                }

                numbersWithLeastCommon = temp.ToArray();
            }

            if (oxygen == string.Empty || co2 == string.Empty)
            {
                throw new Exception("Something bad happened");
            }

            var oxygenDec = Convert.ToInt32(oxygen, 2);
            var co2Dec = Convert.ToInt32(co2, 2);

            return (oxygenDec * co2Dec).ToString();
        }

        private List<string> numbersWhereBitIs(string[] data, int index, int bit)
        {
            var list = new List<string>();

            foreach (var item in data)
            {
                if (int.Parse(item[index].ToString()) == bit)
                {
                    list.Add(item);
                }
            }

            return list;
        }

        private int CommonAtPosition(Common common, string[] data, int index)
        {
            var numOf0 = 0;
            var numOf1 = 0;

            foreach (var num in data)
            {
                if (num[index].ToString() == "0")
                {
                    numOf0++;
                }
                else if (num[index].ToString() == "1")
                {
                    numOf1++;
                }
                else
                {
                    throw new System.Exception("fail");
                }
            }

            if (common == Common.Most)
            {
                return numOf0 == numOf1 ? 1 : numOf0 > numOf1 ? 0 : 1;
            }
            else
            {
                return numOf0 == numOf1 ? 0 : numOf0 < numOf1 ? 0 : 1;
            }
        }

        public enum Common
        {
            Most, Least
        }
    }
}