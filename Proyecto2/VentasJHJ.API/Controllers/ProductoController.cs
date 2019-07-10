using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using VentasJHJ.Model.Business;
using VentasJHJ.Model.Domain;

namespace VentasJHJ.API.Controllers
{
    [Route("api/productos")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IConfiguration configuration;
        ProductoBusiness productoBusiness;
        public ProductoController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        [HttpGet]
        public IEnumerable<Producto> Get()
        {
            productoBusiness = new ProductoBusiness(configuration.GetConnectionString("VideoContext").ToString());
            return productoBusiness.GetAll();
        }
    }
}
