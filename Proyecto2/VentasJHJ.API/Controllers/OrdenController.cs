using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using VentasJHJ.Model.Business;
using VentasJHJ.Model.Data;
using VentasJHJ.Model.Domain;

namespace VentasJHJ.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Orden")]
    [ApiController]
    public class OrdenController : ControllerBase
    {
        private readonly IConfiguration configuration;
        OrdenBusiness ordenBusiness;
        public OrdenController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet]
        public IEnumerable<Orden> Get()
        {
            return null;
        }

        // GET: api/Orden/5
        [HttpGet("{Orden}", Name = "insert")]
        public void Get(Orden orden)
        {
            ordenBusiness = new OrdenBusiness(configuration.GetConnectionString("VideoContext").ToString());
            ordenBusiness.Insertar(orden);
        }

        // POST: api/Orden
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Orden/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
