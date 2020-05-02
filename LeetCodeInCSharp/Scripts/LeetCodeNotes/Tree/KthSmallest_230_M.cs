using System.Collections.Generic;

using System;
using System.Text;

namespace Study.LeetCode
{
    public partial class Solution
    {
        //230. 二叉搜索树中第K小的元素
        //给定一个二叉搜索树，编写一个函数 kthSmallest 来查找其中第 k 个最小的元素。

        //说明：
        //你可以假设 k 总是有效的，1 ≤ k ≤ 二叉搜索树元素个数。

        //示例 1:
        //输入: root = [3,1,4,null,2], k = 1
        //   3
        //  / \
        // 1   4
        //  \
        //   2
        //输出: 1

        //示例 2:
        //输入: root = [5,3,6,2,4,null,null,1], k = 3
        //       5
        //      / \
        //     3   6
        //    / \
        //   2   4
        //  /
        // 1
        //输出: 3
        //进阶：
        //如果二叉搜索树经常被修改（插入/删除操作）并且你需要频繁地查找第 k 小的值，
        //你将如何优化 kthSmallest 函数？

        public int KthSmallest(TreeNode root, int k)
        {
            List<int> temp = new List<int>();
            InorderKthSmallest(root, temp);
            return temp[k-1];
        }

        private void InorderKthSmallest(TreeNode root, List<int> tempList)
        {
            if(root == null)
            {
                return;
            }
            InorderKthSmallest(root.left, tempList);
            tempList.Add(root.val);
            InorderKthSmallest(root.right, tempList);
        }
        public int FindCurSmallNum(TreeNode root,int k,ref int KthSmallestValue)
        {
            int curthSmallest = 0;
            if (root.left == null)
            {
                curthSmallest = 1;
            }
            else
            {
                curthSmallest = FindCurSmallNum(root.left,k,ref KthSmallestValue) + 1;
            }

            if(curthSmallest == k)
            {
                KthSmallestValue = root.val;
            }
            return curthSmallest;
        }

        public int kthSmallest(TreeNode root, int k)
        {
            List<TreeNode> list = new List<TreeNode>();

            while (true)
            {
                while (root != null)
                {
                    list.Add(root);
                    root = root.left;
                }
                root = list[list.Count - 1];

                list.RemoveAt(list.Count - 1);
                if (--k == 0)
                {
                    return root.val;
                }
                root = root.right;
            }
        }

        public int kthSmallest2(TreeNode root, int k)
        {
            List<int> nums = inorder(root, new List<int>());
            return nums[k - 1];
        }
        public List<int> inorder(TreeNode root, List<int> arr)
        {
            if (root == null)
                return arr;
            inorder(root.left, arr);
            arr.Add(root.val);
            inorder(root.right, arr);
            return arr;
        }
    }
}




