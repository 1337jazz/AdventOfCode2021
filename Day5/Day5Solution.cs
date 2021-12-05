using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2021.Day5.Models;

namespace AdventOfCode2021.Day5
{
    public class Day5Solution : SolutionBase
    {
        public override string Part1()
        {
            // Get the lines
            List<Line> lines = GetLines();

            // Create a new, blank graph
            var graph = GraphUtils.CreateGraph();

            // Loop the lines
            foreach (var line in lines)
            {
                // Get the points on the line
                var points = line.PointsOnHorizontalOrVerticalLine().ToList();

                // Update the graph with the points
                GraphUtils.UpdateGraph(graph, points);
            }

            return GraphUtils.OverlappingLineCount(graph).ToString();
        }

        public override string Part2()
        {
            // Get the lines
            List<Line> lines = GetLines();

            // Create a new, blank graph
            var graph = GraphUtils.CreateGraph();

            // Loop each line
            foreach (var line in lines)
            {
                List<int[]> points;

                // Check if line is horiztonal or vertical and apply the correct method to get the points
                // on the line
                if (line.IsHorizontalOrVertical)
                    points = line.PointsOnHorizontalOrVerticalLine().ToList();
                else
                    points = line.PointsOnDiagonalLine().ToList();

                // Update the graph with the points
                GraphUtils.UpdateGraph(graph, points);
            }

            return GraphUtils.OverlappingLineCount(graph).ToString();
        }

        /// <summary>
        /// Helper method for reading the raw data into a list of Line objects
        /// </summary>        
        private List<Line> GetLines()
        {
            var data = Read();
            var lines = new List<Line>();

            // Get the lines
            foreach (var item in data)
                lines.Add(new Line(item));

            return lines;
        }

    }

}