using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Policy;
using static UlearnTasks.Program;

namespace UlearnTasks
{

    internal class Program
    {
        static void Main(string[] args)
        {

        }

    }

    class TaskSl
    {
        /// <summary>
        /// From list of "name"->"email" strings generate dict by first 2 letter as a key and match strign as a value
        /// </summary>
        /// <param name="contacts"></param>
        /// <example>
        ///        "В: v@mail.ru",
        ///        "Саша:a@lex.ru",
        ///        "Ваня:ivan@grozniy.ru",
        ///        "Ваня:vanechka@domain.com",
        ///        "Паша:pavel@mail.list"
        /// </example>
        /// <returns>Dict key:Na(name) -> value {strings[name:email,...]}</returns>
        public static Dictionary<string, List<string>> OptimizeContacts(List<string> contacts)
        {
            var dictionary = new Dictionary<string, List<string>>();

            foreach (var _contact in contacts)
            {
                string _key = _contact.Split(':')[0];
                _key = _key.Length <= 1 ? _key.Substring(0) : _key.Substring(0, 2);
                if (!dictionary.ContainsKey(_key))
                    dictionary[_key] = new List<string>();
                dictionary[_key].Add(_contact);
            }
            return dictionary;
        }

        /// <summary>
        /// Select words from input lines that started with upper char and reverse 'em
        /// </summary>
        /// <param name="lines"></param>
        /// <example>lines[] = {"решИла нЕ Упрощать и зашифРОВАтЬ Все послаНИЕ",
        ///                        "дАже не Старайся нИЧЕГО у тЕбя нЕ получится с расшифРОВкой",
        ///                        "Сдавайся НЕ твоего ума Ты не споСОбЕн Но может быть",
        ///                        "если особенно упорно подойдешь к делу",
        ///                        "",
        ///                        "будет Трудно конечнО",
        ///                        "Код ведЬ не из простых",
        ///                        "очень ХОРОШИЙ код",
        ///                        "то у тебя все получится",
        ///                        "и я буДу Писать тЕбЕ еще",
        ///                        "",
        ///                        "чао",}</example>
        /// <returns>Decoded message</returns>
        public static string DecodeMessage(string[] lines)
        {
            List<string> _words = new List<string>();

            foreach (var _line in lines)
            {
                if (!string.IsNullOrEmpty(_line))
                    foreach (var _word in _line.Split(' '))
                        if (char.IsUpper(_word[0]))
                            _words.Add(_word);
            }

            _words.Reverse();

            return string.Join(" ", _words.ToArray());
        }

        public static void ShiftArrayLeftOn(ref int[] array, int offset)
        {
            for (int i = 0; i < offset; i++)
            {
                var temp = array[0];
                for (int j = 0; j < array.Length - 1; j++)
                    array[j] = array[j + 1];
                array[array.Length-1] = temp;
            }
        }

        public static bool IsLeapYear(int year)
        {
            return (year % 400 == 0) || (year % 100 != 0) && (year % 4 == 0);
        }

        public static int[] GetPoweredArray(int[] arr, int power)
        {
            var resArray = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
                resArray[i] = (int)Math.Pow(arr[i], power);
            return resArray;
        }

        public static int FindSubarrayStartIndex(int[] array, int[] subArray)
        {
            for (var i = 0; i < array.Length - subArray.Length + 1; i++)
                if (ContainsAtIndex(array, subArray, i))
                    return i;
            return -1;
        }
        
        public static bool ContainsAtIndex(int[] array, int[] subArray, int indexArr)
        {
            for (int i = 0; i < subArray.Length; i++)
                if (subArray[i] != array[indexArr + i])
                    return false;
            return true;
        }

        public static int GetElementCount(int[] items, int itemToCount)
        {
            /*
            via Generic Linq
            return items.Count(x => x == itemToCount);
            */
            var count = 0;
            foreach(var e in items)
                if (itemToCount == e)
                    count++;
            return count;
        }

