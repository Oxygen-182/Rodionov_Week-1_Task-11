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
        class StringB
        {
            public StringB(string s, int len)
            {
                n = len;
                Line = new StringBuilder(s.Substring(0, n));
            }
            public int CountSpaces()
            {
                return Line.ToString().Count(x => x == ' ');
            }
            public void RemovePuncts()
            {
                string s = Line.ToString();
                Line.Clear();
                Line.Append(Regex.Replace(s, "[,.:?!]", ""));
                n = Line.Length;
            }
            public void Prop()
            {
                string s = Line.ToString();
                Line.Clear();
                Line.Append(Regex.Replace(s, @"[А-ЯЁ]", m => m.ToString().ToLower()));
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
            private StringBuilder Line;
            private int n;
        }
        
        static void Main(string[] args)
        {
            string line;
            int n;

            while (true)
            {
                try
                {
                    Console.Write("Введите количество символов в строке: ");
                    n = int.Parse(Console.ReadLine());

                    Console.Write("Введите строку: ");
                    line = (Console.ReadLine());

                    if (n > line.Length) throw new Exception("Количество символов в строке не может быть меньше указаного");

                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            StringB s = new StringB(line, n);
            Console.WriteLine("\nСтрока: {0} \nДлина строки: {1}", s, s.Length);
            Console.WriteLine("\nКоличество пробелов: {0}", s.CountSpaces());
            s.Prop();
            Console.WriteLine("\nЗамена прописных букв на строчные: {0}", s);
            s.RemovePuncts();
            Console.WriteLine("\nСтрока без знаков препинания: {0} \nДлина строки: {1}", s, s.Length);
            Console.WriteLine("\nСтрока: {0}", s.line);
        }
    }
}
