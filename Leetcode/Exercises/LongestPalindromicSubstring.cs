using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace Leetcode.Exercises
{
    public class LongestPalindromicSubstringSolution
    {
        public string LongestPalindrome(string s)
        {
            int maxLength = 0, startIndex = 0;
            for (var i = 0; i < s.Length; i++)
            {
                int start = i, end = i;
                while (end < s.Length - 1 && s[start] == s[end + 1])
                    end++;

                while (end < s.Length - 1 && start > 0 && s[start - 1] == s[end + 1])
                {
                    start--;
                    end++;
                }
                if (maxLength < end - start + 1)
                {
                    maxLength = end - start + 1;
                    startIndex = start;
                }
            }
            return s.Substring(startIndex, maxLength);
        }
    }

    public class LongestPalindromicSubstringTests
    {
        private readonly LongestPalindromicSubstringSolution _longestPalindromicSubstring;

        public LongestPalindromicSubstringTests()
        {
            _longestPalindromicSubstring = new LongestPalindromicSubstringSolution();
        }

        [Theory]
        [InlineData("babad", "bab")]
        [InlineData("cbbd", "bb")]
        public void LongestPalindromicSubstringTheory(string input, string expected)
        {
            var result = _longestPalindromicSubstring.LongestPalindrome(input);

            result.Should().Be(expected);
        }
    }
}
