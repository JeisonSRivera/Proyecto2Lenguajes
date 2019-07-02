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

        public PosOrden Insertar(PosOrden orden, ProductoCliente productoCliente)
        {
            InsertarProductoCliente(productoCliente);
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

        public void InsertarProductoCliente(ProductoCliente productoCliente)
        {
            SqlCommand cmdProductoCliente = new SqlCommand();
            cmdProductoCliente.CommandText = "VentasJHJ_Producto_ClienteInsert";
            cmdProductoCliente.CommandType = System.Data.CommandType.StoredProcedure;

            cmdProductoCliente.Parameters.Add(new SqlParameter("@id_cliente", productoCliente.Cliente.IdCliente));
            cmdProductoCliente.Parameters.Add(new SqlParameter("@impuesto", productoCliente.Impuesto));
            cmdProductoCliente.Parameters.Add(new SqlParameter("@cantidad", productoCliente.Cantidad));
            cmdProductoCliente.Parameters.Add(new SqlParameter("@descuento", productoCliente.Descuento));
            cmdProductoCliente.Parameters.Add(new SqlParameter("@precio_unitario", productoCliente.PrecioUnitario));
            cmdProductoCliente.Parameters.Add(new SqlParameter("@precio_subtotal", productoCliente.PrecioSubtotal));
            foreach (Producto item in productoCliente.Productos)
            {
                cmdProductoCliente.Parameters.Add(new SqlParameter("@id_producto", item.IdProducto));
            }
            SqlConnection connection = new SqlConnection(connectionString);
            SqlTransaction transaction = null;
            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();
                cmdProductoCliente.Connection = connection;
                cmdProductoCliente.Transaction = transaction;
                cmdProductoCliente.ExecuteNonQuery();
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
        }

    }
}
