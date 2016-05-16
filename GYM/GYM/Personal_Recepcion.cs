using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace GYM
{
    public partial class Personal_Recepcion : Form
    {
        //Variables
        bool Completo = true;
        String n;
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
                        t.Text = ""+0;
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
            String Linea;
            OcultaPaneles();
            n = Microsoft.VisualBasic.Interaction.InputBox("Cliente a buscar: ");
            panel_client_edit.Visible = true;
            Linea = C.Selecciona("Aparatos", "idaparato", n);

        }

        private void todosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OcultaPaneles();
            panel_client_show_all.Visible = true;
            DataSet datos = C.consultaClientes(dataGridView_client);
            dataGridView_client.DataSource = datos.Tables[0];
            dataGridView_client.Columns[0].HeaderCell.Value = "Clave del cliente";
            dataGridView_client.Columns[1].HeaderCell.Value = "Nombre";
            dataGridView_client.Columns[2].HeaderCell.Value = "Apellido Paterno";
            dataGridView_client.Columns[3].HeaderCell.Value = "Apellido Materno";
            dataGridView_client.Columns[3].HeaderCell.Value = "Telefono";
            dataGridView_client.Columns[3].HeaderCell.Value = "Email";
            dataGridView_client.Columns[3].HeaderCell.Value = "Tipo de Pago";
            dataGridView_client.Columns[3].HeaderCell.Value = "Fecha de Pago";
            dataGridView_client.Columns[3].HeaderCell.Value = "Tipo de Sangre";
        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String Linea;
            OcultaPaneles();
            n = Microsoft.VisualBasic.Interaction.InputBox("Cliente a buscar: ");
            panel_client_show_one.Visible = true;
            Linea = C.Selecciona("cliente", "idcliente", n);
        }

        private void nuevoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OcultaPaneles();
            panel_equip_new.Visible = true;
        }

        private void editarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OcultaPaneles();
            String Linea;
            n = Microsoft.VisualBasic.Interaction.InputBox("Aparato a buscar: ");
            Linea = C.Selecciona("Aparatos", "idaparato", n);
            panel_equip_edit.Visible = true;
        }

        private void todosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OcultaPaneles();
            panel_equip_show_all .Visible = true;
            DataSet datos = C.dataGridView("Aparatos", "idaparato");
            dataGridView_equip.DataSource = datos.Tables[0];
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
                String[] DatosA = {textBox_NombreE.Text,textBox_NSerie.Text,comboBox_Tipo.Text,dateTimePicker_FCompra.Text,dateTimePicker_FMantenimiento.Text};
                C.insertaA(DatosA);
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

        private void button_eliminaclie_Click(object sender, EventArgs e)
        {
            C.Elimina("clientes", n);
        }

        private void button_regpago_Click(object sender, EventArgs e)
        {
            C.Modifica();
        }

        private void buttonE_Save_Click(object sender, EventArgs e)
        {
            RevisaDatos(panel_client_new);
            if (Completo)
            {
                String[] DatosC = {textBox_Nombre.Text,textBox_ApellidoP.Text,textBox_ApellidoM.Text,textBox_Telefono.Text,
                    textBox_Email.Text,comboBox_TPago.Text,dateTimePicker_FPago.Text,comboBox_TSangre.Text,textBox_password.Text};
                String[] DatosD = { textBox_Calle.Text, textBox_Numero.Text, textBox_Interior.Text, textBox_Colonia.Text, textBox_Ciudad.Text };
                C.updateC(n,DatosC, DatosD);
                OcultaPaneles();
            }
            else
            {
                MessageBox.Show("Error", "Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel_inform.Visible = true;
            panel_inform.BringToFront();
            dataGridView_Pagos.Visible = true;
            dataGridView_Mantenimiento.Visible = false;
            label36.Text = "Cortes: ";
            DataSet datos = C.consultapagos(dataGridView_Pagos);
            
        }

        private void aparatosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            panel_inform.Visible = true;
            panel_inform.BringToFront();
            dataGridView_Pagos.Visible = false;
            dataGridView_Mantenimiento.Visible = true;
            label36.Text = "Mantenimiento: ";
            DataSet datos = C.consultamant(dataGridView_Mantenimiento);
            dataGridView_Mantenimiento.DataSource = datos.Tables[0];
        }

        private void buttonee_save_Click(object sender, EventArgs e)
        {
            RevisaDatos(panel_equip_new);
            if (Completo)
            {
                String[] DatosA = { textBox_NombreE.Text, textBox_NSerie.Text, comboBox_Tipo.Text, dateTimePicker_FCompra.Text, dateTimePicker_FMantenimiento.Text };
                C.insertaA(DatosA);
                OcultaPaneles();
            }
            else
            {
                MessageBox.Show("Error", "Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
