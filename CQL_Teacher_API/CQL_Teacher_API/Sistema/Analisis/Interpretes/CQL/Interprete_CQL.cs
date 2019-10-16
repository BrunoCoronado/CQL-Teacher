using CQL_Teacher_API.Sistema.Analisis.Graficas;
using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CQL_Teacher_API.Sistema.Analisis.Interpretes.CQL
{
    public class Interprete_CQL
    {
        public bool interpretar(string entrada)
        {
            ParseTree parseTree = new Parser(new LanguageData(new Gramatica_CQL())).Parse(entrada);
            if (parseTree.Root != null)
            {
                AST ast = new AST();
                ast.graficar(parseTree.Root);
                return true;
            }
            return false;
        }
    }
}