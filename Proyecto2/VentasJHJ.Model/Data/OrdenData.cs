using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using VentasJHJ.Model.Domain;

namespace VentasJHJ.Model.Data
{
    public class OrdenData
    {
        String connectionString;

        public OrdenData(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Orden Insertar(Orden orden)
        {
            SqlCommand cmdOrden = new SqlCommand();
            cmdOrden.CommandText = "VentasJHJ_ConfirmarOrden";
            cmdOrden.CommandType = System.Data.CommandType.StoredProcedure;
            cmdOrden.Parameters.Add(new SqlParameter("id_cliente", orden.Cliente.IdCliente));
            cmdOrden.Parameters.Add(new SqlParameter("impuesto", orden.DetalleOrden.Impuesto));
            SqlConnection connection = new SqlConnection(connectionString);
            SqlTransaction transaction = null;
            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();
                cmdOrden.Connection = connection;
                cmdOrden.Transaction = transaction;
                cmdOrden.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (SqlException ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                throw ex;
            }//catch
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }//finaly
            return orden;
        }

    }
}
