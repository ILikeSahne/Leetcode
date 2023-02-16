using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace Leetcode.Exercises
{
    public class FindMedianSortedArraysSolution
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var len = nums1.Length + nums2.Length;

            var p1 = 0;
            var p2 = 0;

            int GetNum(int[] nums, int p)
            {
                return p >= nums.Length ? int.MaxValue : nums[p];
            }

            if ((len & 1) == 1) // odd
            {
                for (var i = 0; i < len / 2; i++)
                {
                    var n1 = GetNum(nums1, p1);
                    var n2 = GetNum(nums2, p2);

                    if (n1 < n2 && p1 < nums1.Length)
                    {
                        p1++;
                    }
                    else
                    {
                        p2++;
                    }
                }

                return Math.Min(GetNum(nums1, p1), GetNum(nums2, p2));
            }
            else // even
            {
                var prev = 0;
                for (var i = 0; i < len / 2; i++)
                {
                    var n1 = GetNum(nums1, p1);
                    var n2 = GetNum(nums2, p2);

                    prev = Math.Min(n1, n2);

                    if (n1 < n2 && p1 < nums1.Length)
                    {
                        p1++;
                    }
                    else
                    {
                        p2++;
                    }
                }

                return (Math.Min(GetNum(nums1, p1), GetNum(nums2, p2)) + prev) / 2d;
            }
        }
    }

    public class FindMedianSortedArraysTests
    {
        private readonly FindMedianSortedArraysSolution _findMedianSortedArrays;

        public FindMedianSortedArraysTests()
        {
            _findMedianSortedArrays = new FindMedianSortedArraysSolution();
        }

        [Fact]
        public void MedianShouldBe2()
        {
            var actual = _findMedianSortedArrays.FindMedianSortedArrays(new[] { 1, 3 }, new[] { 2 });
            actual.Should().Be(2);
        }

        [Fact]
        public void MedianShouldBe2Point5()
        {
            var actual = _findMedianSortedArrays.FindMedianSortedArrays(new[] { 1, 2 }, new[] { 3, 4 });
            actual.Should().Be(2.5);
        }

        [Fact]
        public void MedianShouldBe2Point5OneListEmpty()
        {
            var actual = _findMedianSortedArrays.FindMedianSortedArrays(Array.Empty<int>(), new[] { 2, 3 });
            actual.Should().Be(2.5);
        }
    }
}
