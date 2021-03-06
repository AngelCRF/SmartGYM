﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GYM
{
    public partial class Administrador : Form
    {
        private Consultas con = new Consultas();
        private int trabajador;
        private int direccion;
        public Administrador()
        {
            InitializeComponent();

        }

        private void crearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel_NuevoTrabajadoir.BringToFront();
        }

        private void verTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void borrarDatos()
        {
            foreach(Control a in this.Controls)
            {
                try
                {
                    TextBox label = (TextBox)a;
                    a.Text = "";
                }
                catch (Exception) { }
            }
            textBox_NuevoInterior.Text = "0";
            textBox_EditarInterior5.Text = "0";
        }

        private void textboxCheck(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            string a = t.Text.ToLower();
            if (a.Contains("select") || a.Contains("update") || a.Contains("where") || a.Contains("alter") || a.Contains("insert") || a.Contains("create") || a.Contains("constraint"))
            {
                MessageBox.Show("Valor invalido");
                t.Text = "";
            }
        }


        private void textBoxInt(Object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            try
            {
                int a = Convert.ToInt32(t.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Ingrese un numero valido");
                t.Text = "";
                t.Focus();              
            }
        }

        private void button_NuevoAgregar_Click(object sender, EventArgs e)
        {
            if (comboBox_NuevoPuesto.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un puesto");
            }
            else
            {
                if (
           con.InsertTrabajador(textBox_NuevoNombre.Text, textBox_NuevoApellido1.Text, textBox_NuevoApellido2.Text, textBox_NuevaCalle.Text,
               textBox_NuevoNumero.Text, textBox_NuevoInterior.Text, textBox_NuevaColonia.Text, textBox_NuevaCiudad.Text, textBox_NuevaContraseña.Text,
               textBox_NuevoSueldo.Text, comboBox_NuevoPuesto.SelectedItem.ToString()))
                {
                    borrarDatos();
                }
            }
           

            
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int a = -1;
            String  n = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el id del trabajador a buscar");
            try
            {
                a = Convert.ToInt32(n);
            }
            catch(Exception )
            {
                MessageBox.Show("Valor invalido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            panel_Editar.BringToFront();
            List<TextBox> aux = new List<TextBox>();
            for (int i = 0; i < 10; i++)
            {
                foreach(Control x in panel_Editar.Controls)
                {
                    try
                    {
                        TextBox y = (TextBox)x;
                        if (y.Name.Contains(i + "") && y.Name.Contains("Editar"))
                        {
                            aux.Add(y);
                        }
                    }
                    catch (Exception) { }
                    
                }
            }
            direccion= con.obtenerTrabajador(a,aux);
            trabajador = a;
      
            if (direccion == -1)
            {
                trabajador = 0;
                direccion = 0;
                borrarDatos();
            }
            else
            {
                con.ObtenerDirTrab(direccion, aux);
                label_id.Text = trabajador+"";
                labeldir.Text = "" + direccion;
            }


        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox_EditarPuesto.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un puesto");
            }
            else
            {
                List<TextBox> aux = new List<TextBox>();
                for (int i = 0; i < 10; i++)
                {
                    foreach (Control x in panel_Editar.Controls)
                    {
                        try
                        {
                            TextBox y = (TextBox)x;
                            if (y.Name.Contains(i + "") && y.Name.Contains("Editar"))
                            {
                                aux.Add(y);
                            }
                        }
                        catch (Exception) { }

                    }
                }
                con.ActualizarTrabajador(label_id.Text, labeldir.Text, aux, comboBox_EditarPuesto.SelectedItem.ToString());
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
