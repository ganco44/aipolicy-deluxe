using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AIPolicy
{
    static class Program
    {
        public enum JDTarget
        {
            AGGRO_MOST,
            AGGRO_LEAST,
            AGGRO_LEAST_RAND,
            MOST_HP,
            MOST_MP,
            LEAST_HP,
            TEAM,
            SELF
        };

        internal static string GetNumber(string s)
        {
            var num = -1;
            var flag = true;
            for (var i = 0; i < s.Length; i++)
            {
                if (char.IsNumber(s[i])) num = i;
                else
                {
                    if (s[i] != '.' || !flag) break;
                    num = i;
                    flag = false;
                }
            }
            return num >= 0 ? s.Substring(0, num + 1) : "";
        }

        internal static int GetOperArgBytes(int operID)
        {
            switch (operID)
            {
                case 0:
                case 1:
                case 3:
                case 9:
                case 10:
                case 11:
                case 19:
                case 20:
                case 21:
                case 23:
                    return 4;
                default:
                    return 0;
            }
        }

        internal static int GetOperPrime(int operID)
        {
            switch (operID)
            {

                case 5:
                    return 2;
                case 6:
                case 7:
                case 16:
                case 17:
                case 18:
                    return 1;
                default:
                    return 3;
            }
        }

        internal static int IDOper(string s)
        {
            switch (s)
            {
                case "a":
                    return 0;
                case "b":
                    return 1;
                case "c":
                    return 2;
                case "d":
                    return 3;
                case "e":
                    return 4;
                case "!":
                    return 5;
                case "f":
                    return 6;
                case "g":
                    return 7;
                case "h":
                    return 8;
                case "i":
                    return 9;
                case "j":
                    return 10;
                case "k":
                    return 11;
                case "l":
                    return 12;
                case "m":
                    return 13;
                case "n":
                    return 14;
                case "o":
                    return 15;
                case ">":
                    return 16;
                case "<":
                    return 17;
                case "=":
                    return 18;
                case "p":
                    return 19;
                case "q":
                    return 20;
                case "r":
                    return 21;
                case "s":
                    return 22;
                case "t":
                    return 23;
                default:
                    return -1;
            }
        }

        [return: MarshalAs(UnmanagedType.U1)]
        internal static bool IsMatch(string s)
        {
            var stack = new Stack();
            var flag = true;
            for (var i = 0; i < s.Length; i++)
            {
                var text = s.Substring(i, 1);
                if (text == "(") stack.Push(text);
                if (text != ")") continue;
                if (stack.Count == 0)
                {
                    flag = false;
                    break;
                }
                stack.Pop();
            }
            return stack.Count == 0 && flag;
        }

        [return: MarshalAs(UnmanagedType.U1)]
        internal static bool IsNumber(string s)
        {
            if (s.Length != 0)
            {
                for (var i = 0; i < s.Length; i++)
                {
                    if (char.IsNumber(s[i])) continue;
                    if (s[i] != '.') return false;

                    if (i == 0) return false;

                    var text = s.Substring(i + 1);
                    if (!text.Contains(".")) continue;
                    return false;
                }
                return true;
            }
            return false;
        }

        internal static int GetSubNodeL(int operID)
        {
            switch (operID)
            {
                case 5:
                    return 4;
                case 6:
                case 7:
                case 16:
                case 17:
                case 18:
                    return 2;
                default:
                    return 0;
            }
        }

        internal static int GetSubNodeR(int operID)
        {
            switch (operID)
            {
                case 6:
                case 7:
                case 16:
                case 17:
                case 18:
                    return 4;
                default:
                    return 0;
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }
    }
}
