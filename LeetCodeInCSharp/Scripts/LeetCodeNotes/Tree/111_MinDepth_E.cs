#region Head

// Author:            LinYuzhou
// Email:             836045613@qq.com

#endregion
using System.Collections.Generic;
using System;

namespace Study.LeetCode
{
    public partial class Solution
    {
        //111. 二叉树的最小深度
        //给定一个二叉树，找出其最小深度。

        //最小深度是从根节点到最近叶子节点的最短路径上的节点数量。

        //说明: 叶子节点是指没有子节点的节点。

        //示例:

        //给定二叉树[3, 9, 20, null, null, 15, 7],

        //    3
        //   / \
        //  9  20
        //    /  \
        //   15   7
        //返回它的最小深度  2.
        public int MinDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            var min = GetMinDepth(root);
            return min;
        }

        public int GetMinDepth(TreeNode node)
        {

            if (node == null)
            {
                return int.MaxValue;
            }
            if (node.left == null && node.right == null)
            {
                return 1;
            }
            int lelfChild = GetMinDepth(node.left);
            int rightChild = GetMinDepth(node.right);
            var min = Math.Min(lelfChild, rightChild) + 1;
            return min;
        }
    }

}

