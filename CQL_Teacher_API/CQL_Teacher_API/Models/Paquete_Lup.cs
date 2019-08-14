using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CQL_Teacher_API.Models
{
    public class Paquete_Lup
    {
        public string contenido { get; set; } //atributo utilizado solo para guardar la información recibida del cliente
        public int tipo; //atributo para identificar el tipo de paquete -> 1.Login 2.Logout 3.Query 4.Struct
        public Hashtable data; //tabla que contendra la informacion importante dependiendo del tipo de paquete

        public Paquete_Lup()
        {
            contenido = null;
            tipo = 0;
            data = new Hashtable();
        }
    }
}