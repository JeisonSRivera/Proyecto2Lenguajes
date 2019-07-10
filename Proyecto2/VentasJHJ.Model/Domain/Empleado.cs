using System;
using System.Collections.Generic;
using System.Text;

namespace VentasJHJ.Model.Domain
{
    public class Empleado
    {
        private string nombre;
        private string apellidos;
        private string email;
        private int idEmpleado;

        public Empleado()
        {
        }

        public Empleado(int idEmpleado, string nombre, string apellidos, string email)
        {
            this.nombre = nombre;
            this.idEmpleado = idEmpleado;
            this.apellidos = apellidos;
            this.email = email;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apeliidos { get => apellidos; set => apellidos = value; }
        public string Email { get => email; set => email = value; }
        public int IdEmpleado { get => idEmpleado; set => idEmpleado = value; }
    }
}
