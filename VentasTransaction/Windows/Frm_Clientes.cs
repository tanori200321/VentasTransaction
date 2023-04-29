using AccesoDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VentasTransaction
{
    public partial class Frm_Clientes : Form
    {
        public Frm_Clientes()
        {
            InitializeComponent();

            try
            {
                ObtenerClientes();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        // --------------- Llamado de Metodos --------------- //

        // Registro de Cliente //
        private void AgregarCliente(string Nombre)
        {
            Clientes cliente = new Clientes();
            cliente.Nombre = Nombre;
            cliente.CrearCliente(cliente);


        }
        // Borrado de Cliente //
        private void EliminarCliente(int Id)
        {
            Clientes cliente = new Clientes();
            cliente.Id = Id;
            cliente.EliminarCliente(Id);


        }
        // Actualizacion de Cliente //
        private void ActualizarCliente(string Nombre)
        {
            Clientes cliente = new Clientes();
            cliente.Nombre = Nombre;
            cliente.Ac(cliente);


        }
        // Mostrar Datos de la tabla //
        private void ObtenerClientes()
        {
            Clientes cliente = new Clientes();
            SqlDataAdapter adapter = cliente.ObtenerClientes();
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

        // Actualizacion de Cliente //
        private void button3_Click(object sender, EventArgs e)
        {
            string cliente = textBox2.Text;
            if (!string.IsNullOrEmpty(cliente))
            {
                ActualizarCliente(cliente);
                ObtenerClientes();
                MessageBox.Show("Cliente Actualizado");
            }
            else
            {
                MessageBox.Show("¡ERROR! no se pudo actualizar el cliente");
            }

        }

        // Borrado de Cliente //
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int clienteId;
                if (int.TryParse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString(), out clienteId))
                {
                    Clientes cliente = new Clientes();
                    cliente.EliminarCliente(clienteId);
                    ObtenerClientes();
                    MessageBox.Show("Cliente Eliminado");
                }
                else
                {
                    MessageBox.Show("¡ERROR! no se elimino el cliente");

                }
            }
            catch (Exception ex)
            {

            }
        }

        // Registro de Cliente //
        private void button1_Click(object sender, EventArgs e)
        {
            string cliente = textBox2.Text;
            if (!string.IsNullOrEmpty(cliente))
            {

                AgregarCliente(cliente);
                ObtenerClientes();
                MessageBox.Show("Cliente Registrado");
                
            }
            else
            {
                MessageBox.Show("¡ERROR! no se registro el cliente");
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

        }
    }
}
