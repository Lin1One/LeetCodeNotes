using System.Collections.Generic;

using System;

namespace Study.LeetCode
{
    public partial class Solution
    {
        //206. 反转链表
        // 反转一个单链表。

        // 示例:

        // 输入: 1->2->3->4->5->NULL
        // 输出: 5->4->3->2->1->NULL
        // 进阶:
        // 你可以迭代或递归地反转链表。你能否用两种方法解决这道题？
        /**
        * Definition for singly-linked list.
        * public class ListNode 
            {
        *     public int val;
        *     public ListNode next;
        *     public ListNode(int x) { val = x; }
        * }
        */


        public ListNode ReverseList0507(ListNode head)
        {
            //循环
            //双指针分别为 上一个节点（初始为 null），当前节点（初始为头节点）
            //1.循环中临时保存当前节点的下一节点 temp。
            //2.当前节点的下一节点指向上一个节点 prev。
            //3.上一节点往前至当前节点 curNode ，，当前节点往前至临时保存的下一节 temp，下一轮循环
            //4.当前节点为空，返回上一节点 prev。
            ListNode prev = null;
            ListNode curNode = head;
            while(curNode != null)
            {
                var curNext = curNode.next;
                curNode.next = prev;
                prev = curNode;
                curNode = curNext;
            }
            return prev;
        }

        public ListNode ReverseList_Test(ListNode head)
        {
            if(head == null)
            {
                return null;
            }
            var newHead = head;
            while(head.next != null)
            {
                var next = head.next;
                head.next = head.next.next;
                next.next = newHead;
                newHead = next;
            }
            return newHead;
        }

        //递归
        public ListNode ReverseList1(ListNode head) 
        {
            if(head == null)
            {
                return null;
            }
            ListNode newHead;
            ReverseList1(head,out newHead).next = null;
            return newHead;
        }
        private ListNode ReverseList1(ListNode head, out ListNode newHead)
        {
            if(head.next != null)
            {
                var newNode = ReverseList1(head.next,out newHead);
                newNode.next = head;
            }
            else
            {
                newHead = head;
            }
            return head;
        }

        public ListNode ReverseList1_2(ListNode head)
        {
            if(head == null || head.next == null)
            {
                return head;
            }
            var newHead = ReverseList1_2(head.next);
            head.next.next = head;
            head.next = null;
            return newHead;
        }

        //循环
        public ListNode ReverseList2(ListNode head) 
        {
            ListNode newHead = head;
            if(head == null)
            {
                return null;
            }
            while(head.next != null)
            {
                var oriNext = head.next;
                head.next = oriNext.next;
                oriNext.next = newHead;
                newHead = oriNext;
            }
            return newHead;
        }

        //循环2
        public ListNode ReverseList3(ListNode head)
        {
            ListNode prev = null;
            ListNode curNode = head;
            while(curNode != null)
            {
                var curNext = curNode.next;
                curNode.next = prev;
                prev = curNode;
                curNode = curNext;
            }
            return prev;
        }
    }
}


