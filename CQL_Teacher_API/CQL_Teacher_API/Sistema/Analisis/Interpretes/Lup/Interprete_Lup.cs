using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CQL_Teacher_API.Sistema.Analisis.Interpretes.Lup
{
    public class Interprete_Lup: Grammar
    {
        public ParseTreeNode raiz;

        public Interprete_Lup()
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