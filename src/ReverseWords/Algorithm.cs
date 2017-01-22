using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseWords
{
    public class Algorithm
    {
        private const char WORD_SEPARATOR = ' ';

        /// <summary>
        /// Reverses each word in a given string.
        /// </summary>
        /// <param name="words">Input string</param>
        /// <returns>Output string</returns>
        /// <exception cref="ArgumentNullException">Thrown when input string is null.</exception>
        public string ReverseWords(string words)
        {
            if (words == null)
                throw new ArgumentNullException(nameof(words));

            var resultBuilder = new StringBuilder();
            var stack = new Stack<char>();

            foreach (var c in words)
            {
                if (c == WORD_SEPARATOR)
                {
                    while (stack.Count > 0)
                    {
                        resultBuilder.Append(stack.Pop());
                    }

                    resultBuilder.Append(c);
                }
                else
                {
                    stack.Push(c);
                }
            }

            while (stack.Count > 0)
            {
                resultBuilder.Append(stack.Pop());
            }

            return resultBuilder.ToString();
        }
    }
}
