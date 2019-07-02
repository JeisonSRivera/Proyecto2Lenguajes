﻿using System;
using System.Collections.Generic;
using System.Text;

namespace VentasJHJ.Model.Domain
{
    public class ProductoCliente
    {
        private float impuesto;
        private int cantidad;
        private float descuento;
        private float precioUnitario;
        private float precioSubtotal;
        private List<Producto> productos;
        private Cliente cliente;

        public ProductoCliente()
        {
            this.productos = new List<Producto>();
        }

        public float Impuesto { get => impuesto; set => impuesto = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public float Descuento { get => descuento; set => descuento = value; }
        public float PrecioUnitario { get => precioUnitario; set => precioUnitario = value; }
        public float PrecioSubtotal { get => precioSubtotal; set => precioSubtotal = value; }
        public List<Producto> Productos { get => productos; set => productos = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
    }
}