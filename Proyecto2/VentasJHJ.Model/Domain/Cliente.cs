using System;
using System.Collections.Generic;
using System.Text;

namespace VentasJHJ.Model.Domain
{
    public class Cliente
    {
        private int idCliente;
        private String nombreCliente;
        private String apellidosCliente;
        private String cedulaCliente;
        private String emailCliente;
        private String passwordCliente;
        private String direccionCliente;
        private String telefonoCliente;
        List<Orden> ordenes;

        public Cliente()
        {
            this.ordenes = new List<Orden>();
        }

        public Cliente(string nombreCliente, string apellidosCliente, string cedulaCliente, string emailCliente, 
            string passwordCliente, string direccionCliente, string telefonoCliente)
        {
            this.nombreCliente = nombreCliente;
            this.apellidosCliente = apellidosCliente;
            this.cedulaCliente = cedulaCliente;
            this.emailCliente = emailCliente;
            this.passwordCliente = passwordCliente;
            this.direccionCliente = direccionCliente;
            this.telefonoCliente = telefonoCliente;
        }

        public Cliente(int idCliente, string nombreCliente, string apellidosCliente, string cedulaCliente, string emailCliente, string passwordCliente, string direccionCliente, string telefonoCliente)
        {
            this.idCliente = idCliente;
            this.nombreCliente = nombreCliente;
            this.apellidosCliente = apellidosCliente;
            this.cedulaCliente = cedulaCliente;
            this.emailCliente = emailCliente;
            this.passwordCliente = passwordCliente;
            this.direccionCliente = direccionCliente;
            this.telefonoCliente = telefonoCliente;
        }

        public int IdCliente { get => idCliente; set => idCliente = value; }
        public string NombreCliente { get => nombreCliente; set => nombreCliente = value; }
        public string ApellidosCliente { get => apellidosCliente; set => apellidosCliente = value; }
        public string CedulaCliente { get => cedulaCliente; set => cedulaCliente = value; }
        public string EmailCliente { get => emailCliente; set => emailCliente = value; }
        public string PasswordCliente { get => passwordCliente; set => passwordCliente = value; }
        public string DireccionCliente { get => direccionCliente; set => direccionCliente = value; }
        public string TelefonoCliente { get => telefonoCliente; set => telefonoCliente = value; }
        public List<Orden> Ordenes { get => ordenes; set => ordenes = value; }
    }
}
