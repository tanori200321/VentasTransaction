using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class Clientes
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        // Metodos De Cliente (Crear, Actualizar, Eliminar) //

        // Datos Tabla Clientes //
        public SqlDataAdapter ObtenerClientes()
        {
            try
            {
                string query = "SELECT * FROM Clientes";
                SqlDataAdapter clientes = new SqlDataAdapter(query, Conexion.ConnectionString);

                return clientes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        // Crear Cliente //
        public void CrearCliente(Clientes cliente)
        {
            try
            {
                // Query para insertar un cliente nuevo //
                string query = "INSERT INTO Clientes" +
                    "(Nombre) " +
                    "VALUES" +
                    "(@Nombre)";

                using (SqlConnection con = new SqlConnection(Conexion.ConnectionString))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                        cmd.ExecuteNonQuery();
                    }

                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        // Eliminar Cliente //
        public void EliminarCliente(int id)
        {
            try
            {
                // Query para Borrar un cliente //
                string query = "DELETE FROM Clientes where Id = @Id";

                using (SqlConnection con = new SqlConnection(Conexion.ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("@Id", id);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Actualizado Cliente //
        public void ActualizarCliente(Clientes cliente)
        {
            try
            {
                // Query para Actualizar un cliente //
                string query = "UPDATE Clientes SET Nombre = @Nombre WHERE Id= @Id";

                using (SqlConnection con = new SqlConnection(Conexion.ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("@Id", cliente.Id);
                        cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                        cmd.ExecuteNonQuery();
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



    }
}
