using System;
using System.Collections.Generic;

namespace AdventOfCode2021.Day5
{
    public static class GraphUtils
    {
        /// <summary>
        /// Get the number of lines that are overlapping on a graph (>1)
        /// </summary>
        public static int OverlappingLineCount(string[,] graph)
        {
            int numLines = 0;

            for (int i = 0; i < graph.GetLength(0); i++)
                for (int j = 0; j < graph.GetLength(1); j++)
                    if (int.TryParse(graph[i, j], out var value))
                        if (value > 1)
                            numLines++;

            return numLines;
        }

        /// <summary>
        /// Creates a graph of 1000x1000 by default as a 2d array
        /// </summary>
        public static string[,] CreateGraph(int length = 1000, int width = 1000)
        {
            // Create the graph
            var graph = new string[length, width];

            for (int i = 0; i < graph.GetLength(0); i++)
                for (int j = 0; j < graph.GetLength(1); j++)
                    graph[i, j] = ".";

            return graph;
        }

        /// <summary>
        /// Takes a list of points and updates a graph. If a point is a number, the corresponding point on the graph is updated,
        /// otherwise the point is added as (1)
        /// </summary>
        public static void UpdateGraph(string[,] graph, List<int[]> points)
        {
            foreach (var point in points)
            {
                var pointOnGraph = graph[point[0], point[1]];

                if (pointOnGraph == ".")
                    graph[point[0], point[1]] = "1";
                else if (int.TryParse(pointOnGraph, out var num))
                    graph[point[0], point[1]] = (num + 1).ToString();
            }
        }

        /// <summary>
        /// Draws a graph (useful for testing)
        /// </summary> 
        public static void DrawGraph(string[,] graph)
        {
            Console.WriteLine("\n==================================================\n");
            // Draw the graph (flipped)
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                for (int j = 0; j < graph.GetLength(1); j++)
                {
                    Console.Write(graph[j, i]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n==================================================\n");
        }
    }
}