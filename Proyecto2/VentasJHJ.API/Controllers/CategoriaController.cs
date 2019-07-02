using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using VentasJHJ.Model.Data;
using VentasJHJ.Model.Domain;

namespace VentasJHJ.API.Controllers
{
    [Produces("application/json")]
    [Route("api/categorias")]
    public class CategoriaController : Controller
    {
        private readonly IConfiguration configuration;
        public CategoriaController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        // GET: api/clientes
        [HttpGet]
        public IEnumerable<Categoria> Get()
        {
            CategoriaData categoriaData =
                new CategoriaData(configuration.GetConnectionString("VideoContext").ToString());
            return categoriaData.GetAll();
        }
    }
}