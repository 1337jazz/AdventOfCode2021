using System.Collections.Generic;

namespace AdventOfCode2021.Day5.Models
{
    public class Line
    {
        public int x1 { get; set; }
        public int y1 { get; set; }
        public int x2 { get; set; }
        public int y2 { get; set; }

        /// <summary>
        /// Returns true if the line is horizontal or vertical
        /// </summary>
        public bool IsHorizontalOrVertical { get => (x1 == x2) || (y1 == y2); }

        public Line(string rawData)
        {
            var line = rawData.Replace(" ", "").Split("->");
            var x1y1 = line[0];
            var x2y2 = line[1];

            x1 = int.Parse(x1y1.Split(",")[0]);
            y1 = int.Parse(x1y1.Split(",")[1]);
            x2 = int.Parse(x2y2.Split(",")[0]);
            y2 = int.Parse(x2y2.Split(",")[1]);
        }

        /// <summary>
        /// Gets the points, as an array of int, on this line, if it's horizonal or vertical
        /// </summary>        
        public IEnumerable<int[]> PointsOnHorizontalOrVerticalLine()
        {
            // Horizontal e.g. (2,2) -> (2,1)
            if (x1 == x2)
                if (y1 > y2)
                    for (int i = y2; i < y1 + 1; i++)
                        yield return new int[] { x1, i };
                else
                    for (int i = y1; i < y2 + 1; i++)
                        yield return new int[] { x1, i };

            // Vertical e.g. (0,9) -> (5,9)
            if (y1 == y2)
                if (x1 > x2)
                    for (int i = x2; i < x1 + 1; i++)
                        yield return new int[] { i, y1 };
                else
                    for (int i = x1; i < x2 + 1; i++)
                        yield return new int[] { i, y1 };
        }

        /// <summary>
        /// Gets the points, as an array of int, on this line, if it's sloping at 45 degrees
        /// </summary>     
        public IEnumerable<int[]> PointsOnDiagonalLine()
        {
            var xList = new List<int>();
            var yList = new List<int>();

            // Add to list of x coordinates
            if (x1 != x2)
                // Ensure we're adding the coordinates in a logical order
                if (x1 < x2)
                    for (int i = x1; i < x2 + 1; i++)
                        xList.Add(i);
                else
                    for (int i = x2; i < x1 + 1; i++)
                        xList.Add(i);


            // Add to list of x coordinates
            if (y1 != y2)
                // Ensure we're adding the coordinates in a logical order
                if (y1 < y2)
                    for (int i = y1; i < y2 + 1; i++)
                        yList.Add(i);
                else
                    for (int i = y2; i < y1 + 1; i++)
                        yList.Add(i);


            // Check to see which way the line slopes (i.e / or \) and loop the list backward is necessary
            if (((x1 > x2) && (y1 < y2)) || ((x1 < x2) && (y1 > y2)))
            {
                // Sloping left to right (/), go backwards
                for (int i = xList.Count - 1; i >= 0; i--)
                    yield return new int[] { xList[i], yList[yList.Count - 1 - i] };
            }
            else
            {
                // Sloping right to left (\), go backwards
                for (int i = 0; i < xList.Count; i++)
                    yield return new int[] { xList[i], yList[i] };
            }
        }

    }
}