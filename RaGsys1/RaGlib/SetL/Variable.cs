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
    public class Variable
    {
        public string Name { get; set; }
        public DataNode Data { get; set; }
        public List<Symbol> Symbols { get; set; }
        public Variable(string name, List<Symbol>symb)// DataNode data)
        {
            Name = name;
       //     Data = data;
            Symbols = symb;
        }

        /*
        public static Variable Parse(SETL setl, string line)
        {
            var result = new Variable(string.Empty, null, null);
            var rgx = Parser.Matches(Parser.VariableRegex, line).First().Groups;
            result.Name = rgx["name"].Value;
            result.Data = DataNode.Parse(setl, rgx["data"].Value);
            return result;
        } 
        */
    }
}
