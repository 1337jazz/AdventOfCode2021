using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2021
{
    public abstract class SolutionBase
    {
        public string DayName
        {
            get
            {
                return GetType().Namespace.Split(".")[1];
            }
        }

        public abstract string Part1();
        public abstract string Part2();

        public SolutionBase()
        {
            Run();
        }

        public virtual void Run()
        {
            Console.WriteLine("\n-----------------------");
            Console.WriteLine(DayName);
            Console.WriteLine("-----------------------");
            Console.WriteLine($"P1: {Part1()}");
            Console.WriteLine($"P2: {Part2()}");
            Console.WriteLine("-----------------------\n");
        }

        protected virtual string[] Read()
        {
            return File.ReadAllLines($"./{DayName}/puzzle_input.txt");
        }

        protected virtual IEnumerable<int> ReadAsInt()
        {
            foreach (var item in Read())
            {
                yield return int.Parse(item);
            }
        }
    }
}