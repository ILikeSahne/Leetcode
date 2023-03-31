using FluentAssertions;

namespace Leetcode.Tests.RandomQuestions3
{
    public class MajorityElementSolution
    {
        public IList<int> MajorityElement(int[] nums)
        {
            var len = nums.Length;
            var dict = nums.Distinct().ToDictionary(n => n, n => nums.Count(n2 => n2 == n));

            var list = new List<int>();

            foreach (var kv in dict)
            {
                if (kv.Value > len / 3)
                {
                    list.Add(kv.Key);
                }
            }

            return list;
        }
    }

    public class MajorityElementTests
    {
        private readonly MajorityElementSolution _majorityElement;

        public MajorityElementTests()
        {
            _majorityElement = new MajorityElementSolution();
        }

        [Fact]
        public void Test1()
        {
            // Arrange
            var nums = new[]
            {
                3, 2, 3
            };

            // Act
            var result = _majorityElement.MajorityElement(nums);

            // Assert
            result.Count.Should().Be(1);
            result[0].Should().Be(3);
        }

        [Fact]
        public void Test2()
        {
            // Arrange
            var nums = new[]
            {
                1
            };

            // Act
            var result = _majorityElement.MajorityElement(nums);

            // Assert
            result.Count.Should().Be(1);
            result[0].Should().Be(1);
        }

        [Fact]
        public void Test3()
        {
            // Arrange
            var nums = new[]
            {
                1,2
            };

            // Act
            var result = _majorityElement.MajorityElement(nums);

            // Assert
            result.Count.Should().Be(2);
            result[0].Should().Be(1);
            result[1].Should().Be(2);
        }
    }
}
