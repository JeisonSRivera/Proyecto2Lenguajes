using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using VentasJHJ.Model.Business;
using VentasJHJ.Model.Data;
using VentasJHJ.Model.Domain;

namespace VentasJHJ.API.Controllers
{
    [Produces("application/json")]
    [Route("api/clientes")]
    [EnableCors("AllowOrigin")]
    public class GeneroController : Controller
    {
        private readonly IConfiguration configuration;
        ClienteBusiness clienteBusiness;
        public GeneroController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        // GET: api/clientes
        [HttpGet]
        public IEnumerable<Cliente> Get()
        {
          clienteBusiness =new ClienteBusiness(configuration.GetConnectionString("VideoContext").ToString());
            return clienteBusiness.GetAll();
        }

        [HttpPost("{cliente}")]
        public Cliente Post([FromBody]Cliente cliente)
        {
            ClienteData clienteData =
              new ClienteData(configuration.GetConnectionString("VideoContext").ToString());
            return clienteData.Insertar(cliente);
        }

        [HttpPut("{cliente}")]
        public void Put([FromBody]Cliente cliente)
        {
            ClienteData clienteData =
               new ClienteData(configuration.GetConnectionString("VideoContext").ToString());
            clienteData.Editar(cliente);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public HttpResponseMessage delete(int id)
        {
            try
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                clienteBusiness = new ClienteBusiness(configuration.GetConnectionString("VideoContext").ToString());
                clienteBusiness.Eliminar(id);
                return response;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadGateway);
            }
        }

        [HttpGet("{nombreCliente}", Name ="get")]
        public IEnumerable<Cliente> GetByNombre(String nombreCliente)
        {
            clienteBusiness = new ClienteBusiness(configuration.GetConnectionString("VideoContext").ToString());
            return clienteBusiness.GetByNombre(nombreCliente);
        }


    }
    
}