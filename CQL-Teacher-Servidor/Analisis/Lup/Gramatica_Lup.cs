using Irony.Parsing;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQL_Teacher_Servidor.Analisis.Lup //namespace no acepta - -> remplazar por _
{
    public class Gramatica_Lup : Grammar
    {

        public ArrayList errores;

        public Gramatica_Lup() : base(caseSensitive: false)
        {
            //ERRORES
            errores = new ArrayList();

            //ACEPTACION
            var aceptacion = ToTerm("$");

            //CONTENIDO
            RegexBasedTerminal contenido = new RegexBasedTerminal("contenido", "[\\s\\S]*");

            //ETIQUETAS
            var _login = ToTerm("login");
            var _user = ToTerm("user");
            var _pass = ToTerm("pass");
            var _logout = ToTerm("logout");
            var _query = ToTerm("query");
            var _data = ToTerm("data");
            var _struct = ToTerm("struct");

            //ESTRUCTURA ETIQUETAS
            var corcheteAbre = ToTerm("[");
            var corcheteCierra = ToTerm("]");
            var mas = ToTerm("+");
            var menos = ToTerm("-");

            //NO TERMINALES
            NonTerminal INICIO = new NonTerminal("INICIO");
            NonTerminal ABRE_ETIQUETA = new NonTerminal("ABRE_ETIQUETA");
            NonTerminal CIERRE_ETIQUETA = new NonTerminal("CIERRE_ETIQUETA");
            NonTerminal ETIQUETA_PADRE = new NonTerminal("ETIQUETA_PADRE");
            NonTerminal ETIQUETA_USER = new NonTerminal("ETIQUETA_USER");
            NonTerminal ETIQUETA_PASS = new NonTerminal("ETIQUETA_PASS");
            NonTerminal ETIQUETA_DATA = new NonTerminal("ETIQUETA_DATA");
            NonTerminal CONTENIDO = new NonTerminal("CONTENIDO");

            //PREFERENCIAS
            this.Root = INICIO;
            this.MarkPunctuation("$", "]", "[", "+", "-");
            this.MarkTransient(INICIO);

            //GRAMATICA
            INICIO.Rule = ABRE_ETIQUETA + ETIQUETA_PADRE + aceptacion
                    | aceptacion
            ;

            ABRE_ETIQUETA.Rule = corcheteAbre + mas;

            CIERRE_ETIQUETA.Rule = corcheteAbre + menos;

            ETIQUETA_PADRE.Rule = _login + corcheteCierra + ETIQUETA_USER +  ETIQUETA_PASS + CIERRE_ETIQUETA + _login
                    | _logout + corcheteCierra + ETIQUETA_USER + CIERRE_ETIQUETA + _logout
                    | _query + corcheteCierra + ETIQUETA_USER + ETIQUETA_DATA + CIERRE_ETIQUETA + _query
                    | _struct + corcheteCierra + ETIQUETA_USER + CIERRE_ETIQUETA + _struct
            ;

            ETIQUETA_USER.Rule = ABRE_ETIQUETA + _user + CONTENIDO + _user + corcheteCierra;

            ETIQUETA_PASS.Rule = ABRE_ETIQUETA + _pass + CONTENIDO + _pass + corcheteCierra;

            ETIQUETA_DATA.Rule = ABRE_ETIQUETA + _data + CONTENIDO + _data + corcheteCierra;

            CONTENIDO.Rule = corcheteCierra + contenido + CIERRE_ETIQUETA;

        }

        public override void ReportParseError(ParsingContext context)
        {
            base.ReportParseError(context);
            if (context.CurrentToken.ValueString.Contains("Invalid character")) { }
            //errores.Add(new Error("ERROR LEXICO", "NO SE RECONOCIO ESTE SIMBOLO " + context.CurrentToken.ValueString.ToString(), (context.Source.Location.Line + 1), context.Source.Location.Column));
            else { }
            //errores.Add(new Error("ERROR SINTACTICO", "NO SE ESPERABA ESTE SIMBOLO " + context.CurrentToken.ValueString.ToString(), (context.Source.Location.Line + 1), context.Source.Location.Column));
        }
    }
}
