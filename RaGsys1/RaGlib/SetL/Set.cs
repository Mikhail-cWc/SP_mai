using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaGlib.Core;

namespace RaGlib.SetL
{
	public static class Set
	{
		private const int _maxLength = 4;

		/// Распечатать (вывести) множество A
		public static void Print(List<Symbol> A)
		{
			Console.Write("{ ");
			foreach (Symbol s in A)
			{
				Console.Write(s);
				if (s != A.Last())
				{
					Console.Write(", ");
				}
			}
			Console.Write(" }");
		} // end print


		/// Принадлежит ли element множеству A
		public static bool Belongs(Symbol element, List<Symbol> A)
		{
			return A.Contains(element);
		} // end belongs


		/// Объединение множеств A or B
		public static List<Symbol> Union(List<Symbol> A, List<Symbol> B)
		{
			return A.AsEnumerable().Union(B.AsEnumerable()).ToList();
		} // end union


		/// Пересечение множеств A and B
		public static List<Symbol> Intersect(List<Symbol> A, List<Symbol> B)
		{
			return A.AsEnumerable().Intersect(B.AsEnumerable()).ToList();
		} // end intersect

		// Звезда Клини множество всех строк конечной длины́, порождённое элементами множества V
		public static List<Symbol> StarKlini(List<Symbol> symbols)
		{
			var result = new List<Symbol>() {"e"};
			var strs = new Stack<string>();
			foreach (var c in symbols)
			{
				strs.Push(c.symbol);
			}

			while (strs.Count > 0)
			{
				var top = strs.Pop();
				if (top.Length > _maxLength)
				{
					continue;
				}
				result.Add(new Symbol(top));
				foreach (var c in symbols)
				{
					strs.Push(top + c.symbol);
				}
			}
			return result;
		}

	}
}
