using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CQL_Teacher_API.Controllers
{
    public class PruebaController : ApiController
    {
        public string GetAllProducts()
        {
            return "prueba de get";
        }
    }
}
