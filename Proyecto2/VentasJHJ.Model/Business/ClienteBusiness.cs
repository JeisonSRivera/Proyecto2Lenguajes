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
    }
}
