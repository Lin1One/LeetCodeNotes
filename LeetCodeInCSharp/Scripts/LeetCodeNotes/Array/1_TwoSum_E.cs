﻿using System.Collections.Generic;


namespace Study.LeetCode
{
    public partial class Solution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            int[] result = new int[2];
            Dictionary<int, int> symbol = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int t = target - nums[i];
                if (!symbol.ContainsKey(t))
                {
                    symbol.Add(t, i);
                }
            }
            for (int j = 0; j < nums.Length; j++)
            {
                if (symbol.ContainsKey(nums[j]) && symbol[nums[j]] != j)
                {
                    result[0] = j;
                    result[1] = symbol[nums[j]];
                    break;
                }
            }
            return result;
        }

        public int[] TwoSum0317(int[] nums, int target)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int discrepancy = target - nums[i];
                if (map.ContainsKey(discrepancy))
                {
                    return new int[] { map[discrepancy], i };
                }
                if (!map.ContainsKey(nums[i]))
                {
                    map.Add(nums[i], i);
                }
            }
            return null;

        }
    }
}


