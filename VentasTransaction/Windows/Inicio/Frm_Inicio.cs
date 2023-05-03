using AccesoDatos;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using AccesoDatos.Entidades;

namespace VentasTransaction
{
    public partial class Frm_Inicio : Form
    {
        public Frm_Inicio()
        {
            InitializeComponent();

            try
            {
                ObtenerVenta();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        //Mostrar Datos de la tabla //
        private void ObtenerVenta()
        {
            Venta ob = new Venta();
            SqlDataAdapter adapter = ob.ObtenerVenta();
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }


        private void button1_Click(object sender, EventArgs e)
        {
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Frm_Clientes frmclientes = new Frm_Clientes();
            frmclientes.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Frm_Productos productoventana= new Frm_Productos();
            productoventana.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Frm_VDetalles frmvdetalles = new Frm_VDetalles();
            frmvdetalles.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Frm_Existencias frmexistencias = new Frm_Existencias();
            frmexistencias.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
 try
            {
                Venta venta = new Venta();
                venta.ClienteId = 1;

                VentaDetalle producto1 = new VentaDetalle();
                producto1.ProductoId = 1;
                producto1.Cantidad = 1;
                producto1.Descripcion = "Azucar kg";
                producto1.PrecioUnitario = 27.00m;
                producto1.Importe = producto1.Cantidad * producto1.PrecioUnitario;
                venta.Conceptos.Add(producto1);

                VentaDetalle producto2 = new VentaDetalle();
                producto2.ProductoId = 2;
                producto2.Cantidad = 1;
                producto2.Descripcion = "Jugo Mango";
                producto2.PrecioUnitario = 10.00m;
                producto2.Importe = producto2.Cantidad * producto2.PrecioUnitario;
                venta.Conceptos.Add(producto2);

                venta.Total = producto1.Importe + producto2.Importe;
                venta.crearVenta(venta);

            }
            catch (Exception ex)
            {

                MessageBox.Show($"Ocurrio un error al guardar la venta {ex.Message}");
            }



            MessageBox.Show("La venta se ha realizado con éxito");
        }
        

        private void button6_Click(object sender, EventArgs e)
        {
            Frm_Ventas frmventas = new Frm_Ventas();
            frmventas.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {




        }
    }
}
