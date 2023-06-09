﻿using AccesoDatos.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class Venta
    {
        public int Id { get; set; }
        public int Folio { get; set; }
        public DateTime Fecha { get; set; }
        public int ClienteId { get; set; }
        public decimal Total { get; set; }
        public List<VentaDetalle> Conceptos { get; set; } = new List<VentaDetalle>();

        public SqlDataAdapter ObtenerVenta()
        {
            try
            {
                string query = "SELECT * FROM Ventas";
                SqlDataAdapter clientes = new SqlDataAdapter(query, Conexion.ConnectionString);

                return clientes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void crearVenta(Venta venta)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.ConnectionString))
                {
                    SqlTransaction transaction;
                    con.Open();
                    transaction = con.BeginTransaction();

                    try
                    {
                        Folios folio = new Folios();
                        int folioActual = folio.ObtenerFolio(con, transaction);

                        venta.Folio = folioActual + 1;
                        venta.Fecha = DateTime.Now;

                        string query = "INSERT INTO Ventas " +
                            "(Folio,Fecha,ClienteId,Total) " +
                            "VALUES " +
                            "(@Folio,@Fecha,@ClienteId,@Total);select scope_identity()";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Transaction = transaction;
                            cmd.Parameters.AddWithValue("@Folio", venta.Folio);
                            cmd.Parameters.AddWithValue("@Fecha", venta.Fecha);
                            cmd.Parameters.AddWithValue("@ClienteId", venta.ClienteId);
                            cmd.Parameters.AddWithValue("@Total", venta.Total);

                            string ejecutaQuery = cmd.ExecuteScalar().ToString();
                            bool sePudoConvertir = int.TryParse(ejecutaQuery, out int idVenta);

                            if (!sePudoConvertir)
                            {
                                throw new Exception("Ocurrio un error al obtener el id de la venta");
                            }
                            venta.Id = idVenta;
                        }

                        foreach (VentaDetalle concepto in venta.Conceptos)
                        {
                            concepto.VentaId = venta.Id;
                            concepto.GuardarConceptos(con, transaction, concepto);

                            Existencias existencia = new Existencias();
                            existencia.Id = concepto.ProductoId;
                            existencia.Existencia = concepto.Cantidad - concepto.Importe;
                            existencia.ActualizarExistencia(existencia.Id, existencia.Existencia);
                        }

                        folio.ActualizarFolio(con, transaction);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception(ex.Message);
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

