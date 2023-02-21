using System.Text;
using FluentAssertions;

namespace Leetcode.Exercises
{
    public class ZigzagConversionSolution
    {
        public string Convert(string s, int numRows)
        {
            if (numRows <= 1)
                return s;

            var outputLists = new List<char>[numRows];
            for (var i = 0; i < numRows; i++)
            {
                outputLists[i] = new List<char>();
            }

            var y = 0;

            var down = true;

            foreach (var c in s)
            {
                outputLists[y].Add(c);

                if (down)
                    y++;
                else
                    y--;

                if (down && y == numRows)
                {
                    y = numRows - 2;
                    down = false;
                }

                if (!down && y == -1)
                {
                    down = true;
                    y = 1;
                }
            }

            var sb = new StringBuilder();
            foreach (var line in outputLists)
            {
                foreach (var c in line)
                {
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }
    }

    public class ZigzagConversionTests
    {
        private readonly ZigzagConversionSolution _zigzagConversion;

        public ZigzagConversionTests()
        {
            _zigzagConversion = new ZigzagConversionSolution();
        }

        [Theory]
        [InlineData("PAYPALISHIRING", 3, "PAHNAPLSIIGYIR")]
        [InlineData("PAYPALISHIRING", 4, "PINALSIGYAHRPI")]
        [InlineData("A", 1, "A")]
        public void ZigzagConversionTheory(string input, int numRows, string expected)
        {
            var result = _zigzagConversion.Convert(input, numRows);

            result.Should().Be(expected);
        }
    }
}
