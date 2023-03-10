using FluentAssertions;
using Leetcode.HelperClasses;

namespace Leetcode.Exercises
{
    public class AddTwoNumbersSolution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var cur1 = l1;
            var cur2 = l2;
            
            var resultStart = new ListNode();
            var result = resultStart;

            var carry = 0;
            
            while (cur1 != null || cur2 != null)
            {
                var num = carry;

                if (cur1 != null)
                {
                    num += cur1.val;
                    cur1 = cur1.next;
                }

                if (cur2 != null)
                {
                    num += cur2.val;
                    cur2 = cur2.next;
                }

                result.next = new ListNode(num % 10);
                result = result.next;

                carry = num / 10;
            }

            if (carry > 0)
            {
                result.next = new ListNode(carry);
            }

            return resultStart.next;
        }
    }

    public class AddTwoNumbersTests
    {
        private readonly AddTwoNumbersSolution _twoSum;

        public AddTwoNumbersTests()
        {
            _twoSum = new AddTwoNumbersSolution();
        }

        [Fact]
        public void AddTwoNumbersShouldReturn807()
        {
            var first = ListNodeHelper.CreateListNodeNumber(2, 4, 3);
            var second = ListNodeHelper.CreateListNodeNumber(5, 6, 4);

            var result = _twoSum.AddTwoNumbers(first, second);

            ListNodeHelper.ListNodeShouldBe(result, 7, 0, 8);
        }

        [Fact]
        public void AddTwoNumbersShouldReturn89990001()
        {
            var first = ListNodeHelper.CreateListNodeNumber(9, 9, 9, 9, 9, 9, 9);
            var second = ListNodeHelper.CreateListNodeNumber(9, 9, 9, 9);

            var result = _twoSum.AddTwoNumbers(first, second);

            ListNodeHelper.ListNodeShouldBe(result, 8, 9, 9, 9, 0, 0, 0, 1);
        }
    }
}
