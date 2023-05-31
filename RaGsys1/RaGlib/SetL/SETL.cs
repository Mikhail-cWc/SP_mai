using RaGlib.SETL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaGlib;
using RaGlib.Core;
using RaGlib.Grammars;
using RaGlib.Automata;

namespace RaGlib.SetL
{
	public class SETL
	{
		public Dictionary<string, Variable> Variables { get; }
		public Dictionary<char, List<Symbol>> Data { get; }
		public Dictionary<char, List<Production>> Productions { get; }
		public SETL(string text, Grammar grammar)
		{
			var aa = new int[] { 1, 2, 3 };
			
			Variables = new();
			/*
			Productions = new();
			Data = new();
			Data['T'] = grammar.T;
			Data['V'] = grammar.V;
			Data['S'] = new List<Symbol>() {grammar.S0};

			Productions['P'] = grammar.P;
			*/
			Variables["T"] = new Variable("T", grammar.T);
			Variables["V"] = new Variable("V", grammar.V);
			Variables["S"] = new Variable("S", new List<Symbol>() { grammar.S0 });

			var result = new Variable(string.Empty, null);

			//var rgx = Parser.Matches(Parser.VariableRegex, text).First().Groups;

			var pattern = Parser.Matches(Parser.SetRegex, text)?.FirstOrDefault()?.Groups;
			if (pattern?.ContainsKey("elements") == true)
			{
				var subPattern = Parser.Matches(Parser.OperationRegex, pattern["elements"].Value)?.FirstOrDefault()?.Groups;
				if (subPattern?.ContainsKey("operation") == true)
				{
					foreach (var sasd in subPattern)
						result.Symbols = OpNode.Parse(pattern["elements"].Value, Variables);//.GetResult(this.Variables);
				}
			}
			/*
			else
			{
				pattern = Parser.Matches(Parser.ElementOperationRegex, text)?.FirstOrDefault()?.Groups;
				if (pattern?.ContainsKey("operation") == true)
					result.Data = OpNode.Parse(pattern["operation"].Value).GetResult(this.Variables);
			}
			*/



			//Console.WriteLine($"({result.Data.GetType()})");
			Variables["C"] = result;
			Console.WriteLine();
		}
	}
}
