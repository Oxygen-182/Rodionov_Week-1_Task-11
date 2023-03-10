using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp_11_form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        class ThisString
        {
            private StringBuilder Line;
            private int n;
            public ThisString(string str)
            {
                Line = new StringBuilder(str);
                n = str.Length;
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
            public void Prop()
            {
                string str = Line.ToString();
                Line.Clear();
                Line.Append(Regex.Replace(str, @"[А-ЯЁ]", m => " " + m.ToString().ToLower()));
                n = Line.Length;
            }
            public int length
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
        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            string line;

            while (true)
            {
                try
                {
                    line = textBox2.Text;
                    break;
                }
                catch (Exception ex)
                {
                    textBox3.Text += ex.Message;
                }
            }

            ThisString s = new ThisString(line);
            textBox3.Text += $"Строка: {s}" + Environment.NewLine + $"Длина строки: {s.length}" + Environment.NewLine;
            textBox3.Text += Environment.NewLine + $"Количество пробелов: {s.CountSpaces()}" + Environment.NewLine;
            s.Prop();
            textBox3.Text += Environment.NewLine + $"Замена прописных букв на строчные: {s}" + Environment.NewLine;
            s.RemovePuncts();
            textBox3.Text += Environment.NewLine + $"Строка без знаков препинания: {s}" + Environment.NewLine + $"Длина строки: {s.length}" + Environment.NewLine;
            textBox3.Text += Environment.NewLine + $"Строка: {s.line}" + Environment.NewLine;
        }
    }
}
