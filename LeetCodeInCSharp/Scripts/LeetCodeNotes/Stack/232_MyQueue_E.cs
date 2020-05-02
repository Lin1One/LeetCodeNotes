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
        //232. 用栈实现队列
        //使用栈实现队列的下列操作：

        //push(x) -- 将一个元素放入队列的尾部。
        //pop() -- 从队列首部移除元素。
        //peek() -- 返回队列首部的元素。
        //empty() -- 返回队列是否为空。
        //示例:

        //MyQueue queue = new MyQueue();

        //queue.push(1);
        //queue.push(2);  
        //queue.peek();  // 返回 1
        //queue.pop();   // 返回 1
        //queue.empty(); // 返回 false
        //说明:

        //你只能使用标准的栈操作 -- 也就是只有 push to top, peek/pop from top, size, 和 is empty 操作是合法的。
        //你所使用的语言也许不支持栈。你可以使用 list 或者 deque（双端队列）来模拟一个栈，只要是标准的栈操作即可。
        //假设所有操作都是有效的 （例如，一个空的队列不会调用 pop 或者 peek 操作）。
        public class MyQueue
        {
            //入栈 O(1) 出栈 O(n)
            public Stack<int> inStack;
            public Stack<int> outStack;
            /** Initialize your data structure here. */
            public MyQueue()
            {
                inStack = new Stack<int>();
                outStack = new Stack<int>();
            }

            /** Push element x to the back of queue. */
            public void Push(int x)
            {
                inStack.Push(x);
            }

            /** Removes the element from in front of queue and returns that element. */
            public int Pop()
            {
                if (outStack.Count == 0)
                {
                    while (inStack.Count != 0)
                    {
                        outStack.Push(inStack.Pop());
                    }
                }
                return outStack.Pop();
            }

            /** Get the front element. */
            public int Peek()
            {
                if (outStack.Count == 0)
                {
                    while (inStack.Count != 0)
                    {
                        outStack.Push(inStack.Pop());
                    }
                }
                return outStack.Peek();
            }

            /** Returns whether the queue is empty. */
            public bool Empty()
            {
                return outStack.Count == 0 && inStack.Count == 0;
            }
        }

        public class MyQueue2
        {
            public Stack<int> curStack;
            public Stack<int> helpStack;
            /** Initialize your data structure here. */
            public MyQueue2()
            {
                curStack = new Stack<int>();
                helpStack = new Stack<int>();
            }

            /** Push element x to the back of queue. */
            public void Push(int x)
            {
                while(curStack.Count != 0)
                {
                    helpStack.Push(curStack.Pop());
                }
                helpStack.Push(x);
                while (helpStack.Count != 0)
                {
                    curStack.Push(helpStack.Pop());
                }
            }

            /** Removes the element from in front of queue and returns that element. */
            public int Pop()
            {
                return curStack.Pop();
            }

            /** Get the front element. */
            public int Peek()
            {
                return curStack.Peek();
            }

            /** Returns whether the queue is empty. */
            public bool Empty()
            {
                return curStack.Count == 0;
            }
        }

    }
}