        public static int MaxIndex(double[] array)
        {
            if (array.Length == 0) return -1;
            var maxVal = array[0];
            var maxIndex = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > maxVal)
                {
                    maxVal = array[i];
                    maxIndex = i;
                }
            }
            return maxIndex;
        }
        
        public static int[] GetFirstEvenNumbers(int count)
        {
            int[] array = new int[count];
            for (int i = 0; i < count; i++)
                array[i] = (i + 1) * 2;
            return array;
        }

        public static int[] GetFirstMaxRepeatSequence(int[] arr)
        {
            int count = 0;
            int maxSequence = 0;
            int endIndx = 0;
            if (arr.Length != 0)
                maxSequence++;count++;
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] == arr[i - 1])
                {
                    count++;
                }
                else
                {
                    if (count > maxSequence)
                    {
                        maxSequence = count;
                        endIndx = i - 1;
                    }
                    count = 1;
                }
            }

            int[] result = new int[maxSequence];
            for (int i = endIndx - maxSequence +1, k = 0; i <= endIndx; i++, k++)
            {
                result[k] = arr[i];
            }

            return result;
        }

        public static int GetMaxRepeatNum(int[] arr)
        {
            int count = 0;
            int maxSequence = 0;
            if (arr.Length != 0)
                maxSequence++;count++;
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] == arr[i - 1])
                    count++;
                else
                {
                    if (count > maxSequence)
                    {
                        maxSequence = count;

                        Console.WriteLine(arr[i]+" "+i);
                    }
                        count = 1;
                }
            }
            return maxSequence;
        }

        public static void PrintArray<T>(T[] arr)
        {
            foreach (T i in arr) Console.Write($"{i} ");
        }
        /*
        public static void PrintArray(double[] arr)
        {
            foreach (double i in arr) Console.Write($"{i} ");
        }
        */

        public static int[] GenerateArray(int length, int minVal, int maxVal) 
        { 
            Random rnd = new Random();
            int[] ints = new int[length];

            for (int i = 0; i < length; i++) 
            {
                ints[i] = rnd.Next(minVal, maxVal + 1);
            }
            return ints;
        }
        public static double[] GenerateArray(int length, double minVal, double maxVal)
        {
            Random rnd = new Random();
            double[] arr = new double[length];

            for (int i = 0; i < length; i++)
            {
                arr[i] = rnd.NextDouble() * (maxVal - minVal) + minVal;
            }
            return arr;
        }
    }

    class TicTacToe
    {
        public enum Mark
        {
            Empty,
            Cross,
            Circle
        }

        public enum GameResult
        {
            CrossWin,
            CircleWin,
            Draw
        }

        public static void PlayExample()
        {
            Run("XXX OO. ...");
            Run("OXO XO. .XO");
            Run("OXO XOX OX.");
            Run("XOX OXO OXO");
            Run("... ... ...");
            Run("XXX OOO ...");
            Run("XOO XOO XX.");
            Run(".O. XO. XOX");
        }

        private static void Run(string description)
        {
            Console.WriteLine(description.Replace(" ", Environment.NewLine));
            Console.WriteLine(GetGameResult(CreateFromString(description)));
            Console.WriteLine();
        }

        private static Mark[,] CreateFromString(string str)
        {
            var field = str.Split(' ');
            var ans = new Mark[3, 3];
            for (int x = 0; x < field.Length; x++)
                for (var y = 0; y < field.Length; y++)
                    ans[x, y] = field[x][y] == 'X' ? Mark.Cross : (field[x][y] == 'O' ? Mark.Circle : Mark.Empty);
            return ans;
        }

        public static GameResult GetGameResult(Mark[,] field)
        {
            bool x = HasWinSequence(field, Mark.Cross);
            bool o = HasWinSequence(field, Mark.Circle);
            if (x && !o)
                return GameResult.CrossWin;
            else if (!x && o)
                return GameResult.CircleWin;
            return GameResult.Draw;
        }

        public static bool HasWinSequence(Mark[,] field, Mark mark)
        {
            var fieldLength0 = field.GetLength(0);
            for (int i = 0; i < fieldLength0; i++)
            {
                if (IsWinRow(field, mark, 0, i, 1, 0)) return true;
                if (IsWinRow(field, mark, i, 0, 0, 1)) return true;
            }
            return (IsWinRow(field, mark, 0, field.GetLength(0) - 1, 1, -1)) || (IsWinRow(field, mark, 0, 0, 1, 1));
        }

        public static bool IsWinRow(Mark[,] field, Mark mark, int x0, int y0, int dx, int dy)
        {
            var fieldLength0 = field.GetLength(0);
            var fieldLength1 = field.GetLength(1);
            for (; x0 < fieldLength0 && y0 < fieldLength1; x0 += dx, y0 += dy)
                if (field[x0, y0] == mark)
                    continue;
                else
                    return false;
            return true;
        }
    }
}
