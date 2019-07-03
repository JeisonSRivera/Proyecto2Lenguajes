using System;
using System.Collections.Generic;
using System.Text;
using VentasJHJ.Model.Data;
using VentasJHJ.Model.Domain;

namespace VentasJHJ.Model.Business
{
    public class OrdenBusiness
    {
        String connectionString;
        OrdenData ordenData;

        public OrdenBusiness(string connectionString)
        {
            this.connectionString = connectionString;
            this.ordenData = new OrdenData(connectionString);
        }
        public Orden Insertar(Orden orden)
        {
            return ordenData.Insertar(orden);
        }
    }
}
