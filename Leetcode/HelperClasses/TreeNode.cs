using FluentAssertions;

namespace Leetcode.HelperClasses
{
    // TreeNode Class from Leetcode
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class TreeNodeHelper
    {
        public static void TreeNodeShouldBe(TreeNode? result, TreeNode? expected)
        {
            CheckChildren(result, expected).Should().BeTrue();
        }

        private static bool CheckChildren(TreeNode? result, TreeNode? expected)
        {
            if ((expected == null) != (result == null))
                return false;

            if (result == null)
                return true;

            if (expected.val != result.val)
                return false;

            var b = CheckChildren(expected.left, result.left);
            b &= CheckChildren(expected.right, result.right);

            return b;
        }
    }
}
