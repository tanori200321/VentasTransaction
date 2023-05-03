using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class Existencias
    {
        public int Id { get; set; }
        public decimal Existencia { get; set; }
        public int ProductoId { get; set; }

        // Datos Tabla Clientes //
        public SqlDataAdapter ObtenerExistencias()
        {
            try
            {
                string query = "SELECT * FROM Existencias";
                SqlDataAdapter clientes = new SqlDataAdapter(query, Conexion.ConnectionString);

                return clientes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ActualizarExistencia(int id, decimal valor)
        {
            try
            {
                // Query para Actualizar una Existencia //
                string query = "UPDATE Existencias SET Existencia = @Valor WHERE Id= @Id";

                using (SqlConnection con = new SqlConnection(Conexion.ConnectionString))
                {
                    con.Open();
                    SqlTransaction transaction = con.BeginTransaction();
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Transaction = transaction;

                            cmd.Parameters.AddWithValue("@Valor", valor);
                            cmd.Parameters.AddWithValue("@Id", id);

                            cmd.ExecuteNonQuery();
                        }
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void AgregarExistenciaEnCero(SqlConnection con, SqlTransaction transaction, int productoId)
        {
            string query = "INSERT INTO Existencias (ProductoId, Existencia) " +
                "VALUES (@ProductoId, @Existencia)";
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Transaction = transaction;
                    cmd.Parameters.AddWithValue("@ProductoId", productoId);
                    cmd.Parameters.AddWithValue("@Existencia", 0);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}