using AccesoDatos;
using AccesoDatos.Entidades;
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
    public partial class Frm_Existencias : Form
    {
        public Frm_Existencias()
        {
            InitializeComponent();

            try
            {
                ObtenerExistencias();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // --------------- Llamado de Metodos --------------- //

        // Actualizacion de Existencias //
        private void ActualizarExistencias(int Id, decimal valor)
        {
            Existencias existencia = new Existencias();
            existencia.Id = Id;
            existencia.Existencia = valor;
            existencia.ActualizarExistencia(existencia.Id,existencia.Existencia);

        }

        //private void ActualizarExistencias()
        //{
        //    Existencias existenciaJumex = new Existencias();
        //    existenciaJumex.Id = 28;
        //    existenciaJumex.Existencia = 15;
        //    existenciaJumex.ActualizarExistencia(existenciaJumex.Id, existenciaJumex.Existencia);

        //}

        // Mostrar Datos de la tabla //
        private void ObtenerExistencias()
        {
            Existencias exi = new Existencias();
            SqlDataAdapter adapter = exi.ObtenerExistencias();
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


        private void button3_Click(object sender, EventArgs e)
        {


        }



        // Agregar Existencia //
        private void button1_Click(object sender, EventArgs e)
        {

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

        // Seleccionar dato //
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView1.SelectedCells[1].Value.ToString();
            textBox1.Text = dataGridView1.SelectedCells[2].Value.ToString();

        }
        // Actualizar Existencia //

        private void button1_Click_1(object sender, EventArgs e)
        {
           

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            try
            {
                int Id;
                if (int.TryParse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString(), out Id))
                {
                    decimal valor;
                    if (decimal.TryParse(textBox1.Text, out valor))
                    {
                        Existencias existencia = new Existencias();
                        existencia.Id = Id;
                        existencia.Existencia = valor;
                        existencia.ActualizarExistencia(existencia.Id, existencia.Existencia);

                        ObtenerExistencias();
                        MessageBox.Show("Existencia Actualizada");
                    }
                    else
                    {
                        MessageBox.Show("¡ERROR! Valor de existencia no válido");
                    }
                }
                else
                {
                    MessageBox.Show("¡ERROR! No se pudo actualizar la existencia");
                }
            }
            catch (Exception)
            {
                // Aquí se maneja cualquier excepción que pueda ocurrir durante el proceso de actualización
            }
        }
    }
}

