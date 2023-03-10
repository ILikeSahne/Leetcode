using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace Leetcode.Exercises
{
    public class ReverseIntegerSolution
    {
        public int Reverse(int x)
        {
            var neg = 1;
            if (x < 0)
            {
                neg = -1;
                x = -x;
            }

            var reverse = 0;

            try
            {
                while (x > 0)
                {
                    reverse = checked(reverse * 10);
                    reverse = checked(reverse + x % 10);
                    x /= 10;
                }
            }
            catch
            {
                return 0;
            }

            return neg * reverse;
        }
    }

    public class ReverseIntegerTests
    {
        private readonly ReverseIntegerSolution _reverseInteger;

        public ReverseIntegerTests()
        {
            _reverseInteger = new ReverseIntegerSolution();
        }

        [Theory]
        [InlineData(123, 321)]
        [InlineData(-123, -321)]
        [InlineData(120, 21)]
        [InlineData(-2147483648, 0)]
        public void ReverseIntegerTheory(int input, int expected)
        {
            var result = _reverseInteger.Reverse(input);

            result.Should().Be(expected);
        }
    }
}
