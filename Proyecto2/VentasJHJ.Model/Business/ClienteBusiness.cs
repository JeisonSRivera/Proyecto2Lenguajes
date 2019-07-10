using System;
using System.Collections.Generic;
using System.Text;
using VentasJHJ.Model.Data;
using VentasJHJ.Model.Domain;

namespace VentasJHJ.Model.Business
{

    public class ClienteBusiness
    {
     ClienteData clienteData;
     String connectionString;

       public ClienteBusiness (string connectionString)
        {
            this.connectionString = connectionString;
            this.clienteData = new ClienteData(connectionString);
        }
        public void Insertar(Cliente c)
        {
            clienteData.Insertar(c);
        }
        public void Eliminar(int id)
        {
            clienteData.Eliminar(id);
        }
        public void Editar(Cliente c)
        {
            clienteData.Editar(c);
        }
        public List<Cliente> GetAll()
        {
            return clienteData.GetAll();
        }
        public List<Cliente> GetByNombre(String nombreCliente)
        {
            return clienteData.GetByName(nombreCliente);
        }
    }
}
