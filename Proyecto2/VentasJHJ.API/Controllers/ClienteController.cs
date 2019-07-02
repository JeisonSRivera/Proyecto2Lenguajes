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
    [Route("api/clientes")]
    public class GeneroController : Controller
    {
        private readonly IConfiguration configuration;
        public GeneroController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        // GET: api/clientes
        [HttpGet]
        public IEnumerable<Cliente> Get()
        {
            ClienteData clienteData =
                new ClienteData(configuration.GetConnectionString("VideoContext").ToString());
            return clienteData.GetAll();
        }

        [HttpPost("{cliente}")]
        public void Insert(Cliente cliente)
        {
            ClienteData clienteData =
                 new ClienteData(configuration.GetConnectionString("VideoContext").ToString());
                 clienteData.Insertar(cliente);
        }

        [HttpPost("{cliente}")]
        public void Update(Cliente cliente)
        {
            ClienteData clienteData =
                 new ClienteData(configuration.GetConnectionString("VideoContext").ToString());
            clienteData.Editar(cliente);
        }

        [HttpPost("{id}")]
        public void Delete(int id)
        {
            ClienteData clienteData =
                 new ClienteData(configuration.GetConnectionString("VideoContext").ToString());
            clienteData.Eliminar(id);
        }
    }
    
}