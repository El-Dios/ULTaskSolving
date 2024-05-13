using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduProject
{
    public class InterviewTasks
    {
        /// <summary>
        /// Windowing method search of the longest substring 
        /// O(n) time complexity
        /// </summary>
        /// <param name="s"></param>
        /// <example>
        ///     string sequence = "abcbada"
        ///     //answer is 4 (cbad)
        /// </example>
        /// <returns></returns>
        public static int LongestSubstring(string s)
        {
            int answer = 0, left = 0, right = 0;
            HashSet<char> set = new HashSet<char>();

            while (right < s.Length)
            {
                char c = s[right];
                if (!set.Contains(c))
                {
                    set.Add(c);
                    answer = Math.Max(answer, right - left + 1);
                    right++;
                }
                else
                {
                    while (set.Contains(c))
                    {
                        set.Remove(s[left]);
                        left++;
                    }
                }
            }

            return answer;
        }

        /// <summary>
        /// You as a robber want to grab max cash from houses.
        /// But you are not allowed to robber houses nearby.
        /// </summary>
        /// <param name="houses"></param>
        /// <example>
        /// houses = [4, 11, 10, 1, 2, 8, 5]
        /// result = 22
        /// </example>
        /// <returns>Max available cash according to the condition</returns>
        public static int HouseRobber(int[] houses)
        {
            if (houses.Length == 0) { return 0; }
            if (houses.Length == 1) { return houses[0]; }

            int[] dp = new int[houses.Length];
            dp[0] = houses[0];
            dp[1] = Math.Max(houses[0], houses[1]);

            for (int i = 2;  i < houses.Length; i++)
            {
                dp[i] = Math.Max(houses[i] + dp[i-2], dp[i - 1]);
            }

            return dp[houses.Length - 1];
        }
    }
}
