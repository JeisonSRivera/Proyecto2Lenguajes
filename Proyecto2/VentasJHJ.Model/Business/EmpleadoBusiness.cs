using System;
using System.Collections.Generic;
using System.Text;
using VentasJHJ.Model.Data;
using VentasJHJ.Model.Domain;

namespace VentasJHJ.Model.Business
{
    public class EmpleadoBusiness
    {
        EmpleadoData categoriaData;
        String connectionString;

        public EmpleadoBusiness(string connectionString)
        {
            this.connectionString = connectionString;
            this.categoriaData = new EmpleadoData(connectionString);
        }
        public List<Empleado> GetAll()
        {
            return categoriaData.GetAll();
        }
    }
}
