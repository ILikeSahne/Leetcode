using FluentAssertions;
using Leetcode.HelperClasses;

namespace Leetcode.Exercises
{
    public class LinkedListCycle2Solution
    {
        public ListNode? DetectCycle(ListNode? head)
        {
            var node = head;

            var visitedNodes = new HashSet<ListNode>();
            while (node != null)
            {
                if (visitedNodes.Contains(node))
                {
                    return node;
                }

                visitedNodes.Add(node);

                node = node.next;
            }

            return null;
        }
    }

    public class LinkedListCycle2Tests
    {
        private readonly LinkedListCycle2Solution _linkedListCycle2;

        public LinkedListCycle2Tests()
        {
            _linkedListCycle2 = new LinkedListCycle2Solution();
        }

        [Fact]
        public void LinkedListCycle2ShouldReturnNode2()
        {
            var loop = ListNodeHelper.CreateListNodeNumber(3, 2, 0, -4);
            loop.next.next.next = loop.next; // Connect -4 to 2

            var result = _linkedListCycle2.DetectCycle(loop);
            result.Should().Be(loop.next);
        }

        [Fact]
        public void LinkedListCycle2ShouldReturnNode1()
        {
            var loop = ListNodeHelper.CreateListNodeNumber(1, 2);
            loop.next = loop; // Connect 2 to 1

            var result = _linkedListCycle2.DetectCycle(loop);
            result.Should().Be(loop);
        }

        [Fact]
        public void LinkedListCycle2ShouldReturnNull()
        {
            var loop = ListNodeHelper.CreateListNodeNumber(1);

            var result = _linkedListCycle2.DetectCycle(loop);
            result.Should().BeNull();
        }
    }
}
