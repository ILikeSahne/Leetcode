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
            var longest = "";

            for (var i = 0; i < s.Length; i++)
            {
                for (var j = i; j < s.Length; j++)
                {
                    var sub = s.Substring(i, j - i + 1);
                    if (IsPalindrome(sub))
                    {
                        if(sub.Length > longest.Length)
                            longest = sub;
                    }
                }
            }

            return longest;
        }

        // IsPalindrome approach that takes a runtime of O(N)
        //private bool IsPalindrome(string s)
        //{
        //    for (var i = 0; i < s.Length / 2; i++)
        //    {
        //        if (s[i] != s[s.Length - i - 1])
        //            return false;
        //    }

        //    return true;
        //}

        private readonly Dictionary<string, bool> _checkedSubstrings = new();

        // Using recursion and a Dictionary to store previous results allows us to only test every substring once, taking its time down to O(1)
        private bool IsPalindrome(string s)
        {
            if (_checkedSubstrings.ContainsKey(s))
                return _checkedSubstrings[s];

            if (s.Length <= 1)
            {
                _checkedSubstrings[s] = true;
                return true;
            }

            if (s[0] == s[^1] && IsPalindrome(s.Substring(1, s.Length - 2)))
            {
                _checkedSubstrings[s] = true;
                return true;
            }

            _checkedSubstrings[s] = false;
            return false;
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
