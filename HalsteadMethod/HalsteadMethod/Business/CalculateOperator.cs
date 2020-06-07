using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalsteadMethod.Business
{
    class CalculateOperator
    {
        private string path;
        Dictionary<string, int> list_operator;
        private static String[] list_triple_symbols = { "+++", "---", "<<=", ">>=" };
        private static String[] list_double_symbols = { "++", "--", "&&", "||", "==", "!=", ">=", "<=", "<<", ">>", "+=", "-+", "*=", "/=", "%=", "^=", "&=", "|=", "?:" };
        private static char[] list_single_symbols = { '+', '-', '*', '/', '.', ',', ';', '[', ']', '{', '}', '(', ')', '?', '<', '>'
                , '=', '!', '#', '@', '$', '%', '^', '&', ':', '\\', '|' };
        Dictionary<string, string> keyword_dictionary = new Dictionary<string, string>();
        public CalculateOperator(Dictionary<string, int> operands)
        {
            this.list_operator = operands;
        }
        public CalculateOperator(string path, Dictionary<string, int> operands)
        {
            this.path = path;
            this.UpdateDictionary(Path.Combine(System.IO.Path.GetFullPath(@"..\..\"), @"Business\key_word.txt"));
            this.List_operator = operands;
            this.Analyze();
        }

        public Dictionary<string, int> List_operator { get => list_operator; set => list_operator = value; }

        private void Analyze()
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(this.path);
                bool checkComment = false;
                foreach (string line in lines)
                {
                    string data = line;
                    //Cut off the leading space
                    data = data.Trim();
                    //Check if the line is empty then decrease total lines and continue this loop
                    if (data.Equals(""))
                    {
                        continue;
                    }
                    //Check if the line is in a comment block then continues the loop
                    if (checkComment)
                    {
                        //Check if that's the end of the comment block then checkComment is false
                        if (data.Contains("*/"))
                        {
                            checkComment = false;
                            //Check if after */ hasn't data then continues the loop
                            int position = data.IndexOf("*/");
                            if (position + 2 == data.Length)
                            {
                                continue;
                            }
                            //We continue check data after */
                            data = data.Substring(position + 2);
                        }
                        else
                        {
                            continue;
                        }
                    }

                    //Check if this line contains a single comment then totalComment increate
                    if (data.Contains("//"))
                    {
                        //Check if single comment is at the beginning of the line then continues the loop
                        if (data[0] == '/')
                        {
                            continue;
                        }
                        else
                        {
                            string[] spl_string = data.Split('/');
                            data = spl_string[0];
                        }
                    }
                    //Check if if that's the begin of the comment block
                    if (data.Contains("/*"))
                    {
                        //Check if this line does not contain a command to close the comment block then checkComment is true
                        if (!data.Contains("*/"))
                        {
                            checkComment = true;
                        }
                        //Check if block comment is at the beginning of the line then continues the loop
                        if (data[0] == '/')
                        {
                            continue;
                        }
                    }

                    string[] words = data.Split(' ');
                    String case_string = "";
                    foreach (string str in words)
                    {
                        if (str.Contains("\"") || case_string != "")
                        {
                            case_string += str;
                            if (CountCharacterInString(case_string, '"') == 2)
                            {
                                case_string = "";
                            }
                            continue;
                        }
                        
                        AddOperators(str);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        private void AddOperators(string operand)
        {
            if (operand == null || operand == "")
            {
                return;
            }
            foreach (string str in list_triple_symbols)
            {
                if (operand.Contains(str))
                {
                    AddOperandWithSpecialChar(operand, str);
                    return;
                }
            }
            foreach (string str in list_double_symbols)
            {
                if (operand.Contains(str))
                {
                    AddOperandWithSpecialChar(operand, str);
                    return;
                }
            }
            foreach (char ch in list_single_symbols)
            {
                if (operand.Contains(ch))
                {
                    AddOperandWithSpecialChar(operand, ch.ToString());
                    return;
                }
            }

            if (keyword_dictionary.ContainsKey(operand))
            {
                AddOperator(operand, 1);
            }
        }

        private void AddOperandWithSpecialChar(string str, string ch)
        {
            string[] split_str = str.Split(new string[] { ch }, StringSplitOptions.None);
            switch (ch)
            {
                case "(": ch = "()"; break;
                case ")": return;
                case "[": ch = "[]"; break;
                case "]": return;
                case "{": ch = "{}"; break;
                case "}": return;
            }
            AddOperator(ch.ToString(), split_str.Length-1);
            foreach (string s in split_str)
            {
                AddOperators(s);
            }
        }
        private void AddOperator(string ope, int number)
        {
            if (!List_operator.ContainsKey(ope))
            {
                List_operator.Add(ope, number);
            }
            else
            {
                List_operator[ope] += number;
            }
        }

        private int CountCharacterInString(String str, char ch)
        {
            int count = 0;
            foreach (char c in str)
                if (c == ch) count++;
            return count;
        }

        private void UpdateDictionary(string path)
        {
            string[] lines = System.IO.File.ReadAllLines(path);
            keyword_dictionary.Add("", "");
            for (int i = 0; i < lines.Length; i++)
            {
                string key = lines[i].Trim();
                //Cut off the leading space
                if (!keyword_dictionary.ContainsKey(key))
                {
                    keyword_dictionary.Add(key, key);
                }
            }
        }
    }
}
