using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.LeetCode
{
    public partial class Solution
    {
        public int FirstMissingPositive(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 1;
            }
            var i = 0;
            while (i < nums.Length)
            {
                var curValue = nums[i];
                if (curValue <= 0 || curValue > nums.Length || nums[i] == nums[curValue - 1])
                {
                    i++;
                    continue;
                }
                var temp = nums[curValue - 1];
                nums[curValue - 1] = nums[i];
                nums[i] = temp;
            }
            for (var j = 0; j < nums.Length; j++)
            {
                if (nums[j] != j + 1)
                {
                    return j + 1;
                }
            }
            return nums.Length + 1;
        }
    }
}
