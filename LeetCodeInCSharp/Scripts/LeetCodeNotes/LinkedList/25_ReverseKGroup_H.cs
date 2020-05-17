﻿using System.Collections.Generic;

using System;
using System.Text;

namespace Study.LeetCode
{
    public partial class Solution
    {
        // 25. K 个一组翻转链表
        // 给你一个链表，每 k 个节点一组进行翻转，请你返回翻转后的链表。
        // k 是一个正整数，它的值小于或等于链表的长度。
        // 如果节点总数不是 k 的整数倍，那么请将最后剩余的节点保持原有顺序。

        // 示例：
        // 给你这个链表：1->2->3->4->5
        // 当 k = 2 时，应当返回: 2->1->4->3->5
        // 当 k = 3 时，应当返回: 3->2->1->4->5

        // 说明：
        // 你的算法只能使用常数的额外空间。
        // 你不能只是单纯的改变节点内部的值，而是需要实际进行节点交换。        
        public ListNode ReverseKGroup(ListNode head, int k)
        {
            var curNode = head;
            var nodeCount = k;
            while(curNode != null && nodeCount > 0)
            {
                curNode = curNode.next;
                nodeCount--;
            }
            if(curNode == null)
            {
                return head;
            }
            var nextNode = curNode.next;
            curNode.next = null;
            ListNode preNode = null;
            curNode = head;
            while(curNode != null)
            {
                var next = curNode.next;
                curNode.next = preNode;
                preNode = curNode;
                curNode = next;
            }
            head.next = ReverseKGroup(nextNode, k);
            return preNode;
        }
    }
}

