using System.Collections.Generic;

using System;
using System.Text;

namespace Study.LeetCode
{
    public partial class Solution
    {
        public int CountNodes(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            var leftChild = CountNodes(root.left);
            var rightChild = CountNodes(root.right);
            return leftChild + rightChild + 1;
        }
    }
}




