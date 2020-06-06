using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalsteadMethod.Analysis
{
    class SymbolAnalyzer
    {
		private static String[] symbols = { "+", "++", "-", "--", "*", ".", ";", "/", "%", "!", ">", "<", ">=", "<=", "==", "=", ":", "~" };

		public static SymbolAnalyzer _instance;
		private SymbolAnalyzer()
		{

		}

		public static SymbolAnalyzer Instance
		{
			get
			{
				if (_instance == null) _instance = new SymbolAnalyzer();
				return _instance;
			}
			set => _instance = value;
		}

		public static int size()
		{
			return symbols.Length;
		}

		public bool isSymbols(String symbols)
		{
			bool result = false;
			for (int i = 0; i < size(); ++i)
			{
				if (symbols[i].Equals(symbols))
				{
					result = true;
					break;
				}
			}
			return result;
		}
	}
}
