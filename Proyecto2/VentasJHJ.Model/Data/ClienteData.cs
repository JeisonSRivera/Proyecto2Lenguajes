﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using VentasJHJ.Model.Domain;

namespace VentasJHJ.Model.Data
{
    public class ClienteData
    {
        String connectionString;

        public ClienteData(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Cliente Insertar(Cliente cliente)
        {
            SqlCommand cmdCliente = new SqlCommand();
            cmdCliente.CommandText = "VentasJHJ_ClienteInsert";
            cmdCliente.CommandType = System.Data.CommandType.StoredProcedure;
            cmdCliente.Parameters.Add(new SqlParameter("nombre_cliente", cliente.NombreCliente));
            cmdCliente.Parameters.Add(new SqlParameter("apellidos_cliente", cliente.ApellidosCliente));
            cmdCliente.Parameters.Add(new SqlParameter("cedula_cliente", cliente.CedulaCliente));
            cmdCliente.Parameters.Add(new SqlParameter("email_cliente", cliente.EmailCliente));
            cmdCliente.Parameters.Add(new SqlParameter("direccion_cliente", cliente.DireccionCliente));
            cmdCliente.Parameters.Add(new SqlParameter("telefono_cliente", cliente.TelefonoCliente));
            SqlParameter parIdCliente = new SqlParameter("id_cliente", System.Data.SqlDbType.Int);
            parIdCliente.Direction = System.Data.ParameterDirection.Output;
            cmdCliente.Parameters.Add(parIdCliente);

            SqlConnection connection = new SqlConnection(connectionString);
            SqlTransaction transaction = null;
            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();
                cmdCliente.Connection = connection;
                cmdCliente.Transaction = transaction;
                cmdCliente.ExecuteNonQuery();
                cliente.IdCliente = Int32.Parse(cmdCliente.Parameters["id_cliente"].Value.ToString());
                transaction.Commit();
            }
            catch (SqlException ex)
            {
                if (transaction!=null)
                {
                    transaction.Rollback();
                }
                throw ex;
            }//catch
            finally
            {
                if (connection!=null)
                {
                    connection.Close();
                }
            }//finaly
            return cliente;
        }

        public void Eliminar(int idCliente)
        {
            SqlCommand cmdCliente = new SqlCommand();
            cmdCliente.CommandText = "VentasJHJ_ClienteDelete";
            cmdCliente.CommandType = System.Data.CommandType.StoredProcedure;
            cmdCliente.Parameters.Add(new SqlParameter("id", idCliente));
            SqlConnection connection = new SqlConnection(connectionString);
            SqlTransaction transaction = null;
            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();
                cmdCliente.Connection = connection;
                cmdCliente.Transaction = transaction;
                cmdCliente.ExecuteNonQuery();
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
            }
        }
    

