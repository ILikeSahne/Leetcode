using FluentAssertions;

namespace Leetcode.Exercises
{
    public class StringToIntegerSolution
    {
        public int MyAtoi(string s)
        {
            s = s.TrimStart();

            if (s.Length == 0)
                return 0;

            var i = 0;

            var neg = false;
            if (s[i] == '+' || s[i] == '-')
            {
                neg = s[i] == '-';
                i++;
            }

            var sum = 0;
            for (; i < s.Length; i++)
            {
                var c = s[i];
                if (!char.IsDigit(c))
                {
                    break;
                }

                c -= '0';

                if (!neg)
                {
                    try
                    {
                        sum = checked(sum * 10 + c);
                    }
                    catch
                    {
                        sum = int.MaxValue;
                    }
                }
                else
                {
                    try
                    {
                        sum = checked(sum * 10 - c);
                    }
                    catch
                    {
                        sum = int.MinValue;
                    }
                }
            }

            return sum;
        }
    }

    public class StringToIntegerTests
    {
        private readonly StringToIntegerSolution _stringToInteger;

        public StringToIntegerTests()
        {
            _stringToInteger = new StringToIntegerSolution();
        }

        [Theory]
        [InlineData("42", 42)]
        [InlineData("   -42", -42)]
        [InlineData("4193 with words", 4193)]
        [InlineData("42  33", 42)]
        [InlineData("   42x3", 42)]
        [InlineData("-91283472332", -2147483648)]
        public void StringToIntegerTheory(string input, int expected)
        {
            var result = _stringToInteger.MyAtoi(input);

            result.Should().Be(expected);
        }
    }
}
