using System;
using System.Windows.Forms;

namespace GYM
{
    public partial class Personal_Recepcion : Form
    {
        //Variables
        bool Completo = true;
        Consultas C = new Consultas();

        public Personal_Recepcion()
        {
            InitializeComponent();
            OcultaPaneles();
            dateTimePicker_FPago.Value = DateTime.Now;
        }

        //Funciones
        private void OcultaPaneles()
        {
            try
            {
                foreach (Panel p in this.Controls)
                {
                    p.Visible = false;
                }
            }
            catch (Exception e)
            {
            }
        }

        private void RevisaDatos()
        {
            if (textBox_Nombre.Text.Equals("") || textBox_Nombre== null ||
                textBox_ApellidoP.Text.Equals("") || textBox_ApellidoP == null ||
                textBox_ApellidoM.Text.Equals("") || textBox_ApellidoM == null ||
                textBox_Telefono.Text.Equals("") || textBox_Telefono == null ||
                textBox_Calle.Text.Equals("") || textBox_Calle == null ||
                textBox_Numero.Text.Equals("") || textBox_Numero == null ||
                textBox_Interior.Text.Equals("") || textBox_Interior == null ||
                textBox_Colonia.Text.Equals("") || textBox_Colonia == null ||
                textBox_Ciudad.Text.Equals("") || textBox_Ciudad == null)
            {
                Completo = false;
            }
            if (textBox_Interior.Text.Equals("Opcional"))
            {
                textBox_Interior.Text = null;
            }
            /*foreach (TextBox t in this.Controls)
            {
                if (t.Text.Equals("") || t.Text == null)
                {
                    Completo = false;
                }
                if (t.Text.Equals("Opcional"))
                {
                    t.Text = null;
                }
            }*/
        }

        //Acciones
        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OcultaPaneles();
            panel_user_new.Visible = true;
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OcultaPaneles();
            panel_user_edit.Visible = true;
        }

        private void todosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OcultaPaneles();
            panel_user_show_all.Visible = true;
        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OcultaPaneles();
            panel_user_show_one.Visible = true;
        }

        private void button_Save_User_Click(object sender, EventArgs e)
        {
            RevisaDatos();
            if (Completo)
            {
                //C.inserta();
                MessageBox.Show("Datos Guardados", "Cliente Agregado", MessageBoxButtons.OK);
                OcultaPaneles();
            }
            else
            {
                MessageBox.Show("Error", "Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
