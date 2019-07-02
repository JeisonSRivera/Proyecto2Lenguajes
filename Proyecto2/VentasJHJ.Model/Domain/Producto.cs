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
        private Categoria categoria;

        public Producto()
        {
            this.Categoria = new Categoria();
        }

        public int IdProducto { get => idProducto; set => idProducto = value; }
        public string NombreProducto { get => nombreProducto; set => nombreProducto = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int CantidadEnStock { get => cantidadEnStock; set => cantidadEnStock = value; }
        public float Precio { get => precio; set => precio = value; }
        public Categoria Categoria { get => categoria; set => categoria = value; }
    }
}
