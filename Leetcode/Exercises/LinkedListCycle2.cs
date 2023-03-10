using FluentAssertions;
using Leetcode.HelperClasses;

namespace Leetcode.Exercises
{
    public class LinkedListCycle2Solution
    {
        // Constant Memory
        public ListNode? DetectCycle(ListNode? head)
        {
            var nodePointerSlow = head;
            var nodePointerFast = head;

            while (true)
            {
                nodePointerSlow = nodePointerSlow?.next;
                if (nodePointerSlow == null)
                    return null;

                nodePointerFast = nodePointerFast?.next?.next;
                if (nodePointerFast == null)
                    return null;

                if (nodePointerSlow == nodePointerFast)
                {
                    break;
                }
            }

            // Loop found, resetting slow pointer, moving forward at normal speed will cause the 2 pointers to meet at the start
            nodePointerSlow = head;
            while (true)
            {
                if (nodePointerSlow == nodePointerFast)
                    return nodePointerSlow;

                nodePointerSlow = nodePointerSlow?.next;
                nodePointerFast = nodePointerFast?.next;
            }
        }

        public ListNode? DetectCycle_HashSetApproach(ListNode? head)
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
            loop.next.next = loop; // Connect 2 to 1

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
