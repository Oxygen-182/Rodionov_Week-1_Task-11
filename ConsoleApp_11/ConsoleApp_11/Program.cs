using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp_11
{
    internal class Program
    {
        class ThisString
        {
            private StringBuilder Line;
            private int n;
            public ThisString(string str)
            {
                Line = new StringBuilder(str);
                n = str.Length;
            }
            public ThisString(string str, int len)
            {
                n = len;
                Line = new StringBuilder(str.Substring(0, n));
            }
            public int CountSpaces()
            {
                return Line.ToString().Count(x => x == ' ');
            }
            public void RemovePuncts()
            {
                string str = Line.ToString();
                Line.Clear();
                Line.Append(Regex.Replace(str, "[,.:?!]", ""));
                n = Line.Length;
            }
            public void Lower()
            {
                string str = Line.ToString();
                Line.Clear();
                Line.Append(Regex.Replace(str, @"[А-ЯЁ]", m => m.ToString().ToLower()));
                n = Line.Length;
            }
            public int Length
            {
                get { return n; }
            }
            public StringBuilder line
            {
                get
                {
                    return Line;
                }
                set
                {
                    Line = value;
                }
            }
            public override string ToString()
            {
                return Line.ToString();
            }
        }
        
        static void Main(string[] args)
        {
            string line;

            while (true)
            {
                try
                {
                    Console.Write("Введите строку: ");
                    line = (Console.ReadLine());
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            ThisString s = new ThisString(line);
            Console.WriteLine("\nСтрока: {0} \nДлина строки: {1}", s, s.Length);
            Console.WriteLine("\nКоличество пробелов: {0}", s.CountSpaces());
            s.Lower();
            Console.WriteLine("\nЗамена прописных букв на строчные: {0}", s);
            s.RemovePuncts();
            Console.WriteLine("\nСтрока без знаков препинания: {0} \nДлина строки: {1}", s, s.Length);
            Console.WriteLine("\nСтрока: {0}", s.line);
        }
    }
}
