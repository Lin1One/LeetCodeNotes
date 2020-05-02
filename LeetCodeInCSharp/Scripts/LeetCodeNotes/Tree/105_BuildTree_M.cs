﻿using System.Collections.Generic;

using System;
using System.Text;

namespace Study.LeetCode
{
    public partial class Solution
    {
        // 105. 从前序与中序遍历序列构造二叉树
        // 根据一棵树的前序遍历与中序遍历构造二叉树。
        
        // 注意:
        // 你可以假设树中没有重复的元素。

        // 例如，给出
        // 前序遍历 preorder = [3,9,20,15,7]
        // 中序遍历 inorder = [9,3,15,20,7]
        // 返回如下的二叉树：

        //     3
        //    / \
        //   9  20
        //     /  \
        //    15   7

        // [3,9,20,15,7]
        // [9,3,15,20,7]
        // 输出
        // [3,9,9]
        // 预期结果
        // [3,9,20,null,null,15,7]
        public TreeNode BuildTree1(int[] preorder, int[] inorder) 
        {
            if(preorder.Length== 0)
            {
                return null;
            }
            TreeNode rootNode = new TreeNode(preorder[0]);
            int rootValIndex = Array.FindIndex(inorder,v=> v== preorder[0]);
            int leftCount = rootValIndex;
            int rightCount = inorder.Length - 1 - rootValIndex;


            int[] leftValues = new int[leftCount];
            int[] rightValues = new int[rightCount];
            Array.Copy(inorder,leftValues,leftCount);
            Array.Copy(inorder,leftCount + 1,rightValues,0,rightCount);

            int[] leftValuesPreorder = new int[leftCount];
            int[] rightValuesInorder = new int[rightCount];
            Array.Copy(preorder,1,leftValuesPreorder,0,leftCount);
            Array.Copy(preorder,leftCount + 1,rightValuesInorder,0,rightCount);

            rootNode.left = BuildTree1(leftValuesPreorder,leftValues);
            rootNode.right = BuildTree1(rightValuesInorder,rightValues);
            return rootNode;
        }

        public TreeNode BuildTree2(int[] preorder, int[] inorder) 
        {
             if(preorder.Length== 0)
            {
                return null;
            }
            TreeNode rootNode = BuildTree2(preorder,inorder,0,0,inorder.Length);
            return rootNode;
        }

        public TreeNode BuildTree2(
            int[] preorder, 
            int[] inorder,
            int rootIndex,
            int leftIndex,
            int rightIndex) 
        {

            if(leftIndex == rightIndex)
            {
                return null;
            }

            int rootVal = preorder[rootIndex];
            TreeNode rootNode = new TreeNode(rootVal);
            int rootValIndexInorder = Array.FindIndex(inorder,v=> v== rootVal);
            rootNode.left = BuildTree2(preorder,inorder,rootValIndexInorder +1,leftIndex,rootValIndexInorder);
            rootNode.right = BuildTree2(preorder,inorder,rootValIndexInorder + 1,rootValIndexInorder + 1,rightIndex);
            return rootNode;
        }

        int pre_idx = 0;
        int[] preorder;
        int[] buildTreeInorder;
        Dictionary<int, int> idx_map = new Dictionary<int, int>();


        public TreeNode BuildTree3(int[] preorder, int[] inorder) 
        {
            this.preorder = preorder;
            this.buildTreeInorder = inorder;
            for (var i = 0;i < inorder.Length;i++)
            {
                idx_map.Add(inorder[i], i);
            }
            return helper(0, inorder.Length);
        }

        public TreeNode helper(int in_left, int in_right) 
        {
            if (in_left == in_right)
            {
                return null;
            }

            int root_val = preorder[pre_idx];
            TreeNode root = new TreeNode(root_val);

            // root splits inorder list
            // into left and right subtrees
            int index = idx_map[root_val];
            pre_idx++;
            root.left = helper(in_left, index);
            root.right = helper(index + 1, in_right);
            return root;
        }

        public TreeNode BuildTree0403(int[] preorder, int[] inorder)
        {
            return BuildTree0403(preorder, inorder, 0, 0, preorder.Length);
        }

        public TreeNode BuildTree0403(int[] preorder, int[] inorder, int curNodeIndex, int left, int right)
        {
            if (left == right)
            {
                return null;
            }
            int curNodeInOrderIndex = 0;
            for (var i = left; i < right; i++)
            {
                if (inorder[i] == preorder[curNodeIndex])
                {
                    curNodeInOrderIndex = i;
                }
            }
            int leftNodeCount = curNodeInOrderIndex - left;
            int rightNodeCount = right - curNodeInOrderIndex - 1;
            TreeNode curNode = new TreeNode(preorder[curNodeIndex]);
            curNode.left = BuildTree0403(preorder, inorder, curNodeIndex + 1, left, curNodeInOrderIndex);
            curNode.right = BuildTree0403(preorder, inorder, curNodeIndex + leftNodeCount + 1, curNodeInOrderIndex + 1, right);
            return curNode;

        }

    }
}




