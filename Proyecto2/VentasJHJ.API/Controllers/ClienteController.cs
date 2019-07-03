﻿using System;
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
    [Route("api/clientes")]
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

        [HttpPost()]
        public void Insert([FromBody] Cliente cliente)
        {
            clienteBusiness = new ClienteBusiness(configuration.GetConnectionString("VideoContext").ToString());
            clienteBusiness.Insertar(cliente);
        }

        [HttpPost("{cliente}")]
        public void Update(Cliente cliente)
        {
            clienteBusiness = new ClienteBusiness(configuration.GetConnectionString("VideoContext").ToString());
            clienteBusiness.Editar(cliente);
        }

        [HttpGet("{id}",Name= "Delete")]
        public void Delete(int id)
        {
            clienteBusiness = new ClienteBusiness(configuration.GetConnectionString("VideoContext").ToString());
            clienteBusiness.Eliminar(id);
        }

        [HttpGet("{idCliente}", Name = "GetById")]
        public IEnumerable<Cliente> GetById(int id)
        {
            clienteBusiness = new ClienteBusiness(configuration.GetConnectionString("VideoContext").ToString());
            return clienteBusiness.GetById(id);
        }
    }
    
}