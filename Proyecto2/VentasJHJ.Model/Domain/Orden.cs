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

        public Orden()
        {
            this.DetalleOrden = DetalleOrden;
        }

        public int IdOrden { get => idOrden; set => idOrden = value; }
        public string FechaOrden { get => fechaOrden; set => fechaOrden = value; }
        public string FechaEnvio { get => fechaEnvio; set => fechaEnvio = value; }
        public float ValorTotal { get => valorTotal; set => valorTotal = value; }
        public float ValorEnvio { get => valorEnvio; set => valorEnvio = value; }
        internal DetalleOrden DetalleOrden { get => detalleOrden; set => detalleOrden = value; }
    }
}
