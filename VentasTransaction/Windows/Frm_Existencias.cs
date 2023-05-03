﻿using AccesoDatos;
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
        private void ActualizarExistencias(int Id, int ProductoId, decimal Existencia)
        {
            //Existencias existencia = new Existencias();
            //existencia.Id = Id;
            //existencia.ProductoId= ProductoId;  
            //existencia.Existencia= Existencia;
            //existencia.ActualizarExistencia(existencia);


        }

        // Mostrar Datos de la tabla //
        private void ObtenerExistencias()
        {
            Existencias exi = new Existencias();
            SqlDataAdapter adapter = exi.ObtenerExistencias();
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            ExistenciasGrid.DataSource = dt;
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        // Seleccionar dato //
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = ExistenciasGrid.SelectedCells[1].Value.ToString();
            textBox3.Text = ExistenciasGrid.SelectedCells[2].Value.ToString();

        }
        // Actualizar Producto //
        private void button2_Click(object sender, EventArgs e)
        {


            }
        }
}

