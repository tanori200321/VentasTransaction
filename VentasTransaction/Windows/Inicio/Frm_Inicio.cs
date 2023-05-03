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
        }

        //Metodo para Guardar Ventas//
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

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Frm_Ventas frmventas = new Frm_Ventas();
            frmventas.Show();
        }
    }
}
