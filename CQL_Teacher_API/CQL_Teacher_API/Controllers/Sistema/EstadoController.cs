using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CQL_Teacher_API.Controllers.Sistema
{
    public class EstadoController : ApiController
    {
        // GET: api/Estado
        public String Get()
        {
            return "Servidor Activo";
        }
    }
}
