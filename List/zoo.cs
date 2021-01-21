using System;
using System.Collections;
using System.Collections.Generic;

namespace List
{
    public class zoo
    {
        public bool IsValid(string s)  //leecode:有效的括号
        {
            Stack stack = new Stack();
            Char[] chars = s.ToCharArray();
            for(int i = 0; i < chars.Length; i++)
            {
                char c = chars[i];
                if(c == '(' || c == '[' || c == '{')
                {
                    stack.Push(c);
                }
                else
                {
                    if (stack.Count == 0) //判空
                        return false;

                    char top = (char)stack.Pop();
                    if (c == ')' && top != '(')
                        return false;
                    if (c == ']' && top != '[')
                        return false;
                    if (c == '}' && top != '{')
                        return false;
                }
            }

            return stack.Count == 0;
        }

        public bool Isvalid2(string s)
        {
            Dictionary<char, char> map = new Dictionary<char, char>
            {
                { ']', '[' },
                { ')', '(' },
                { '}', '{' }
            };
            var stack = new Stack();

            foreach (var item in s)
            {
                if (map.ContainsKey(item))
                {
                    //ex:"]}"
                    if (stack.Count == 0)
                    {
                        return false;
                    }
                    else
                    {
                        var element = (char)stack.Pop();
                        if (element != map[item])
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    stack.Push(item);
                }
            }


            //ex:"[[["
            return stack.Count == 0;

        }


    }
}
