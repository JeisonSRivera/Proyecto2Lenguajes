using System;
using System.Collections.Generic;
using System.Text;

namespace VentasJHJ.Model.Domain
{
    public class ProductoPosOrden
    {
        private int idDetalleOrden;
        private int cantidad;
        private float impuesto;
        private float precioUnitario;
        private List<Producto> productos;
        private float descuento;
        private float precioSubtotal;
        public ProductoPosOrden()
        {
            this.Productos = new List<Producto>();
        }

        public int IdDetalleOrden { get => idDetalleOrden; set => idDetalleOrden = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public float PrecioUnitario { get => precioUnitario; set => precioUnitario = value; }
        public List<Producto> Productos { get => productos; set => productos = value; }
        public float Descuento { get => descuento; set => descuento = value; }
        public float PrecioSubtotal { get => precioSubtotal; set => precioSubtotal = value; }
        public float Impuesto { get => impuesto; set => impuesto = value; }
    }
}
