using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using VentasJHJ.Model.Domain;

namespace VentasJHJ.Model.Data
{
    public class EmpleadoData
    {
        String connectionString;

        public EmpleadoData(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public List<Empleado> GetAll()
        {
            String sqlProcedure = "VentasJHJ_EmpleadoGetAll";
            SqlConnection connection = new SqlConnection(this.connectionString);
            SqlDataAdapter daEmpleados = new SqlDataAdapter();
            daEmpleados.SelectCommand = new SqlCommand(sqlProcedure, connection);
            daEmpleados.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            DataSet dsEmpelados = new DataSet();
            daEmpleados.Fill(dsEmpelados, "Empleado");

            List<Empleado> empleados = new List<Empleado>();
            DataRowCollection rows = dsEmpelados.Tables["Empleado"].Rows;
            foreach (DataRow row in rows)
            {
                empleados.Add(new Empleado(Int32.Parse(row["id_empleado"].ToString()), row["nombre_empleado"].ToString(),
                    row["apellidos_empleado"].ToString(), row["email"].ToString()));
            }
            return empleados;
        }
    }
}
