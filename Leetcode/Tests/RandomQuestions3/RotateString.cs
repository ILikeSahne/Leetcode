using System.Text;
using FluentAssertions;

namespace Leetcode.Tests.RandomQuestions3
{
    public class RotateStringSolution
    {
        public bool RotateString(string s, string goal)
        {
            if(s.Length != goal.Length)
                return false;

            var sb = new StringBuilder();

            for (var i = 0; i < s.Length; i++)
            {
                sb.Clear();
                for (var j = i; j < s.Length + i; j++)
                {
                    sb.Append(s[j % s.Length]);
                }

                if (sb.ToString() == goal)
                {
                    return true;
                }
            }

            return false;
        }
    }

    public class RotateStringTests
    {
        private readonly RotateStringSolution _rotateString;

        public RotateStringTests()
        {
            _rotateString = new RotateStringSolution();
        }

        [Fact]
        public void Test1()
        {
            // Arrange
            var s = "abcde";
            var goal = "cdeab";

            // Act
            var result = _rotateString.RotateString(s, goal);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void Test2()
        {
            // Arrange
            var s = "abcde";
            var goal = "abced";

            // Act
            var result = _rotateString.RotateString(s, goal);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void Test3()
        {
            // Arrange
            var s = "a";
            var goal = "a";

            // Act
            var result = _rotateString.RotateString(s, goal);

            // Assert
            result.Should().BeTrue();
        }
    }
}
