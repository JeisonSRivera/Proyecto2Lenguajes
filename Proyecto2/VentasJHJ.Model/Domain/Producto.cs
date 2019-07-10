using System;
using System.Collections.Generic;
using System.Text;

namespace VentasJHJ.Model.Domain
{
    public class Producto
    {
        private int idProducto;
        private String nombreProducto;
        private String descripcion;
        private int cantidadEnStock;
        private float precio;
        private int idCategoria;
        public Producto()
        {
        }

        public Producto(int idProducto, string nombreProducto, string descripcion, int cantidadEnStock, float precio, int idCategoria)
        {
            this.idProducto = idProducto;
            this.nombreProducto = nombreProducto;
            this.descripcion = descripcion;
            this.cantidadEnStock = cantidadEnStock;
            this.precio = precio;
            this.idCategoria = idCategoria;
        }

        public int IdProducto { get => idProducto; set => idProducto = value; }
        public string NombreProducto { get => nombreProducto; set => nombreProducto = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int CantidadEnStock { get => cantidadEnStock; set => cantidadEnStock = value; }
        public float Precio { get => precio; set => precio = value; }
        public int IdCategoria { get => idCategoria; set => idCategoria = value; }
    }
}
