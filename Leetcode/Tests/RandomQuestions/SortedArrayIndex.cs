using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace Leetcode.Tests.RandomQuestions
{
    public class SortedArrayIndexSolution
    {
        public int SearchInsert(int[] nums, int target)
        {
            for (var i = 0; i < nums.Length; i++)
            {
                var n = nums[i];

                if (n >= target)
                {
                    return i;
                }
            }

            return nums.Length;
        }
    }

    public class SortedArrayIndexTests
    {
        private readonly SortedArrayIndexSolution _sortedArrayIndex;

        public SortedArrayIndexTests()
        {
            _sortedArrayIndex = new SortedArrayIndexSolution();
        }

        [Fact]
        public void SortedArrayIndexShouldBe2()
        {
            var result = _sortedArrayIndex.SearchInsert(new []{ 1, 3, 5, 6 }, 5);

            result.Should().Be(2);
        }

        [Fact]
        public void SortedArrayIndexShouldBe1()
        {
            var result = _sortedArrayIndex.SearchInsert(new[] { 1, 3, 5, 6 }, 2);

            result.Should().Be(1);
        }

        [Fact]
        public void SortedArrayIndexShouldBe4()
        {
            var result = _sortedArrayIndex.SearchInsert(new[] { 1, 3, 5, 6 }, 7);

            result.Should().Be(4);
        }
    }
}
