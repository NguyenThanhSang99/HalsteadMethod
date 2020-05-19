using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace HalsteadMethod.Business
{
    public class CalculateOperand
    {
        private string path;
        Dictionary<string, int> list_operand;
        char[] special_char = { '+', '-', '*', '/', '.', ',', ';', '[', ']', '{', '}', '(', ')', '?', '<', '>'
                , '=', '!', '#', '@', '$', '%', '^', '&', ':', '\\' };
        Dictionary<string, string> exception_dictionary = new Dictionary<string, string>();

        public CalculateOperand(string path, Dictionary<string, int> operands)
        {
            this.path = path;
            Debug.Print(System.IO.Path.GetFullPath(@"..\..\"));
            this.UpdateDictionary(Path.Combine(System.IO.Path.GetFullPath(@"..\..\"), @"Business\key_word.txt"));
            this.List_operand = operands;
            this.Analyze();
        }

        public Dictionary<string, int> List_operand { get => list_operand; set => list_operand = value; }

        private void Analyze()
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(this.path);
                bool checkComment = false;
                bool begin = false;
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
                    if (!begin)
                    {
                        if (data.Contains("{"))
                        {
                            begin = true;
                        }
                    }
                    if (begin)
                    {
                        string[] dataInLine = data.Split(' ');
                        String case_string = "";
                        foreach (string str in dataInLine)
                        {
                            if (!exception_dictionary.ContainsKey(str))
                            {
                                if (str.Contains("\"") || case_string != "")
                                {
                                    case_string += str;
                                    if (CountCharacterInString(case_string, '"') == 2)
                                    {
                                        AddOperand("String");
                                        case_string = "";
                                    }
                                    continue;
                                }

                                this.AddOperand(str);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void AddOperand(string operand)
        {
            if (exception_dictionary.ContainsKey(operand) || operand == null)
            {
                return;
            }

            foreach(char ch in special_char)
            {
                if (operand.Contains(ch))
                {
                    AddOperandWithSpecialChar(operand, ch);
                    return;
                }
            }

            if (!List_operand.ContainsKey(operand))
            {
                List_operand.Add(operand, 1);
            }
            else
            {
                List_operand[operand] += 1;
            }
        }

        private void AddOperandWithSpecialChar(string str, char ch)
        {
            string[] split_str = str.Split(ch);
            foreach (string s in split_str)
            {
                AddOperand(s);
            }
        }

        private int CountCharacterInString(String str, char ch)
        {
            int count = 0;
            foreach (char c in str)
                if (c == ch) count++;
            return count;
        }

        public int Total()
        {
            int sum = 0;
            foreach (KeyValuePair<string, int> item in list_operand)
            {
                sum += item.Value;
            }
            return sum;
        }

        private void UpdateDictionary(string path)
        {
            string[] lines = System.IO.File.ReadAllLines(path);
            exception_dictionary.Add("","");
            for (int i = 0; i < lines.Length; i++)
            {
                string key = lines[i].Trim();
                //Cut off the leading space
                if (!exception_dictionary.ContainsKey(key))
                {
                    exception_dictionary.Add(key, key);
                }
            }
        }
    }
}
