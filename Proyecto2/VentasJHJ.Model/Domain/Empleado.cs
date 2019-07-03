using System;
using System.Collections.Generic;
using System.Text;

namespace VentasJHJ.Model.Domain
{
    public class Empleado
    {
        private string nombre, apellidos,email;
        List<Orden> ordenes;

        public Empleado()
        {
            this.ordenes = new List<Orden>();
        }

        public Empleado(string nombre, string apellidos, string email, List<Orden> ordenes)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.email = email;
            this.ordenes = new List<Orden>();
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apeliidos { get => apellidos; set => apellidos = value; }
        public string Email { get => email; set => email = value; }
        public List<Orden> Ordenes { get => ordenes; set => ordenes = value; }
    }
}
