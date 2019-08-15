using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CQL_Teacher_API.Sistema.Analisis.Interpretes.CQL
{
    public class Gramatica_CQL : Grammar
    {

        public Gramatica_CQL() : base(caseSensitive: false)
        {
            //COMENTARIOS
            CommentTerminal comentarioLinea = new CommentTerminal("comentarioLinea", "//", "\n", "\r\n", "\r", "\u2085", "\u2028", "\u2029");
            CommentTerminal comentarioMultiLinea = new CommentTerminal("comentarioMultiLinea", "/*", "*/");

            //IDENTIFICADOR
            IdentifierTerminal identificador = new IdentifierTerminal("identificador");

            //TIPOS DE DATOS Y VALOR NULO
            var _null = ToTerm("null");

            var _int = ToTerm("int");
            RegexBasedTerminal numeroEntero = new RegexBasedTerminal("int", "[0-9]+");

            var _double = ToTerm("double");
            RegexBasedTerminal numeroDecimal = new RegexBasedTerminal("double", "[0-9]+\\.[0-9]+");

            var _string = ToTerm("string");
            StringLiteral cadena = new StringLiteral("string", "\"");

            var _bool = ToTerm("boolean");
            RegexBasedTerminal valorBooleano = new RegexBasedTerminal("boolean", "true|false");

            var _date = ToTerm("date");
            RegexBasedTerminal fecha = new RegexBasedTerminal("date", "[0-2][0-9]{3}-(0[0-9]|1[0-2])-(0[0-9]|1[0-9]|2[0-9]|3[0-1])");

            var _time = ToTerm("time");
            RegexBasedTerminal hora = new RegexBasedTerminal("time", "(0[0-9]|1[0-9]|2[0-4])-([0-5][0-9]|60)-([0-5][0-9]|60)");

            //NO TERMINALES


            
        }
    }
}