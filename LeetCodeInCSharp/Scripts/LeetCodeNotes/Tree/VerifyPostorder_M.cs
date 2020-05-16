using System.Collections.Generic;

using System;
using System.Text;

namespace Study.LeetCode
{
    public partial class Solution
    {
        // 面试题33. 二叉搜索树的后序遍历序列
        // 输入一个整数数组，判断该数组是不是某二叉搜索树的后序遍历结果。
        // 如果是则返回 true，否则返回 false。假设输入的数组的任意两个数字都互不相同。
        // 参考以下这颗二叉搜索树：

        //      5
        //     / \
        //    2   6
        //   / \
        //  1   3
        // 示例 1：

        // 输入: [1,6,3,2,5]
        // 输出: false
        // 示例 2：

        // 输入: [1,3,2,6,5]
        // 输出: true
        

        // 提示：

        // 数组长度 <= 1000

    public bool verifyPostorder(int[] postorder) {
        return recur(postorder, 0, postorder.Length - 1);
    }
    bool recur(int[] postorder, int i, int j) {
        if(i >= j) return true;
        int p = i;
        while(postorder[p] < postorder[j]) 
        {
            p++;
        }
        int m = p;
        while(postorder[p] > postorder[j]) 
        {
            p++;
        }
        return p == j && recur(postorder, i, m - 1) && recur(postorder, m, j - 1);
    }

        public bool VerifyPostorder(int[] postorder)
        {
            // 后序遍历倒序： [ 根节点 | 右子树 | 左子树 ] 。
            // 类似 先序遍历的镜像 ，即先序遍历为 “根、左、右” 的顺序，
            // 而后序遍历的倒序为 “根、右、左” 顺序。

            Stack<int> stack = new Stack<int>();
            int curValue = int.MaxValue;
            for(var i = postorder.Length - 1;i>= 0;i--)
            {
                if(postorder[i] > curValue)
                {
                    return false;
                }
                while(stack.Count > 0 && stack.Peek() > postorder[i])
                {
                    curValue = stack.Pop();
                }
                stack.Push(postorder[i]);
            }
            return true;
            // 时间复杂度 O(N) ： 
            // 遍历 postorder 所有节点，各节点均入栈 / 出栈一次，使用 O(N) 时间。
            // 空间复杂度 O(N) ： 
            // 最差情况下，单调栈 stack 存储所有节点，使用 O(N) 额外空间。

        }
    }
}




