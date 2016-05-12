using System;
using System.Collections.Generic;
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
        
        //MenuStrip Click
        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OcultaPaneles();
            panel_client_new.Visible = true;
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OcultaPaneles();
            panel_client_edit.Visible = true;
        }

        private void todosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OcultaPaneles();
            panel_client_show_all.Visible = true;
        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OcultaPaneles();
            panel_client_show_one.Visible = true;
        }

        private void nuevoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OcultaPaneles();
            panel_equip_new.Visible = true;
        }

        private void editarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OcultaPaneles();
            panel_equip_edit.Visible = true;
        }

        private void todosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OcultaPaneles();
            panel_equip_show_all .Visible = true;
        }

        private void buscarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OcultaPaneles();
            panel_equip_show_one.Visible = true;
        }

        //Botones Click
        private void button_Save_Equip_Click(object sender, EventArgs e)
        {
            RevisaDatos(panel_equip_new);
            if (Completo)
            {
                //C.inserta();
                MessageBox.Show("Datos Guardados", "Aparato Agregado", MessageBoxButtons.OK);
                OcultaPaneles();
            }
            else
            {
                MessageBox.Show("Error", "Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_Save_User_Click(object sender, EventArgs e)
        {
            RevisaDatos(panel_client_new);
            if (Completo)
            {
                String[] DatosC = {textBox_Nombre.Text,textBox_ApellidoP.Text,textBox_ApellidoM.Text,textBox_Telefono.Text,
                    textBox_Email.Text,comboBox_TPago.Text,dateTimePicker_FPago.Text,comboBox_TSangre.Text,textBox_password.Text};
                String[] DatosD = { textBox_Calle.Text, textBox_Numero.Text, textBox_Interior.Text,textBox_Colonia.Text,textBox_Ciudad.Text};
                C.insertaC(DatosC, DatosD);
                OcultaPaneles();
            }
            else
            {
                MessageBox.Show("Error", "Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
