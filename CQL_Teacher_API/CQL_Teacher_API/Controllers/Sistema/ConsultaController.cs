using CQL_Teacher_API.Models;
using CQL_Teacher_API.Sistema.Analisis.Graficas;
using CQL_Teacher_API.Sistema.Analisis.Interpretes.Lup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CQL_Teacher_API.Controllers.Sistema
{
    public class ConsultaController : ApiController
    {
        private Interprete_Lup interprete_Lup = new Interprete_Lup();

        // POST: api/Consulta
        public string Post([FromBody]Paquete_Lup paquete_lup)
        {
            if (paquete_lup is null)
                return "sin contenido";
            Paquete_Lup paquete_procesado = interprete_Lup.interpretar(paquete_lup.contenido + "$"); //interpretamos el contenido que envia el cliente para obtener un paquete procesado con la informacion util para el interprete CQL
            if (paquete_procesado != null) //si el paquete no es nulo, entonces sabemos que la salida sera un paquete tipo 3
                return "contenido valido - se produjo un paquete del tipo " + paquete_procesado.tipo; //mandar al interprete CQL
            return "contenido invalido";
        }
    }
}
