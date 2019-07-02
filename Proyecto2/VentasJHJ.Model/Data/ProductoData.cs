using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using VentasJHJ.Model.Domain;

namespace VentasJHJ.Model.Data
{
    public class ProductoData
    {

        String connectionString;

        public ProductoData(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Producto Insertar(Producto producto)
        {
            SqlCommand cmdProducto = new SqlCommand();
            cmdProducto.CommandText = "VentasJHJ_ProductoInsert";
            cmdProducto.CommandType = System.Data.CommandType.StoredProcedure;
            cmdProducto.Parameters.Add(new SqlParameter("nombre_producto", producto.NombreProducto));
            cmdProducto.Parameters.Add(new SqlParameter("descripcion", producto.Descripcion));
            cmdProducto.Parameters.Add(new SqlParameter("cantidad_stock", producto.CantidadEnStock));
            cmdProducto.Parameters.Add(new SqlParameter("precio", producto.Precio));
            SqlParameter parIdProoducto = new SqlParameter("id_producto", System.Data.SqlDbType.Int);
            parIdProoducto.Direction = System.Data.ParameterDirection.Output;
            cmdProducto.Parameters.Add(parIdProoducto);

            // CREAR EL SEGUNDO COMMAND
            SqlCommand cmdCategoriaProducto = new SqlCommand();
            cmdCategoriaProducto.CommandText = "VentasJHJ_Categoria_ProductoInsert";
            cmdCategoriaProducto.CommandType = System.Data.CommandType.StoredProcedure;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlTransaction transaction = null;
            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();
                cmdCategoriaProducto.Connection = connection;
                cmdCategoriaProducto.Transaction = transaction;
                cmdProducto.Connection = connection;
                cmdProducto.Transaction = transaction;
                cmdProducto.ExecuteNonQuery();
                producto.IdProducto = Int32.Parse(cmdProducto.Parameters["id_producto"].Value.ToString());
                Categoria categoria = producto.Categoria;

                cmdCategoriaProducto.Parameters.Add(new SqlParameter("id_producto", producto.IdProducto));
                cmdCategoriaProducto.Parameters.Add(new SqlParameter("id_categoria", categoria.IdCategoria));
                cmdCategoriaProducto.ExecuteNonQuery();
                cmdCategoriaProducto.Parameters.Clear();
                
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
            return producto;
        }

        public List<Producto> GetByName(String nombre)
        {

            String sqlSelect = "select p.id_producto, nombre_producto, descripcion, cantidad_stock, precio, c.id_categoria," +
                " c.nombre_categoria from Producto p , Categoria c, Producto_Categoria pc " +
                " where p.id_producto = pc.id_producto and c.id_categoria = pc.id_categoria and p.nombre_producto like '%"+
                nombre+ "%'";
            SqlDataAdapter daProductos = new SqlDataAdapter(sqlSelect, new SqlConnection(connectionString));

            DataSet dsProductos = new DataSet();
            daProductos.Fill(dsProductos, "Producto");

            Dictionary<Int32, Producto> dictionary = new Dictionary<Int32, Producto>();
            Producto producto = null;
            foreach (DataRow row in dsProductos.Tables["Producto"].Rows)
            {
                Int32 id = Int32.Parse(row["id_producto"].ToString());
                if (dictionary.ContainsKey(id) == false)
                {
                    producto = new Producto();
                    producto.IdProducto = id;
                    producto.NombreProducto = row["nombre_producto"].ToString();
                    producto.Descripcion = row["descripcion"].ToString();
                    producto.CantidadEnStock = Int32.Parse(row["cantidad_stock"].ToString());
                    producto.Precio = float.Parse(row["precio"].ToString());
                    producto.Categoria.IdCategoria = Int32.Parse(row["id_categoria"].ToString());
                    producto.Categoria.NombreCategoria = row["nombre_categoria"].ToString();
                    dictionary.Add(id, producto);
                } // if
                int categoriaId = Int32.Parse(row["id_categoria"].ToString());
                if (categoriaId > 0)
                {
                    Categoria categoria = new Categoria();
                    categoria.IdCategoria = categoriaId;
                    categoria.NombreCategoria = row["nombre_categoria"].ToString();
                    producto.Categoria=categoria;
                }
            } // foreach
            return dictionary.Values.ToList<Producto>();
        } // GetAllMovies

    }
}
