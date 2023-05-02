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
        public void ActualizarExistencia(SqlConnection con, SqlTransaction transaction, VentaDetalle concepto)
        {
            string query = "Update Existencias " +
                    "set Existencia = Existencia-@Cantidad " +
                    "where ProductoId = @ProductoId";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = transaction;

                cmd.Parameters.AddWithValue("@ProductoId", concepto.ProductoId);
                cmd.Parameters.AddWithValue("@Cantidad", concepto.Cantidad);
                cmd.ExecuteNonQuery();
            }

        }
        public void AgregarExistenciaEnCero(SqlConnection con, SqlTransaction transaction, int productoId)
        {
            string query = "Insert into Existencias (Existencia, ProductoId) +" +
                "VALUES (0, ProductoId)";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.CommandType = CommandType.Text; cmd.Transaction = transaction;

                cmd.Parameters.AddWithValue("@ProductoId", productoId);
            }

        }


    }

}