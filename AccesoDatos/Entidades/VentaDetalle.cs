using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class VentaDetalle
    {
        public int Id { get; set; }
        public int VentaId { get; set; }
        public int ProductoId { get; set; }
        public decimal Cantidad { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Importe { get; set; }


        public SqlDataAdapter ObtenerVentaDetalle()
        {
            try
            {
                string query = "SELECT * FROM VentasDetalles";
                SqlDataAdapter clientes = new SqlDataAdapter(query, Conexion.ConnectionString);

                return clientes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void GuardarConceptos(SqlConnection con, SqlTransaction transaction, VentaDetalle concepto)
        {
            try
            {
                string query = "INSERT INTO VentasDetalle" +
                    "(VentaId,ProductoId,Cantidad,Descripcion,PrecioUnitario,Importe) " +
                    "VALUES" +
                    "(@VentaId,@ProductoId,@Cantidad,@Descripcion,@PrecioUnitario,@Importe)";


                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Transaction = transaction;

                    cmd.Parameters.AddWithValue("@VentaId", concepto.VentaId);
                    cmd.Parameters.AddWithValue("@ProductoId", concepto.ProductoId);
                    cmd.Parameters.AddWithValue("@Cantidad", concepto.Cantidad);
                    cmd.Parameters.AddWithValue("@Descripcion", concepto.Descripcion);
                    cmd.Parameters.AddWithValue("@PrecioUnitario", concepto.PrecioUnitario);
                    cmd.Parameters.AddWithValue("@Importe", concepto.Importe);
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