using System;
using System.Collections.Generic;
using System.Text;
using VentasJHJ.Model.Data;
using VentasJHJ.Model.Domain;

namespace VentasJHJ.Model.Business
{
    class ProdctoBusiness
    {
        String connectionString;
        ProductoData productoData;

        public ProdctoBusiness(string connectionString)
        {
            this.connectionString = connectionString;
            this.productoData = new ProductoData(connectionString);
        }
        public Producto Insertar(Producto producto)
        {
            return productoData.Insertar(producto);
        }
        public List<Producto> GetByName(String nombre)
        {
            return productoData.GetByName(nombre);
        }
    }
}
