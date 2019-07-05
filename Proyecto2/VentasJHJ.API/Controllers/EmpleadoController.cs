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
    [Route("api/empleado")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly IConfiguration configuration;
        EmpleadoBusiness empleadoBusiness;
        public EmpleadoController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        [HttpGet]
        public IEnumerable<Empleado> Get()
        {
            empleadoBusiness = new EmpleadoBusiness(configuration.GetConnectionString("VideoContext").ToString());
            return empleadoBusiness.GetAll();
        }
    }
}
