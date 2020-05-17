using System;
using System.Collections;
using System.Collections.Generic;


namespace Study.LeetCode
{
    public partial class Solution
    {
        //面试题40.最小的k个数
        //输入整数数组 arr ，找出其中最小的 k 个数。例如，输入4、5、1、6、2、7、3、8这8个数字，
        //则最小的4个数字是1、2、3、4。

        //示例 1：
        //输入：arr = [3,2,1], k = 2
        //输出：[1,2]
        //或者[2, 1]

        //示例 2：
        //输入：arr = [0,1,2,1], k = 1
        //输出：[0]

        public int[] GetLeastNumbers(int[] arr, int k)
        {
            if (k == arr.Length)
            {
                return arr;
            }
            helper(arr, 0, arr.Length - 1, k);
            var res = new int[k];
            for(var i = 0;i< k;i++)
            {
                res[i] = arr[i];
            }
            return res;
        }

        private void helper(int[] arr, int left,int right, int k)
        {
            var curPivotIndex = QuickSort(arr, left, right);
            if (curPivotIndex == k)
            {
                return;
            }
            else if(curPivotIndex < k)
            {
                helper(arr, curPivotIndex + 1, right,k);
            }
            else
            {
                helper(arr, left, curPivotIndex - 1,k);
            }
        }

        private int QuickSort(int[] arr, int left, int right)
        {
            var pivot = arr[left];
            var l = left;
            var r = right;
            while(l < r)
            {
                while(l < r && arr[r] >= pivot)
                {
                    r--;
                }
                arr[l] = arr[r];
                while(l < r && arr[l] <= pivot)
                {
                    l++;
                }
                arr[r] = arr[l];
            }
            arr[l] = pivot;
            return l;
        }
    }
}