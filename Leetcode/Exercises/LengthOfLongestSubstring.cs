using FluentAssertions;

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
            var first = CreateListNodeNumber(2, 4, 3);
            var second = CreateListNodeNumber(5, 6, 4);

            var result = _twoSum.AddTwoNumbers(first, second);

            ListNodeShouldBe(result, 7, 0, 8);
        }

        [Fact]
        public void AddTwoNumbersShouldReturn89990001()
        {
            var first = CreateListNodeNumber(9, 9, 9, 9, 9, 9, 9);
            var second = CreateListNodeNumber(9, 9, 9, 9);

            var result = _twoSum.AddTwoNumbers(first, second);

            ListNodeShouldBe(result, 8, 9, 9, 9, 0, 0, 0, 1);
        }

        private ListNode CreateListNodeNumber(params int[] numbers)
        {
            if(numbers.Length == 0)
                return new ListNode();

            var start = new ListNode(numbers[0]);
            var current = start;

            for(var i = 1; i < numbers.Length; i++)
            {
                current.next = new ListNode(numbers[i]);
                current = current.next;
            }

            return start;
        }

        private void ListNodeShouldBe(ListNode node, params int[] numbers)
        {
            var current = node;
            foreach (var num in numbers)
            {
                current.Should().NotBeNull();

                current.val.Should().Be(num);

                current = current.next;
            }
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}
