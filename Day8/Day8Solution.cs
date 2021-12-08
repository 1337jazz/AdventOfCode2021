using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Day8
{
    public class Day8Solution : SolutionBase
    {
        public override string Part1()
        {

            var data = Read();
            List<string> signalPatterns = new List<string>();
            List<string> outputs = new List<string>();


            // Read into lists
            foreach (var line in data)
            {
                signalPatterns.Add(line.Split(" | ")[0]);
                outputs.Add(line.Split(" | ")[1]);
            }

            var count = 0;

            foreach (var item in outputs)
            {
                var numbers = item.Split(" ");

                foreach (var number in numbers)
                {
                    var guessedNumber = GuessNumber(number);

                    if (guessedNumber != 99)
                    {
                        count++;
                    }
                }
            }

            return count.ToString();
        }

        public override string Part2()
        {
            var data = Read();
            List<string> signalPatterns = new List<string>();
            List<string> outputs = new List<string>();


            // Read into lists
            foreach (var line in data)
            {
                signalPatterns.Add(line.Split(" | ")[0]);
                outputs.Add(line.Split(" | ")[1]);
            }



            var sum = 0;

            for (int i = 0; i < outputs.Count; i++)
            {
                var output = outputs[i].Split(" ");
                var pattern = signalPatterns[i].Split(" ");

                // For each pattern
              
                    var num = GuessNumber2(pattern, output);
                    System.Console.WriteLine(num);
                    sum += num;
                
            }





            return sum.ToString();
        }

        private int GuessNumber(string numberFromOutput)
        {
            switch (numberFromOutput.Length)
            {
                case 2: return 1;
                case 4: return 4;
                case 3: return 7;
                case 7: return 8;
                default: return 99;
            }
        }

        private int GuessNumber2(string[] pattern, string[] output)
        {
            /*            
               111
              2    3
              2    3
               4444
              5    6
              5    6
               7777
            */

            // First analyse the pattern
            // example input: be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb

            var dict = new Dictionary<int, string>();

            // Loop the pattern and get the easy ones
            foreach (var patt in pattern)
            {
                switch (patt.Length)
                {
                    case 2:
                        dict.Add(1, patt);
                        break;
                    case 4:
                        dict.Add(4, patt);
                        break;
                    case 3:
                        dict.Add(7, patt);
                        break;
                    case 7:
                        dict.Add(8, patt);
                        break;
                    default: break;
                }
            }

            var failed9 = false;

            // Loop again and get the hard ones, based on the info from the easy ones
            foreach (var patt in pattern)
            {
                switch (patt.Length)
                {
                    case 5: // could be 2, 3 or 5
                        if (PatternContains(patt, dict[1]))
                        {
                            // Only a 3 contains everything from 1
                            dict.Add(3, patt);
                            break;
                        }
                        else
                        {
                            // is a 2 or a 5
                            // 2 has 4 of 9
                            // 5 has 5 of 9
                            if (dict.ContainsKey(9))
                            {
                                var x = numMatchesBetween(patt, dict[9]);

                                if (x == 5)
                                {
                                    dict.Add(5, patt);
                                }
                                else
                                {
                                    dict.Add(2, patt);
                                }
                                break;
                            }
                            else
                            {
                                failed9 = true;
                                break;
                            }
                        }
                    case 6: //  could be 6, 9 or 0                        
                        if (PatternContains(patt, dict[1]))
                        {
                            // Not a 6
                            // If it's a 6, it can't have both a [b and an e]

                            // Could be 0 or 9
                            // If it's a 9 it should contain everything from 4
                            if (PatternContains(patt, dict[4]))
                            {
                                // must be 9
                                dict.Add(9, patt);
                                break;
                            }
                            else
                            {
                                dict.Add(0, patt);
                                break;
                            }
                        }

                        // Must be a 6
                        dict.Add(6, patt);
                        break;

                    default:
                        break;
                }
            }

            // 2 = 5
            // 3 = 5
            // 5 = 5
            // 6 = 6
            // 9 = 6
            // 0 = 6


            if (failed9)
            {
                foreach (var patt in pattern)
                {
                    if (dict.Count == 10)
                    {
                        break;
                    }

                    if (patt.Length == 5)
                    {

                        var x = numMatchesBetween(patt, dict[9]);
                        
                        if (!PatternContains(patt, dict[1]))// true = 3 again
                        {
                            if (x == 5)
                            {
                                dict.Add(5, patt);
                            }
                            else
                            {
                                dict.Add(2, patt);
                            }
                        }

                    }
                }

            }

            // Decode and return
            var decodedValueString = string.Empty;

            foreach (var item in output)
            {
                var myKey = dict.FirstOrDefault(x => PatternContainsStrict(item, x.Value)).Key;
                decodedValueString += myKey.ToString();
            }

            
            return int.Parse(decodedValueString);
        }

        private bool PatternContains(string pattern, string comparison)
        {
            foreach (var item in comparison)
            {
                if (!pattern.Contains(item))
                {
                    return false;
                }
            }

            return true;
        }

        private bool PatternContainsStrict(string pattern, string comparison)
        {
            if (pattern.Length != comparison.Length) return false;
            foreach (var item in comparison)
            {
                if (!pattern.Contains(item))
                {
                    return false;
                }
            }

            return true;
        }

        private int numMatchesBetween(string comp1, string comp2)
        {
            var count = 0;
            foreach (var item in comp1)
            {
                if (comp2.Contains(item))
                {
                    count++;
                }
            }

            return count;
        }
    }
}