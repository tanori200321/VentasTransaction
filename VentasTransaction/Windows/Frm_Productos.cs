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
        private void CrearProductos(string Descripcion, decimal PrecioUnitario)
        {
            Productos producto = new Productos();
            producto.Descripcion = Descripcion;
            producto.PrecioUnitario = PrecioUnitario;
            producto.CrearProducto(producto);



        }
        // Borrado de Producto //
        private void EliminarProducto(int Id)
        {
            Productos producto = new Productos();
            producto.Id = Id;
            producto.EliminarProducto(Id);


        }
        // Actualizacion de Producto //
        private void ActualizarProductos(int Id, string Descripcion, decimal PrecioUnitario)
        {
            Productos producto = new Productos();
            producto.Id = Id;
            producto.Descripcion = Descripcion;
            producto.PrecioUnitario = PrecioUnitario;

            // Aquí se llama al método ActualizarProducto de la clase Producto
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
            try
            {
                int productoId;
                if (int.TryParse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString(), out productoId))
                {
                    string Descripcion = textBox2.Text;
                    decimal precioUnitario;
                    if (decimal.TryParse(textBox3.Text, out precioUnitario))
                    {
                        Productos producto = new Productos();
                        producto.Id = productoId;
                        producto.Descripcion = Descripcion;
                        producto.PrecioUnitario = precioUnitario;
                        producto.ActualizarProducto(producto);

                        ObtenerProductos();
                        MessageBox.Show("Producto Actualizado");
                    }
                    else
                    {
                        MessageBox.Show("¡ERROR! Precio unitario no válido");
                    }
                }
                else
                {
                    MessageBox.Show("¡ERROR! No se pudo actualizar el producto");
                }
            }
            catch (Exception)
            {
                // Aquí se maneja cualquier excepción que pueda ocurrir durante el proceso de actualización
            }
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
            catch (Exception )
            {
            }
        }

        // Agregar Producto //
        private void button1_Click(object sender, EventArgs e)
        {
            string Descripcion = textBox2.Text;
            decimal PrecioUnitario;

            if (!string.IsNullOrEmpty(Descripcion) && decimal.TryParse(textBox3.Text, out PrecioUnitario))
            {
                CrearProductos(Descripcion, PrecioUnitario);
                ObtenerProductos();
                MessageBox.Show("Producto Registrado");
            }
            else
            {
                MessageBox.Show("¡ERROR! No se pudo registrar el producto");
            }
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
