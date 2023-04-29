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

            try
            {
                ObtenerProductos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // --------------- Llamado de Metodos --------------- //

        // Agregado de Producto //
        private void CrearProducto(string Nombre)
        {
            Productos producto = new Productos();



        }
        // Borrado de Producto //
        private void EliminarProducto(int Id)
        {
            Productos producto = new Productos();
            producto.Id = Id;
            producto.EliminarProducto(Id);


        }
        // Actualizacion de Producto //
        private void ActualizarProducto(string Descripcion, decimal PrecioUnitario)
        {
            Productos producto = new Productos();
            producto.Descripcion = Descripcion;
            producto.PrecioUnitario = PrecioUnitario;
            producto.ActualizarProducto(producto);


        }
        // Mostrar Datos de la tabla //
        private void ObtenerProductos()
        {
            Productos cliente = new Productos();
            SqlDataAdapter adapter = cliente.ObtenerProductos();
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        // Actualizar Producto //
        private void button3_Click(object sender, EventArgs e)
        {

        }

        // Eliminar Producto //
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int Id;
                if (int.TryParse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString(), out Id))
                {
                    Productos producto = new Productos();
                    producto.EliminarProducto(Id);
                    ObtenerProductos();
                    MessageBox.Show("Producto Eliminado");
                }
                else
                {
                    MessageBox.Show("¡ERROR! no se elimino el Producto");

                }
            }
            catch (Exception ex)
            {
            }
        }

        // Agregar Producto //
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

        // Seleccionar dato //
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView1.SelectedCells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedCells[2].Value.ToString();

        }
    }
}
