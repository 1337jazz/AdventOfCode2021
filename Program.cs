using System;
using System.Linq;
using System.Reflection;

namespace AdventOfCode2021
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly.GetCallingAssembly().GetTypes()
                    .Where(t => t.IsSubclassOf(typeof(SolutionBase)))
                    .OrderBy(t => int.Parse(t.Name.Replace("Day", "").Replace("Solution", "")))
                    .ToList()
                    .ForEach(t => Activator.CreateInstance(t));
        }
    }
}
