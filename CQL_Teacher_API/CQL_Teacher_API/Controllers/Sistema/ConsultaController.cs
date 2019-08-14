using CQL_Teacher_API.Models;
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
        // GET: api/Consulta
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST: api/Consulta
        public string Post([FromBody]Paquete_Lup paquete)
        {
            if (paquete is null)
            {
                return "nulo";
            }
            else
            {
                return paquete.contenido;
            }
            
        }
    }
}