        public void Editar(Cliente cliente)
        {
            SqlCommand cmdCliente = new SqlCommand();
            cmdCliente.CommandText = "VentasJHJ_ClienteUpdate";
            cmdCliente.CommandType = System.Data.CommandType.StoredProcedure;
            cmdCliente.Parameters.Add(new SqlParameter("id_cliente", cliente.IdCliente));
            cmdCliente.Parameters.Add(new SqlParameter("nombre_cliente", cliente.NombreCliente));
            cmdCliente.Parameters.Add(new SqlParameter("apellidos_cliente", cliente.ApellidosCliente));
            cmdCliente.Parameters.Add(new SqlParameter("cedula_cliente", cliente.CedulaCliente));
            cmdCliente.Parameters.Add(new SqlParameter("email_cliente", cliente.EmailCliente));
            cmdCliente.Parameters.Add(new SqlParameter("direccion_cliente", cliente.DireccionCliente));
            cmdCliente.Parameters.Add(new SqlParameter("telefono_cliente", cliente.TelefonoCliente));

            SqlConnection connection = new SqlConnection(connectionString);
            SqlTransaction transaction = null;
            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();
                cmdCliente.Connection = connection;
                cmdCliente.Transaction = transaction;
                cmdCliente.ExecuteNonQuery();
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

        public List<Cliente> GetAll()
        {
            String sqlProcedure = "VentasJHJ_ClienteGetAll";
            SqlConnection connection = new SqlConnection(this.connectionString);
            SqlDataAdapter daClientes = new SqlDataAdapter();
            daClientes.SelectCommand = new SqlCommand(sqlProcedure, connection);
            daClientes.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            DataSet dsClientes = new DataSet();
            daClientes.Fill(dsClientes, "Cliente");

            List<Cliente> clientes = new List<Cliente>();
            DataRowCollection rows = dsClientes.Tables["Cliente"].Rows;
            foreach (DataRow row in rows)
            {
                clientes.Add(new Cliente(Int32.Parse(row["id_cliente"].ToString()), row["nombre_cliente"].ToString(),
                    row["apellidos_cliente"].ToString(), row["cedula_cliente"].ToString(), row["email_cliente"].ToString(),
                    row["direccion_cliente"].ToString(), row["telefono_cliente"].ToString()));
            }
            return clientes;
        }

        public List<Cliente> GetById(int idCliente)
        {
            String sqlSelect = "Select id_cliente,nombre_cliente,apellidos_cliente,cedula_cliente, email_cliente,direccion_cliente, telefono_cliente " +
                "from Cliente where id_cliente like '%" + idCliente + "%'";

            SqlDataAdapter daClientes = new SqlDataAdapter(sqlSelect, new SqlConnection(connectionString));
            DataSet dsCliente = new DataSet();
            daClientes.Fill(dsCliente, "Cliente");

            Dictionary<Int32, Cliente> dictionary = new Dictionary<Int32, Cliente>();
            Cliente cliente = null;
            foreach (DataRow row in dsCliente.Tables["Cliente"].Rows)
            {
                Int32 id = Int32.Parse(row["id_cliente"].ToString());
               // if (dictionary.ContainsKey(id) == false)
               // {
                    cliente = new Cliente();
                    cliente.IdCliente = id;
                    cliente.NombreCliente = row["nombre_cliente"].ToString();
                    cliente.ApellidosCliente = row["apellidos_cliente"].ToString();
                    cliente.CedulaCliente = row["cedula_cliente"].ToString();
                    cliente.TelefonoCliente = row["telefono_cliente"].ToString();
                    cliente.EmailCliente = row["email_cliente"].ToString();
                    cliente.DireccionCliente = row["direccion_cliente"].ToString();
                    dictionary.Add(id, cliente);
               // } // if
            } // foreach
            return dictionary.Values.ToList<Cliente>();
        } // GetAllMovies

        public List<Cliente> GetByName(String nombreCliente)
        {
            String sqlSelect = "Select id_cliente,nombre_cliente,apellidos_cliente,cedula_cliente, email_cliente,direccion_cliente, telefono_cliente " +
                "from Cliente where nombre_cliente like '%" + nombreCliente + "%'";

            SqlDataAdapter daClientes = new SqlDataAdapter(sqlSelect, new SqlConnection(connectionString));
            DataSet dsCliente = new DataSet();
            daClientes.Fill(dsCliente, "Cliente");

            Dictionary<Int32, Cliente> dictionary = new Dictionary<Int32, Cliente>();
            foreach (DataRow row in dsCliente.Tables["Cliente"].Rows)
            {
                Int32 id = Int32.Parse(row["id_cliente"].ToString());
                // if (dictionary.ContainsKey(id) == false)
                // {
                Cliente cliente = new Cliente();
                cliente.IdCliente = id;
                cliente.NombreCliente = row["nombre_cliente"].ToString();
                cliente.ApellidosCliente = row["apellidos_cliente"].ToString();
                cliente.CedulaCliente = row["cedula_cliente"].ToString();
                cliente.TelefonoCliente = row["telefono_cliente"].ToString();
                cliente.EmailCliente = row["email_cliente"].ToString();
                cliente.DireccionCliente = row["direccion_cliente"].ToString();
                dictionary.Add(id, cliente);
                // } // if
            } // foreach
            return dictionary.Values.ToList<Cliente>();
        } // GetAllClientes
    }
}