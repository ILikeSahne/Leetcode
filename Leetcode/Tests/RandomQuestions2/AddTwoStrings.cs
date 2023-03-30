using FluentAssertions;

namespace Leetcode.Tests.RandomQuestions2
{
    public class AddTwoStringsSolution
    {
        public string AddStrings(string num1, string num2)
        {
            var result = "";
            var i1 = 0;
            var i2 = 0;
            var carry = 0;
            while (i1 != num1.Length || i2 != num2.Length)
            {
                var n1 = 0;
                var n2 = 0;

                if (i1 < num1.Length)
                {
                    n1 = num1[^(i1 + 1)] - '0';
                    i1++;
                }

                if (i2 < num2.Length)
                {
                    n2 = num2[^(i2 + 1)] - '0';
                    i2++;
                }

                var sum = n1 + n2 + carry;

                carry = sum / 10;
                result = sum % 10 + result;
            }

            if (carry > 0)
            {
                result = carry + result;
            }

            return result;
        }
    }

    public class AddTwoStringsTests
    {
        private readonly AddTwoStringsSolution _addTwoStrings;

        public AddTwoStringsTests()
        {
            _addTwoStrings = new AddTwoStringsSolution();
        }

        [Fact]
        public void Test1()
        {
            // Arrange
            var num1 = "11";
            var num2 = "123";

            // Act
            var result = _addTwoStrings.AddStrings(num1, num2);

            // Assert
            result.Should().Be("134");
        }

        [Fact]
        public void Test2()
        {
            // Arrange
            var num1 = "456";
            var num2 = "77";

            // Act
            var result = _addTwoStrings.AddStrings(num1, num2);

            // Assert
            result.Should().Be("533");
        }

        [Fact]
        public void Test3()
        {
            // Arrange
            var num1 = "0";
            var num2 = "0";

            // Act
            var result = _addTwoStrings.AddStrings(num1, num2);

            // Assert
            result.Should().Be("0");
        }

        [Fact]
        public void Test4()
        {
            // Arrange
            var num1 = "1";
            var num2 = "9";

            // Act
            var result = _addTwoStrings.AddStrings(num1, num2);

            // Assert
            result.Should().Be("10");
        }
    }
}
