using System;
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
    public partial class Instructor : Form
    {
        private Consultas con = new Consultas();


        public Instructor()
        {
            InitializeComponent();
        }

        private void Instructor_Load(object sender, EventArgs e)
        {

        }

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel_MostrarRutinas.BringToFront();
            //HABILITAR CUANDO ESTÉ LA BASE DE DATOS

            /*DataSet dato = con.dataGridView("rutinas", "idrutina");
            dataGridViewRutina.DataSource = dato.Tables[0];
            dataGridViewRutina.Columns[0].HeaderCell.Value = "Clave de rutina";
            dataGridViewRutina.Columns[1].HeaderCell.Value = "Nombre";
            dataGridViewRutina.Columns[2].HeaderCell.Value = "Duración de rutina";
            */
        }

        private void dataGridViewRutina_KeyPress(object sender, KeyPressEventArgs e)
        {
            string clave = "";
            try
            {
                foreach (DataGridViewRow row in dataGridViewRutina.SelectedRows)
                {
                    clave = row.Cells[0].Value.ToString();
                }
                DataSet dato = con.dataGridView("rut_ejer", clave);
                dataGridViewEjercicio.DataSource = dato.Tables[0];
                dataGridViewEjercicio.Columns[0].HeaderCell.Value = "Clave de aparato";
                dataGridViewEjercicio.Columns[1].HeaderCell.Value = "Repeticiones";
                dataGridViewEjercicio.Columns[2].HeaderCell.Value = "Descripción";
            }
            catch (Exception) { }
        }

        private void crearRutinaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel_CrearRutina.BringToFront();
            textBox_ModificarrutinaId.Visible = false;
            label6.Visible = false;
            button_BuscarRutina.Visible = false;
            button_AgrerarEjercicio2.Visible = false;
            button_EliminarEjercicio.Visible = false;
            button_agregarEjercicios.Visible = true;
            //HABILITAR CUANDO ESTÉ LA BASE DE DATOS

            /* DataSet dato = con.dataGridView("ejercicio", "idejercicio");
             dataGridView_AgregarEjercicios.DataSource = dato.Tables[0];
             dataGridView_AgregarEjercicios.Columns[0].HeaderCell.Value = "Clave del ejercicio";
             dataGridView_AgregarEjercicios.Columns[1].HeaderCell.Value = "clave del aparato";
             dataGridView_AgregarEjercicios.Columns[2].HeaderCell.Value = "repeticiones";
             dataGridView_AgregarEjercicios.Columns[3].HeaderCell.Value = "descripción";
             */

        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView_AgregarEjercicios.SelectedRows)
            {
                con.AgregarEjercicios(textBox_CrearIdRutina.Text, row.Cells[0].Value.ToString());
            }              
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel_CrearRutina.BringToFront();
            textBox_ModificarrutinaId.Enabled = true;
            textBox_ModificarrutinaId.Visible = true;
            label6.Visible = true;
            button_BuscarRutina.Visible = true;
            button_agregarEjercicios.Visible = false;
            dataGridView_AgregarEjercicios.Rows.Clear();
            dataGridView_AgregarEjercicios.Refresh();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox_ModificarrutinaId.Text);
            textBox_ModificarrutinaId.Enabled = false;
            textBox_CrearIdRutina.Enabled = false;
            


        }

        private void button_AgrerarEjercicio2_Click(object sender, EventArgs e)
        {
            
                foreach (DataGridViewRow row in dataGridView_AgregarEjercicios.SelectedRows)
                {
                    con.AgregarEjercicios(textBox_ModificarrutinaId.Text, row.Cells[0].Value.ToString());
                }
            
           
        }

        private void button_CambiarHora_Click(object sender, EventArgs e)
        {

        }

        private void button_EliminarEjercicio_Click(object sender, EventArgs e)
        {
           
                foreach (DataGridViewRow row in dataGridView_AgregarEjercicios.SelectedRows)
                {
                    con.eliminarEjercicios(textBox_ModificarrutinaId.Text, row.Cells[0].Value.ToString());
                }
            
          
        }

        private void crearEjercicioToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void textBox_Repeticiones_Leave(object sender, EventArgs e)
        {
            try
            {
                int a = Convert.ToInt32(textBox_Repeticiones.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Ingrese un numero correcto", "numero entero");
                textBox_Repeticiones.Focus();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int id = -1;
            if(textBox_Repeticiones.Text=="" || textBox_Descricpcion.Text == "")
            {
                MessageBox.Show("Llene todos los campos", "verifique la información");
            }
            else
            {
                try
                {
                    foreach (DataGridViewRow row in dataGridView_aparatos.SelectedRows)
                    {
                       id = Convert.ToInt32(row.Cells[0].Value.ToString());
                    }
                    if (id > 0)
                    {
                        con.inserta("ejercicio", Convert.ToString(id), textBox_Repeticiones.Text, textBox_Descricpcion.Text,"", "" );
                    }
                }
                catch (Exception) { MessageBox.Show("debe seleccionar un aparato"); }
            }

        }
    }
}
