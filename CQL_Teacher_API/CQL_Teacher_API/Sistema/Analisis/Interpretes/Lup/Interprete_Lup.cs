using CQL_Teacher_API.Models;
using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CQL_Teacher_API.Sistema.Analisis.Interpretes.Lup
{
    public class Interprete_Lup: Grammar
    {
        public Paquete_Lup interpretar(String entrada)
        {
            ParseTree parseTree = new Parser(new LanguageData(new Gramatica_Lup())).Parse(entrada);
            if (parseTree.Root != null)
                return analizarPaqueteLup(parseTree.Root);
            return null;
        }

        private Paquete_Lup analizarPaqueteLup(ParseTreeNode raiz)//toma la raiz del arbol generado y retorna un paquete lup procesado para que sea utilizado por los demas interpretes
        {
            Paquete_Lup paquete_Lup = new Paquete_Lup();
            switch (raiz.ToString())
            {
                case "ETIQUETA_LOGIN": //creamos el paquete lup para el login que es del tipo 1
                    paquete_Lup.tipo = 1;
                    paquete_Lup.data.Add("usuario", raiz.ChildNodes.ElementAt(0)); //guardamos el nodo que contiene la informacion del usuario
                    paquete_Lup.data.Add("password", raiz.ChildNodes.ElementAt(1)); //guardamos el nodo que contiene la informacion del password
                    break;
                case "ETIQUETA_LOGOUT": //creamos el paquete lup para el logout que es del tipo 2
                    paquete_Lup.tipo = 2;
                    paquete_Lup.data.Add("usuario", raiz.ChildNodes.ElementAt(0)); //guardamos el nodo que contiene la informacion del usuario
                    break;
                case "ETIQUETA_QUERY": //creamos el paquete lup para el query que es del tipo 3
                    paquete_Lup.tipo = 3;
                    paquete_Lup.data.Add("usuario", raiz.ChildNodes.ElementAt(0)); //guardamos el nodo que contiene la informacion del usuario
                    paquete_Lup.data.Add("query", raiz.ChildNodes.ElementAt(1)); //guardamos el nodo que contiene la informacion del query
                    break;
                case "ETIQUETA_STRUCT": //creamos el paquete lup para el struct que es del tipo 4
                    paquete_Lup.tipo = 4;
                    paquete_Lup.data.Add("usuario", raiz.ChildNodes.ElementAt(0)); //guardamos el nodo que contiene la informacion del usuario
                    break;
            }
            return paquete_Lup;
        }
    }
}