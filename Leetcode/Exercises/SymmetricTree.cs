using FluentAssertions;
using Leetcode.HelperClasses;

namespace Leetcode.Exercises
{
    public class SymmetricTreeSolution
    {
        public bool IsSymmetric(TreeNode root)
        {
            var visit = new Queue<(TreeNode left, TreeNode right)>();
            visit.Enqueue((root.left, root.right));

            while (visit.Any())
            {
                var check = visit.Dequeue();
                var n1 = check.left;
                var n2 = check.right;

                if ((n1 == null) != (n2 == null))
                    return false;
                
                if(n1 == null)
                    continue;

                if (n1.val != n2.val)
                    return false;

                visit.Enqueue((n1.left, n2.right));
                visit.Enqueue((n1.right, n2.left));
            }

            return true;
        }

        public bool IsSymmetric_revursive(TreeNode root)
        {
            return CheckSymmetry_revursive(root.left, root.right);
        }

        private bool CheckSymmetry_revursive(TreeNode? n1, TreeNode? n2)
        {
            if ((n1 == null) != (n2 == null))
                return false;

            if (n1 == null)
                return true;
            
            if (n1.val != n2.val)
                return false;

            var b = CheckSymmetry_revursive(n1.left, n2.right);
            b &= CheckSymmetry_revursive(n1.right, n2.left);

            return b;
        }
    }

    public class SymmetricTreeTests
    {
        private readonly SymmetricTreeSolution _symmetricTree;

        public SymmetricTreeTests()
        {
            _symmetricTree = new SymmetricTreeSolution();
        }

        [Fact]
        public void SymmetricTreeShouldReturnTrue()
        {
            var tree = new TreeNode(1)
            {
                left = new TreeNode(2)
                {
                    left = new TreeNode(3),
                    right = new TreeNode(4)
                },
                right = new TreeNode(2)
                {
                    left = new TreeNode(4),
                    right = new TreeNode(3)
                },
            };

            var result = _symmetricTree.IsSymmetric(tree);

            result.Should().BeTrue();
        }


        [Fact]
        public void SymmetricTreeShouldReturnFalse()
        {
            var tree = new TreeNode(1)
            {
                left = new TreeNode(2)
                {
                    right = new TreeNode(3)
                },
                right = new TreeNode(2)
                {
                    right = new TreeNode(3)
                },
            };

            var result = _symmetricTree.IsSymmetric(tree);

            result.Should().BeFalse();
        }
    }
}
