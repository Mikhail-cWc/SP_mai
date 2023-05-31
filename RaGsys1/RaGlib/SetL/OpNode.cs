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
	public abstract class OpNode
	{
		public static List<Symbol> Parse(string input, Dictionary<string, Variable> variables)
		{
			input = input.Trim();
			var operation = Parser.Matches(Parser.OpConditionRegex, input)?.FirstOrDefault()?.Groups;
		/*	
			if (operation?.ContainsKey("condition") == true)
			{
				 return new OpCondition(Parse(operation["left"].Value), Parse(operation["right"].Value));
			}
            
			operation = Parser.Matches(Parser.OpFromRegex, input)?.FirstOrDefault()?.Groups;
			if (operation?.ContainsKey("from") == true)
			{
				return new OpFrom(operation["left"].Value, Parse(operation["right"].Value, variables));
			}
			
		operation = Parser.Matches(Parser.OpAutomateRegex, input)?.FirstOrDefault()?.Groups;
		if (operation?.ContainsKey("automate") == true)
		{
			 return new OpAutomate(Parse(operation["left"].Value) as OpVariable, Parse(operation["right"].Value) as OpVariable);
		}
		*/
			operation = Parser.Matches(Parser.OpKliniRegex, input)?.FirstOrDefault()?.Groups;
			if (operation?.ContainsKey("symbol") == true)
			{
				return Set.StarKlini(variables[operation["symbol"].Value].Symbols);
			}
			/*
			operation = Parser.Matches(Parser.OpSetUnionRegex, input)?.FirstOrDefault()?.Groups;
			if (operation?.ContainsKey("union") == true)
			{
				 return new OpSetUnion(Parse(operation["left"].Value), Parse(operation["right"].Value));
			}
			operation = Parser.Matches(Parser.OpSetIntersectRegex, input)?.FirstOrDefault()?.Groups;
			if (operation?.ContainsKey("intersect") == true)
			{
				 return new OpSetIntersect(Parse(operation["left"].Value), Parse(operation["right"].Value));
			}
			operation = Parser.Matches(Parser.OpVariableRegex, input)?.FirstOrDefault()?.Groups;
			if (operation?.ContainsKey("name") == true)
			{
				 return new OpVariable(operation["name"].Value);
			}
			*/
			return null;
		}

		public abstract DataNode GetResult(Dictionary<string, Variable> variables);
	}
}
