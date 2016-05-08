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
            catch (Exception e){}
        }

        private void RevisaDatos(Panel PanelActual)
        {
            TextBox t = new TextBox();
            foreach (Object o in PanelActual.Controls)
            {
                try
                {
                    t = (TextBox) o;
                    if (t.Text.Equals("") || t.Text == null)
                    {
                        Completo = false;
                    }
                    if (t.Text.Equals("Opcional"))
                    {
                        t.Text = null;
                    }
                }
                catch(Exception e){}
            }
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
            RevisaDatos(panel_user_new);
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
