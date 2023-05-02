using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccesoDatos
{
    public class Productos
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioUnitario { get; set; }

        // Metodos De Producto (Crear, Actualizar, Eliminar) //

        // Datos Tabla Clientes //
        public SqlDataAdapter ObtenerProductos()
        {
            try
            {
                string query = "SELECT * FROM Productos";
                SqlDataAdapter productos = new SqlDataAdapter(query, Conexion.ConnectionString);

                return productos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Crear Producto //
        public void CrearProducto(Productos producto)
        {
            try
            {
                string query = "INSERT INTO Productos" +
                    "(Descripcion,PrecioUnitario) " +
                    "VALUES" +
                    "(@Descripcion,@PrecioUnitario);select scope_identity()";

                using (SqlConnection con = new SqlConnection(Conexion.ConnectionString))
                {
                    SqlTransaction transaction;
                    con.Open();
                    transaction = con.BeginTransaction();
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Transaction = transaction;

                            cmd.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                            cmd.Parameters.AddWithValue("@PrecioUnitario", producto.PrecioUnitario);


                            if (!int.TryParse(cmd.ExecuteScalar().ToString(), out int idProducto))
                            {
                                throw new Exception("Ocurrio un error al obtener el id del Producto");
                            }
                            Console.WriteLine("ID: " + idProducto);
                            Existencias existencia = new Existencias();
                            existencia.AgregarExistenciaEnCero(con, transaction, idProducto);
                        }
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception(ex.Message);
                    }
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        // Actualizar Producto //
        public void ActualizarProducto(Productos producto)
        {
            try
            {
                string query = "UPDATE Productos SET Descripcion = @Descripcion, PrecioUnitario = @PrecioUnitario WHERE Id = @Id";

                using (SqlConnection con = new SqlConnection(Conexion.ConnectionString))
                {
                    SqlTransaction transaction;
                    con.Open();
                    transaction = con.BeginTransaction();
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Transaction = transaction;

                            cmd.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                            cmd.Parameters.AddWithValue("@PrecioUnitario", producto.PrecioUnitario);
                            cmd.Parameters.AddWithValue("@Id", producto.Id);

                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected == 0)
                            {
                                throw new Exception("El producto no existe");
                            }
                        }
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception(ex.Message);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void EliminarProducto(int id)
        {
            try
            {
                string query = "DELETE FROM Existencias WHERE ProductoId = @Id; DELETE FROM Productos where Id = @Id";

                using (SqlConnection con = new SqlConnection(Conexion.ConnectionString))
                {
                    con.Open();
                    SqlTransaction transaction = con.BeginTransaction();

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        try
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Transaction = transaction;

                            cmd.Parameters.AddWithValue("@Id", id);

                            cmd.ExecuteNonQuery();
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw new Exception(ex.Message);
                        }

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
