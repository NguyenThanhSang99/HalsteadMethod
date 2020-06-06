using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalsteadMethod.Analysis
{
	class KeywordsAnalyzer
	{
		public static  KeywordsAnalyzer _instance;
		private static String[] keywords = { "auto", "break", "case", "char", "const", "continue", "default", "do",
			"double", "else", "enum", "extern", "float", "for", "goto", "if", "int", "long", "register", "return",
			"short", "signed", "sizeof", "static", "struct", "switch", "typedef", "union", "unsigned", "void",
			"volatile", "while" };


		private KeywordsAnalyzer()
		{

		}

		public static KeywordsAnalyzer Instance {
			get { if (_instance == null) _instance = new KeywordsAnalyzer();
				return _instance; }
			set => _instance = value;
		}

		public static int size()
		{
			return keywords.Length;
		}

		public bool isKeyword(String keyword)
		{
			bool result = false;
			for (int i = 0; i < size(); ++i)
			{
				if (keywords[i].Equals(keyword))
				{
					result = true;
					break;
				}
			}
			return result;
		}
	}
}
