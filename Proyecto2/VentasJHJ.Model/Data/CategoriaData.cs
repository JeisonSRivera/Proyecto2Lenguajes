using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using VentasJHJ.Model.Domain;

namespace VentasJHJ.Model.Data
{
    public class CategoriaData
    {

        String connectionString;

        public CategoriaData(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Categoria Insertar(Categoria categoria)
        {
            SqlCommand cmdCategoria = new SqlCommand();
            cmdCategoria.CommandText = "VentasJHJ_CategoriaInsert";
            cmdCategoria.CommandType = System.Data.CommandType.StoredProcedure;
            cmdCategoria.Parameters.Add(new SqlParameter("nombre_categoria", categoria.NombreCategoria));
            SqlParameter parIdCategoria = new SqlParameter("id_categoria", System.Data.SqlDbType.Int);
            parIdCategoria.Direction = System.Data.ParameterDirection.Output;
            cmdCategoria.Parameters.Add(parIdCategoria);

            SqlConnection connection = new SqlConnection(connectionString);
            SqlTransaction transaction = null;
            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();
                cmdCategoria.Connection = connection;
                cmdCategoria.Transaction = transaction;
                cmdCategoria.ExecuteNonQuery();
                categoria.IdCategoria = Int32.Parse(cmdCategoria.Parameters["id_categoria"].Value.ToString());
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
            return categoria;
        }

        public List<Categoria> GetAll()
        {
            String sqlProcedure = "VentasJHJ_CategoriaGetAll";
            SqlConnection connection = new SqlConnection(this.connectionString);
            SqlDataAdapter daCategorias = new SqlDataAdapter();
            daCategorias.SelectCommand = new SqlCommand(sqlProcedure, connection);
            daCategorias.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            DataSet dsCategorias = new DataSet();
            daCategorias.Fill(dsCategorias, "Categoria");

            List<Categoria> categorias = new List<Categoria>();
            DataRowCollection rows = dsCategorias.Tables["Categoria"].Rows;
            foreach (DataRow row in rows)
            {
                categorias.Add(new Categoria(Int32.Parse(row["id_categoria"].ToString()), row["nombre_categoria"].ToString()));
            }
            return categorias;
        }
    }
}
