using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public static class AssertExtensions
    {
        public static bool EqualsToOne<T>(this IEnumerable<T> actual, params IEnumerable<T>[] expectedArrays)
        {
            var actualList = actual.ToList();
            
            foreach (var expected in expectedArrays)
            {
                var expectedList = expected.ToList();
                
                if(actualList.Count != expectedList.Count)
                    continue;

                for (var i = 0; i < actualList.Count; i++)
                {
                    if (!actualList[i]!.Equals(expectedList[i]))
                        continue;
                }

                return true;
            }

            return false;
        }
    }
}
