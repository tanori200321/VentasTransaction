using AccesoDatos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VentasTransaction
{
    public partial class Frm_Productos : Form
    {
        public Frm_Productos()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string consulta = "select * from productos";
            SqlDataAdapter adapter = new SqlDataAdapter(consulta, Conexion.ConnectionString);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Productos producto = new Productos();
            producto.Id = 1; // El ID del producto a actualizar
            producto.Descripcion = "Nuevo nombre de producto";
            producto.PrecioUnitario = 150.0m;

            producto.ActualizarProducto(producto);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Productos producto = new Productos();
            //producto.EliminarProducto(txtBox.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Productos producto = new Productos();
            producto.Descripcion = "Producto de ejemplo";
            producto.PrecioUnitario = 100.0m;

            producto.CrearProducto(producto);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //txtBox.Text = dataGridView1.SelectedCells[0].Value.ToString();
            //textBox2.Text = dataGridView1.SelectedCells[1].Value.ToString();
            //textBox3.Text = dataGridView1.SelectedCells[2].Value.ToString();

        }
    }
}
