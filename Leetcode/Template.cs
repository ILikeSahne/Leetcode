using FluentAssertions;

namespace Leetcode
{
    public class Class1Solution
    {
        public int Solve(int x)
        {
            return x;
        }
    }

    public class Class1Tests
    {
        private Class1Solution _class1;

        public Class1Tests()
        {
            _class1 = new Class1Solution();
        }

        [Fact]
        public void SolveShouldBe5()
        {
            // Arrange
            var x = 5;

            // Act
            var result = _class1.Solve(x);

            // Assert
            result.Should().Be(5);
        }
    }
}
