using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace CQL_Teacher_API.Sistema.Analisis.Graficas
{
    public class AST
    {
        private int contadorNodos = 0;
        private String conexiones = "";
        private StreamWriter streamWriter;

        public void graficar(ParseTreeNode raiz)
        {
            try
            {
                using (streamWriter = new StreamWriter(System.Web.HttpContext.Current.Server.MapPath("~/App_Data/ast.txt")))
                {
                    streamWriter.WriteLine("digraph G{");
                    String idNodo = "nodo" + (++contadorNodos).ToString();
                    streamWriter.WriteLine(idNodo + "[label = \" " + contadorNodos.ToString() + " \\n " + raiz.ToString() + " \"]");

                    if (raiz.ChildNodes.Count != 0)
                    {
                        foreach (ParseTreeNode node in raiz.ChildNodes)
                            graficarHijos(idNodo, node);
                    }
                    streamWriter.Write(conexiones + "\n}");
                }
                //String comando = "/C dot.exe -Tsvg " + System.Web.HttpContext.Current.Server.MapPath("~/App_Data/ast.txt") + " -o " + System.Web.HttpContext.Current.Server.MapPath("~/App_Data/ast.svg");
                //System.Diagnostics.Debug.WriteLine(System.Web.HttpContext.Current.Server.MapPath(".") + "\\App_Data\\graficar.bat");
                //System.Diagnostics.Process.Start(System.Web.HttpContext.Current.Server.MapPath(".") + "\\App_Data\\graficar.bat");
                //System.Diagnostics.Process.Start(System.Web.HttpContext.Current.Server.MapPath("~/ast.svg"));
            }
            catch (Exception ex)
            {
                //abrirArchivo();
            }
        }

        private void graficarHijos(String padre, ParseTreeNode hijo)
        {
            string idNodo = "nodo" + (++contadorNodos).ToString();
            streamWriter.WriteLine(idNodo + "[label = \" " + contadorNodos.ToString() + " \\n " + hijo.ToString() + " \"]");
            conexiones += padre + "->" + idNodo + "\n";
            if (hijo.ChildNodes.Count != 0)
            {
                foreach (ParseTreeNode node in hijo.ChildNodes)
                    graficarHijos(idNodo, node);
            }
        }
    }
}