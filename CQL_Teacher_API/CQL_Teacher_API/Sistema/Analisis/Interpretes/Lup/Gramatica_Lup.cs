using Irony.Parsing;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CQL_Teacher_API.Sistema.Analisis.Interpretes.Lup
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
            RegexBasedTerminal contenido = new RegexBasedTerminal("contenido", "[^\\[-]*");

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
            NonTerminal INICIO = new NonTerminal("INICIO"),
                        ABRE_ETIQUETA = new NonTerminal("ABRE_ETIQUETA"),
                        CIERRE_ETIQUETA = new NonTerminal("CIERRE_ETIQUETA"),
                        ETIQUETA_PADRE = new NonTerminal("ETIQUETA_PADRE"),
                        ETIQUETA_LOGIN = new NonTerminal("ETIQUETA_LOGIN"),
                        ETIQUETA_LOGOUT = new NonTerminal("ETIQUETA_LOGOUT"),
                        ETIQUETA_QUERY = new NonTerminal("ETIQUETA_QUERY"),
                        ETIQUETA_STRUCT = new NonTerminal("ETIQUETA_STRUCT"),
                        ETIQUETA_USER = new NonTerminal("ETIQUETA_USER"),
                        ETIQUETA_PASS = new NonTerminal("ETIQUETA_PASS"),
                        ETIQUETA_DATA = new NonTerminal("ETIQUETA_DATA"),
                        CONTENIDO = new NonTerminal("CONTENIDO");

            //PREFERENCIAS
            this.Root = INICIO;
            this.MarkPunctuation("$", "]", "[", "+", "-", "user", "data", "query", "login", "pass", "logout", "struct");
            this.MarkTransient(INICIO, ETIQUETA_PADRE, ABRE_ETIQUETA, CIERRE_ETIQUETA, CONTENIDO, ETIQUETA_USER, ETIQUETA_PASS, ETIQUETA_DATA);

            //GRAMATICA
            INICIO.Rule = ABRE_ETIQUETA  + ETIQUETA_PADRE + corcheteCierra + aceptacion
                    | aceptacion
            ;

            ABRE_ETIQUETA.Rule = corcheteAbre + mas;

            CIERRE_ETIQUETA.Rule = corcheteAbre + menos;

            ETIQUETA_PADRE.Rule = ETIQUETA_LOGIN
                    | ETIQUETA_LOGOUT
                    | ETIQUETA_QUERY
                    | ETIQUETA_STRUCT
            ;

            ETIQUETA_LOGIN.Rule = _login + corcheteCierra + ETIQUETA_USER + ETIQUETA_PASS + CIERRE_ETIQUETA + _login;

            ETIQUETA_LOGOUT.Rule = _logout + corcheteCierra + ETIQUETA_USER + CIERRE_ETIQUETA + _logout;

            ETIQUETA_QUERY.Rule = _query + corcheteCierra + ETIQUETA_USER + ETIQUETA_DATA + CIERRE_ETIQUETA + _query;

            ETIQUETA_STRUCT.Rule = _struct + corcheteCierra + ETIQUETA_USER + CIERRE_ETIQUETA + _struct;

            ETIQUETA_USER.Rule = ABRE_ETIQUETA + _user + CONTENIDO + _user + corcheteCierra;

            ETIQUETA_PASS.Rule = ABRE_ETIQUETA + _pass + CONTENIDO + _pass + corcheteCierra;

            ETIQUETA_DATA.Rule = ABRE_ETIQUETA + _data + CONTENIDO + _data + corcheteCierra;

            CONTENIDO.Rule = corcheteCierra + contenido + CIERRE_ETIQUETA;

        }

        public override void ReportParseError(ParsingContext context)
        {
            base.ReportParseError(context);
            if (context.CurrentToken.ValueString.Contains("Invalid character"))
            {
                //errores.Add(new Error("ERROR LEXICO", "NO SE RECONOCIO ESTE SIMBOLO " + context.CurrentToken.ValueString.ToString(), (context.Source.Location.Line + 1), context.Source.Location.Column));
                System.Diagnostics.Debug.WriteLine("ERROR LEXICO", "NO SE RECONOCIO ESTE SIMBOLO " + context.CurrentToken.ValueString.ToString() + " EN LINEA " + (context.Source.Location.Line + 1)  + " Y COLUMNA " + context.Source.Location.Column);
            }
            else
            {
                //errores.Add(new Error("ERROR SINTACTICO", "NO SE ESPERABA ESTE SIMBOLO " + context.CurrentToken.ValueString.ToString(), (context.Source.Location.Line + 1), context.Source.Location.Column));
                System.Diagnostics.Debug.WriteLine("ERROR SINTACTICO", "NO SE ESPERABA ESTE SIMBOLO " + context.CurrentToken.ValueString.ToString() + " EN LINEA " + (context.Source.Location.Line + 1) + " Y COLUMNA " + context.Source.Location.Column);
            }
        }
    }
}