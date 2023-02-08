using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace Leetcode.Exercises
{
    public class TwoSumSolution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            var differences = new Dictionary<int, int>();
            for (var i = 0; i < nums.Length; i++)
            {
                var num = nums[i];
                var dif = target - num;
                
                if (differences.ContainsKey(dif))
                {
                    return new[]
                    {
                        differences[dif], i
                    };
                }

                if(!differences.ContainsKey(num))
                    differences.Add(num, i);
            }

            return Array.Empty<int>();
        }
    }

    public class TwoSumTests
    {
        private readonly TwoSumSolution _twoSum;

        public TwoSumTests()
        {
            _twoSum = new TwoSumSolution();
        }

        [Fact]
        public void TwoSumShouldReturn0And1()
        {
            var expected1 = new[] { 0, 1 };
            var expected2 = new[] { 1, 0 };

            var actual = _twoSum.TwoSum(new[] { 2, 7, 11, 15 }, 9);

            actual.EqualsToOne(expected1, expected2).Should().BeTrue();
        }
    }
}
