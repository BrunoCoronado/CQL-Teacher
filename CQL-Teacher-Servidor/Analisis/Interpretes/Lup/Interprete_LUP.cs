using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQL_Teacher_Servidor.Analisis.Interpretes.Lup
{
    public class Interprete_LUP : Grammar
    {
        public ParseTreeNode raiz;

        public Interprete_LUP()
        {
            raiz = null;
        }

        public bool interpretar(String entrada)
        {
            ParseTree parseTree = new Parser(new LanguageData(new Gramatica_Lup())).Parse(entrada);
            if (parseTree.Root != null)
                return true;
            return false;
        }
    }
}
