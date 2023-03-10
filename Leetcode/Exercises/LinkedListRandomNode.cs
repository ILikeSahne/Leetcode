using FluentAssertions;
using Leetcode.HelperClasses;

namespace Leetcode.Exercises
{
    public class LinkedListRandomNodeSolution
    {
        private readonly ListNode? _head;

        private readonly int _len;
        private readonly Random _rand;

        public LinkedListRandomNodeSolution(ListNode? head)
        {
            _head = head;

            var node = head;
            _len = 0;
            while (node != null)
            {
                _len++;
                node = node.next;
            }

            _rand = new Random();
        }

        public int GetRandom()
        {
            var rand = _rand.Next(_len);
            var node = _head;

            for (var i = 0; i < rand; i++)
            {
                node = node?.next;
            }

            return node?.val;
        }
    }

    public class LinkedListRandomNodeTests
    {
        public LinkedListRandomNodeTests()
        {}

        [Fact]
        public void LinkedListRandomNodeTest()
        {
            var head = ListNodeHelper.CreateListNodeNumber(1, 2, 3);
            var solution = new LinkedListRandomNodeSolution(head);

            var numbers = new Dictionary<int, int>();
            for (var i = 0; i < 10_000; i++)
            {
                var random = solution.GetRandom();
                if (!numbers.ContainsKey(random))
                {
                    numbers[random] = 1;
                }
                else
                {
                    numbers[random]++;
                }
            }

            var percentage = 1d / numbers.Count;
            var tolerance = 0.9;

            var total = 0;
            foreach (var val in numbers.Values)
            {
                total += val;
            }

            foreach (var val in numbers.Values)
            {
                var per = (double) val / total;
                per.Should().BeInRange(percentage * tolerance, percentage * (2 - tolerance));
            }
        }
    }
}
