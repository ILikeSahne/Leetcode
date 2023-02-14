using FluentAssertions;

namespace Leetcode.Exercises
{
    public class LengthOfLongestSubstringSolution
    {
        public int LengthOfLongestSubstring_SlowApproach(string s)
        {
            var maxLength = 0;

            var characters = new HashSet<char>();
            var length = 0;

            for (var i = 0; i < s.Length; i++)
            {
                var j = i;
                for (; j < s.Length; j++)
                {
                    var c = s[j];

                    if (characters.Contains(c))
                    {
                        if (length > maxLength)
                        {
                            maxLength = length;
                        }

                        break;
                    }

                    length++;
                    characters.Add(c);
                }

                if (j == s.Length)
                {
                    if (length > maxLength)
                    {
                        maxLength = length;
                    }

                    break;
                }

                characters.Clear();
                length = 0;
            }
            return maxLength;
        }

        public int LengthOfLongestSubstring(string s)
        {
            var maxLength = 0;

            var startPos = 0;

            var characters = new Dictionary<char, int>();

            var i = 0;
            for (; i < s.Length; i++)
            {
                var c = s[i];
                if (characters.ContainsKey(c))
                {
                    startPos = Math.Max(startPos, characters[c] + 1);
                }

                var len = i - startPos + 1;
                if (len > maxLength)
                {
                    maxLength = len;
                }

                if (characters.ContainsKey(c))
                {
                    characters[c] = i;
                }
                else
                {
                    characters.Add(c, i);
                }
            }

            return maxLength;
        }
    }

    public class LengthOfLongestSubstringTests
    {
        private readonly LengthOfLongestSubstringSolution _lengthOfLongestSubstring;

        public LengthOfLongestSubstringTests()
        {
            _lengthOfLongestSubstring = new LengthOfLongestSubstringSolution();
        }

        [Theory]
        [InlineData("abcabcbb", 3)]
        [InlineData("bbbbb", 1)]
        [InlineData("pwwkew", 3)]
        [InlineData("aab", 2)]
        public void LengthOfLongestSubstringTheory(string input, int expected)
        {
            var result = _lengthOfLongestSubstring.LengthOfLongestSubstring(input);

            result.Should().Be(expected);
        }
    }
}
