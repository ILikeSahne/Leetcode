using Leetcode.Exercises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace Leetcode.HelperClasses
{
    // ListNode Class from Leetcode
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

    public class ListNodeHelper
    {
        public static ListNode CreateListNodeNumber(params int[] numbers)
        {
            if (numbers.Length == 0)
                return new ListNode();

            var start = new ListNode(numbers[0]);
            var current = start;

            for (var i = 1; i < numbers.Length; i++)
            {
                current.next = new ListNode(numbers[i]);
                current = current.next;
            }

            return start;
        }

        public static void ListNodeShouldBe(ListNode node, params int[] numbers)
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
}
