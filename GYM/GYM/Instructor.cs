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

            DataSet dato = con.dataGridView("rutina", "idrutina");
            dataGridViewRutina.DataSource = dato.Tables[0];
            dataGridViewRutina.Columns[0].HeaderCell.Value = "Clave de rutina";
            dataGridViewRutina.Columns[1].HeaderCell.Value = "Nombre";
            dataGridViewRutina.Columns[2].HeaderCell.Value = "Duración de rutina";
            
        }

        private void crearRutinaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel_CrearRutina.BringToFront();
            textBox_CrearHorasRutina.Text = "";
            textBox_ModificarrutinaId.Text = "";
            textBox_CrearNombre.Text = "";
            textBox_CrearHorasRutina.Enabled = true;
            textBox_CrearNombre.Enabled = true;
            dataGridView_crearRutina.Visible = true;
            dataGridView_Eliminarejercicios.Visible = false;
            dataGridView_AgregarEjercicios.Visible = false;
            textBox_ModificarrutinaId.Visible = false;
            label6.Visible = false;
            button_CambiarHora.Visible = false;
            button_BuscarRutina.Visible = false;
            button_AgrerarEjercicio2.Visible = false;
            button_EliminarEjercicio.Visible = false;
            button_agregarEjercicios.Visible = true;
            //HABILITAR CUANDO ESTÉ LA BASE DE DATOS

            DataSet dato = con.consultaEjercicios(dataGridView_crearRutina);
            dataGridView_crearRutina.DataSource = dato.Tables[0];
            dataGridView_crearRutina.Columns[0].HeaderCell.Value = "Clave del ejercicio";
            dataGridView_crearRutina.Columns[1].HeaderCell.Value = "clave del aparato";
            dataGridView_crearRutina.Columns[2].HeaderCell.Value = "repeticiones";
            dataGridView_crearRutina.Columns[3].HeaderCell.Value = "descripción";
             

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox_CrearNombre.Text==""|| textBox_CrearHorasRutina.Text == "")
            {
                MessageBox.Show("Llenar todos los campos");
            }
            else
            {
                String id= con.CrearRutina(textBox_CrearNombre.Text, textBox_CrearHorasRutina.Text);
                foreach (DataGridViewRow row in dataGridView_crearRutina.SelectedRows)
                {
                    con.AgregarEjercicios(id, row.Cells[0].Value.ToString());
                }

            }
                         
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel_CrearRutina.BringToFront();
            textBox_ModificarrutinaId.Enabled = true;
            textBox_ModificarrutinaId.Visible = true;
            textBox_CrearHorasRutina.Text = "";
            textBox_ModificarrutinaId.Text = "";
            textBox_CrearNombre.Text = "";
            label6.Visible = true;
            button_BuscarRutina.Visible = true;
            button_agregarEjercicios.Visible = false;
            dataGridView_crearRutina.Visible = false;
            dataGridView_Eliminarejercicios.Visible = true;
            dataGridView_AgregarEjercicios.Visible = true;
            button_AgrerarEjercicio2.Visible = true;
            button_EliminarEjercicio.Visible = true;
            dataGridView_Eliminarejercicios.Rows.Clear();
            dataGridView_Eliminarejercicios.Refresh();
            //dataGridView_AgregarEjercicios.Rows.Clear();
            dataGridView_AgregarEjercicios.Refresh();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String id = textBox_ModificarrutinaId.Text;
            textBox_ModificarrutinaId.Enabled = false;
            try
            {
                DataSet dato = con.consultaejerciciosContenidos(dataGridView_Eliminarejercicios, Convert.ToInt32(id));
                dataGridViewEjercicio.Columns[0].HeaderCell.Value = "Clave de ejercicio";
                dataGridViewEjercicio.Columns[1].HeaderCell.Value = "Clave de aparato";
                dataGridViewEjercicio.Columns[2].HeaderCell.Value = "Repeticiones";
                dataGridViewEjercicio.Columns[3].HeaderCell.Value = "Descripción";

                DataSet dato2 = con.consultaEjercicios(dataGridView_AgregarEjercicios);
                dataGridViewEjercicio.Columns[0].HeaderCell.Value = "Clave de ejercicio";
                dataGridViewEjercicio.Columns[1].HeaderCell.Value = "Clave de aparato";
                dataGridViewEjercicio.Columns[2].HeaderCell.Value = "Repeticiones";
                dataGridViewEjercicio.Columns[3].HeaderCell.Value = "Descripción";
            }
            catch (Exception ex) { MessageBox.Show("Error de consulta en buscar id:" + ex.Message); }
        }

        private void button_AgrerarEjercicio2_Click(object sender, EventArgs e)
        {
            if (!textBox_ModificarrutinaId.Enabled)
            {
                foreach (DataGridViewRow row in dataGridView_AgregarEjercicios.SelectedRows)
                {
                    con.AgregarEjercicios(textBox_ModificarrutinaId.Text, row.Cells[0].Value.ToString());
                }
            }
            
           
        }

        private void button_CambiarHora_Click(object sender, EventArgs e)
        {
            if (!textBox_ModificarrutinaId.Enabled)
            {
                if (textBox_CrearHorasRutina.Text == "" || textBox_CrearNombre.Text == "")
                {
                    MessageBox.Show("Campos incompletos");
                }
                else
                {
                    con.ActualizarRutina(textBox_ModificarrutinaId.Text, textBox_CrearNombre.Text, textBox_CrearHorasRutina.Text);
                }
            }
            else
            {
                MessageBox.Show("Ingrese un id para buscar");
            }
        }

        private void button_EliminarEjercicio_Click(object sender, EventArgs e)
        {
            if (!textBox_ModificarrutinaId.Enabled)
            {
                foreach (DataGridViewRow row in dataGridView_Eliminarejercicios.SelectedRows)
                {
                    con.eliminarEjercicios(textBox_ModificarrutinaId.Text, row.Cells[0].Value.ToString());
                }
            }
            else
            {
                MessageBox.Show("Ingrese un id para buscar");
            }
            
          
        }

        private void crearEjercicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel_CrearEjercicio.BringToFront();
            DataSet dato2 = con.consultaaparatos(dataGridView_aparatos);
            //dataGridView_aparatos.DataSource = dato2.Tables[0];
            dataGridView_aparatos.Columns[0].HeaderCell.Value = "Clave de aparato";
            dataGridView_aparatos.Columns[1].HeaderCell.Value = "Clave de nombre";
            dataGridView_aparatos.Columns[2].HeaderCell.Value = "Numero de serie";
            dataGridView_aparatos.Columns[3].HeaderCell.Value = "tipo";
            dataGridView_aparatos.Columns[4].HeaderCell.Value = "fecha de compra";
            dataGridView_aparatos.Columns[5].HeaderCell.Value = "fecha de matenimiento";


        }

        private void textBox_Repeticiones_Leave(object sender, EventArgs e)
        {
            TextBox aux = (TextBox)sender;
            try
            {
                int a = Convert.ToInt32(aux.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Ingrese un numero correcto", "numero entero");
                aux.Focus();
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
                        con.insertaEjercicio(Convert.ToString(id), textBox_Repeticiones.Text, textBox_Descricpcion.Text);
                    }
                }
                catch (Exception) { MessageBox.Show("debe seleccionar un aparato"); }
            }

        }

        private void eliminarRutinaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel_EliminarRutina.BringToFront();
        }

        private void button_EliminarRutina_Click(object sender, EventArgs e)
        {
            if (textBox_eliminarId.Text == "")
            {
                MessageBox.Show("ingrese un id");
            }
            else
            {
                con.Elimina("rutina", textBox_eliminarId.Text);
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void asignarRutinaAClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel_AsignarRutinas.BringToFront();



        }

        private void dataGridViewRutina_MouseClick(object sender, MouseEventArgs e)
        {
            string clave = "";
            try
            {
                foreach (DataGridViewRow row in dataGridViewRutina.SelectedRows)
                {
                    clave = row.Cells[0].Value.ToString();
                    
                }
                DataSet dato = con.consultaRutinaEjercicios(dataGridViewEjercicio, Convert.ToInt32(clave));
                //dataGridViewEjercicio.DataSource = dato.Tables[0];
                dataGridViewEjercicio.Columns[0].HeaderCell.Value = "Clave de ejercicio";
                dataGridViewEjercicio.Columns[1].HeaderCell.Value = "Clave de aparato";
                dataGridViewEjercicio.Columns[2].HeaderCell.Value = "Repeticiones";
                dataGridViewEjercicio.Columns[3].HeaderCell.Value = "Descripción";
            }
            catch (Exception) { }
        }
    }
}
