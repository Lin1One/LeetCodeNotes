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
        //946. 验证栈序列
        //给定 pushed 和 popped 两个序列，每个序列中的 值都不重复，只有当它们可能是在最初空栈上进行的推入 push 和弹出 pop 操作序列的结果时，返回 true；否则，返回 false 。



        //示例 1：

        //输入：pushed = [1,2,3,4,5], popped = [4,5,3,2,1]
        //        输出：true
        //解释：我们可以按以下顺序执行：
        //push(1), push(2), push(3), push(4), pop() -> 4,
        //push(5), pop() -> 5, pop() -> 3, pop() -> 2, pop() -> 1
        //示例 2：

        //输入：pushed = [1,2,3,4,5], popped = [4,3,5,1,2]
        //        输出：false
        //解释：1 不能在 2 之前弹出。


        //提示：

        //0 <= pushed.length == popped.length <= 1000
        //0 <= pushed[i], popped[i] < 1000
        //pushed 是 popped 的排列。

        public bool ValidateStackSequences(int[] pushed, int[] popped)
        {
            //将 pushed 队列中的每个数都 push 到栈中，同时检查这个数是不是 popped 序列中下一个要 pop 的值，
            //如果是就把它 pop 出来。
            //最后，检查不是所有的该 pop 出来的值都是 pop 出来了。
            var helpStack = new Stack<int>();
            var popIndex = 0;
            for (var i = 0; i < pushed.Length; i++)
            {
                helpStack.Push(pushed[i]);
                while (popIndex < pushed.Length && helpStack.Count != 0 && helpStack.Peek() == popped[popIndex])
                {
                    popIndex++;
                    helpStack.Pop();
                }
            }
            return helpStack.Count == 0;
        }
    }
}

