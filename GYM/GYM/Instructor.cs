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
            try
            {
                foreach (DataGridViewRow row in dataGridView_AgregarEjercicios.SelectedRows)
                {
                    con.AgregarEjercicios(textBox_CrearIdRutina.Text, row.Cells[0].Value.ToString());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ya existe el ejercicio en la rutina", "Error de consulta");
            }
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel_CrearRutina.BringToFront();
            textBox_ModificarrutinaId.Visible = false;
            label6.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox_ModificarrutinaId.Text);


        }
    }
}
