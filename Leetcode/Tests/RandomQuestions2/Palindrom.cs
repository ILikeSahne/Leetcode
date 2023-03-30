using FluentAssertions;

namespace Leetcode.Tests.RandomQuestions2
{
    public class PalindromeSolution
    {
        public bool IsPalindrome(int x)
        {
            if(x < 0)
                return false;

            var len = (int) Math.Log10(x) + 1;
            for (var i = 0; i < len / 2; i++)
            {
                var num1 = x % 10;
                var nearestPowerOfTen = (int)Math.Pow(10, len - i * 2 - 1);
                var num2 = (x / nearestPowerOfTen) % 10;
                
                if (num1 != num2)
                {
                    return false;
                }

                x /= 10;
            }

            return true;
        }
    }

    public class PalindromeTests
    {
        private readonly PalindromeSolution _palindrome;

        public PalindromeTests()
        {
            _palindrome = new PalindromeSolution();
        }

        [Fact]
        public void Test1()
        {
            // Arrange
            var x = 121;

            // Act
            var result = _palindrome.IsPalindrome(x);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void Test2()
        {
            // Arrange
            var x = -121;

            // Act
            var result = _palindrome.IsPalindrome(x);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void Test3()
        {
            // Arrange
            var x = 10;

            // Act
            var result = _palindrome.IsPalindrome(x);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void Test4()
        {
            // Arrange
            var x = 3;

            // Act
            var result = _palindrome.IsPalindrome(x);

            // Assert
            result.Should().BeTrue();
        }


        [Fact]
        public void Test5()
        {
            // Arrange
            var x = 10;

            // Act
            var result = _palindrome.IsPalindrome(x);

            // Assert
            result.Should().BeFalse();
        }
    }
}
