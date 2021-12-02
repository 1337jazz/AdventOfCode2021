using System;

namespace AdventOfCode2021.Day2
{
    public class Day2Solution : SolutionBase
    {
        private int _horizontalPosition = 0, _depth = 0, _aim = 0;

        public override string Part1()
        {
            _horizontalPosition = _depth = 0;

            foreach (var command in Read())
            {
                var split = command.Split(" ");
                var instruction = split[0];
                var amount = int.Parse(split[1]);

                switch (instruction)
                {
                    case "forward": _horizontalPosition += amount; break;
                    case "down": _depth += amount; break;
                    case "up": _depth -= amount; break;
                    default: throw new ArgumentException($"Unknown instruction: {instruction}", nameof(instruction));
                }
            }

            return (_horizontalPosition * _depth).ToString();
        }

        public override string Part2()
        {
            _horizontalPosition = _depth = _aim = 0;

            foreach (var command in Read())
            {
                var split = command.Split(" ");
                var instruction = split[0];
                var amount = int.Parse(split[1]);

                switch (instruction)
                {
                    case "forward":
                        _horizontalPosition += amount;
                        _depth += (_aim * amount);
                        break;
                    case "down":
                        _aim += amount; ; break;
                    case "up":
                        _aim -= amount; break;
                    default: throw new ArgumentException($"Unknown instruction: {instruction}", nameof(instruction));
                }
            }

            return (_horizontalPosition * _depth).ToString();
        }
    }
}