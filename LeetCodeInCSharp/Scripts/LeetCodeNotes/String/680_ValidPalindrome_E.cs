using System.Collections.Generic;

using System;
using System.Text;

namespace Study.LeetCode
{
    public partial class Solution
    {
        //680. 验证回文字符串 Ⅱ
        //给定一个非空字符串 s，最多删除一个字符。判断是否能成为回文字符串。

        //示例 1:

        //输入: "aba"
        //输出: True
        //示例 2:

        //输入: "abca"
        //输出: True
        //解释: 你可以删除c字符。
        //注意:

        //字符串只包含从 a-z 的小写字母。字符串的最大长度是50000。
        public bool ValidPalindrome(string s)
        {
            var start = 0;
            var end = s.Length - 1;
            while (start < end)
            {
                if (s[start] == s[end])
                {
                    start++;
                    end--;
                }
                else
                {
                    bool flag1 = true, flag2 = true;
                    for (int i = start, j = end - 1; i < j; i++, j--)
                    {
                        char c3 = s[i], c4 = s[j];
                        if (c3 != c4)
                        {
                            flag1 = false;
                            break;
                        }
                    }
                    for (int i = start + 1, j = end; i < j; i++, j--)
                    {
                        char c3 = s[i], c4 = s[j];
                        if (c3 != c4)
                        {
                            flag2 = false;
                            break;
                        }
                    }
                    return flag1 || flag2;
                }

            }
            return true;
        }

    }
}


