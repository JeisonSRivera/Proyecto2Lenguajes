using System;
using System.Collections.Generic;
using System.Text;

namespace VentasJHJ.Model.Domain
{
    public class Orden
    {
        private int idOrden;
        private string fechaOrden;
        private string fechaEnvio;
        private float valorTotal;
        private float valorEnvio;
        private DetalleOrden detalleOrden;
        private Empleado empleado;
        private Cliente cliente;

        public Orden()
        {
            this.DetalleOrden = DetalleOrden;
            this.empleado = new Empleado();
            this.cliente = new Cliente();
        }

        public Orden(int idOrden, string fechaOrden, string fechaEnvio, float valorTotal, 
            float valorEnvio, DetalleOrden detalleOrden, Empleado empleado, Cliente cliente)
        {
            this.idOrden = idOrden;
            this.fechaOrden = fechaOrden;
            this.fechaEnvio = fechaEnvio;
            this.valorTotal = valorTotal;
            this.valorEnvio = valorEnvio;
            this.detalleOrden = detalleOrden;
            this.empleado = empleado;
            this.cliente = cliente;
        }

        public int IdOrden { get => idOrden; set => idOrden = value; }
        public string FechaOrden { get => fechaOrden; set => fechaOrden = value; }
        public string FechaEnvio { get => fechaEnvio; set => fechaEnvio = value; }
        public float ValorTotal { get => valorTotal; set => valorTotal = value; }
        public float ValorEnvio { get => valorEnvio; set => valorEnvio = value; }
        public DetalleOrden DetalleOrden { get => detalleOrden; set => detalleOrden = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        public Cliente Cliente1 { get => cliente; set => cliente = value; }
        internal Empleado Empleado { get => empleado; set => empleado = value; }
    }
}
