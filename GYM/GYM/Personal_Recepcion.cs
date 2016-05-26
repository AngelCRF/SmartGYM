using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace GYM
{
    public partial class Personal_Recepcion  : Form
    {
        //Variables
        bool Completo = true;
        String n;
        int idd;
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
            Panel aux;
                foreach (Control p in this.Controls)
                {
                    try
                    {
                    aux = (Panel)p;
                    aux.Visible = false;
                }
                catch (Exception e) { }
            }
        }

        private void LimpiaDatos(Panel Actual)
        {
            TextBox t = new TextBox();
            foreach (Object o in Actual.Controls)
            {
                try
                {
                    try
                    {
                        t = (TextBox)o;
                        if (t.Text.Equals("0"))
                        {
                            textBoxE_Int.Text = "Opcional";
                        }
                        else
                        {
                            t.Text = "";
                        }
                    }
                    catch (Exception e)
                    {
                    }
                }
                catch (Exception e) { }
            }
        }

        private void RevisaDatos(Panel PanelActual)
        {
            TextBox t = new TextBox();
            foreach (Object o in PanelActual.Controls)
            {
                try
                {
                    try
                    {
                        t = (TextBox)o;
                    }
                    catch (Exception e)
                    {
                    }
                    if (t.Text == null)
                    {
                        Completo = false;

                    }
                    if (t.Text.Equals("Opcional"))
                    {
                        textBoxE_Int.Text = ""+0;
                    }
                }
                catch(Exception e){}
            }
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

        //MenuStrip Click
        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OcultaPaneles();
            LimpiaDatos(panel_client_new);
            panel_client_new.Visible = true;
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String Linea;
            OcultaPaneles();
            LimpiaDatos(panel_client_edit);
            n = Microsoft.VisualBasic.Interaction.InputBox("Cliente a buscar: ");
            if (Convert.ToInt32(n) > 0 || n != null)
            {
                Linea = C.Selecciona("cliente", "idcliente", n);
                if (Linea != null)
                {
                    panel_client_edit.Visible = true;
                    textBoxE_Nombre.Text = Linea.Split(',')[1];
                    textBoxE_ApellidoP.Text = Linea.Split(',')[2];
                    textBoxE_ApellidoM.Text = Linea.Split(',')[3];
                    textBoxE_Pass.Text = Linea.Split(',')[4];
                    textBoxE_Tel.Text = Linea.Split(',')[5];
                    textBoxE_mail.Text = Linea.Split(',')[6];
                    comboBoxE_TSangre.Text = Linea.Split(',')[7];
                    dateTimePickerE_FPago.Text = Linea.Split(',')[8];
                    comboBoxE_TPago.Text = Linea.Split(',')[9];
                    idd = Convert.ToInt32(Linea.Split(',')[10]);
                    textBoxE_Calle.Text= Linea.Split(',')[11];
                    textBoxE_Num.Text = Linea.Split(',')[12];
                    textBoxE_Int.Text = Linea.Split(',')[13];
                    textBoxE_Col.Text = Linea.Split(',')[14];
                    textBoxE_Ciudad.Text= Linea.Split(',')[15];
                }
                else
                {
                    MessageBox.Show("No existe el cliente", "Error");
                }
            }
            else
            {
                MessageBox.Show("Ingresa un numero valido", "Error");
            }
        }

        private void todosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OcultaPaneles();
            panel_client_show_all.Visible = true;
            DataSet datos = C.consultaClientes(dataGridView_client);
            dataGridView_client.DataSource = datos.Tables[0];
            dataGridView_client.Columns[0].HeaderCell.Value = "Id";
            dataGridView_client.Columns[1].HeaderCell.Value = "Nombre";
            dataGridView_client.Columns[2].HeaderCell.Value = "Apellido Paterno";
            dataGridView_client.Columns[3].HeaderCell.Value = "Apellido Materno";
            dataGridView_client.Columns[4].HeaderCell.Value = "Telefono";
            dataGridView_client.Columns[5].HeaderCell.Value = "Email";
            dataGridView_client.Columns[6].Visible = false;
            dataGridView_client.Columns[7].HeaderCell.Value = "Tipo de Sangre";
            dataGridView_client.Columns[8].HeaderCell.Value = "Fecha de corte";
            dataGridView_client.Columns[9].HeaderCell.Value = "Tipo de pago";
            dataGridView_client.Columns[10].HeaderCell.Value = "Calle";
            dataGridView_client.Columns[11].HeaderCell.Value = "Numero";
            dataGridView_client.Columns[12].HeaderCell.Value = "Interior";
            dataGridView_client.Columns[13].HeaderCell.Value = "Colonia";
            dataGridView_client.Columns[14].HeaderCell.Value = "Ciudad";
        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String Linea;
            OcultaPaneles();
            LimpiaDatos(panel_client_show_one);
            try
            {
                n = Microsoft.VisualBasic.Interaction.InputBox("Cliente a buscar: ");
                if (Convert.ToInt32(n) > 0 || n != null)
                {
                    Linea = C.Selecciona("cliente", "idcliente", n);
                    if (Linea != null)
                    {
                        panel_client_show_one.Visible = true;
                        textBoxM_Nom.Text = Linea.Split(',')[1];
                        textBoxM_AP.Text = Linea.Split(',')[2];
                        textBoxM_AM.Text = Linea.Split(',')[3];
                        textBoxM_P.Text = Linea.Split(',')[4];
                        textBoxM_T.Text = Linea.Split(',')[5];
                        textBoxM_EM.Text = Linea.Split(',')[6];
                        comboBoxM_TS.Text = Linea.Split(',')[7];
                        dateTimePickerM_FP.Text = Linea.Split(',')[8];
                        comboBoxM_TP.Text = Linea.Split(',')[9];
                        idd = Convert.ToInt32(Linea.Split(',')[10]);
                        textBoxM_C.Text = Linea.Split(',')[11];
                        textBoxM_Num.Text = Linea.Split(',')[12];
                        textBoxM_Int.Text = Linea.Split(',')[13];
                        textBoxM_Col.Text = Linea.Split(',')[14];
                        textBoxM_Ciu.Text = Linea.Split(',')[15];
                    }
                    else
                    {
                        MessageBox.Show("No existe el cliente", "Error");
                    }
                }
                else
                {
                    MessageBox.Show("Ingresa un numero valido", "Error");
                }
            }
            catch(Exception ex)
            {

            }
            }

        private void nuevoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OcultaPaneles();
            LimpiaDatos(panel_equip_new);
            panel_equip_new.Visible = true;
        }

        private void editarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            String Linea;
            OcultaPaneles();
            LimpiaDatos(panel_equip_edit);
            n = Microsoft.VisualBasic.Interaction.InputBox("Aparato a buscar: ");
            if (Convert.ToInt32(n) > 0 || n!=null)
            {
                Linea = C.Selecciona("aparatos", "idaparato", n);
                if (Linea != null)
                {
                    panel_equip_edit.Visible = true;
                    textBoxee_nombre.Text = Linea.Split(',')[1];
                    textBoxee_numserie.Text = Linea.Split(',')[2];
                    comboBoxee_tipo.Text = Linea.Split(',')[3];
                    dateTimePickeree_fcompra.Text = Linea.Split(',')[4];
                    dateTimePickeree_fmant.Text = Linea.Split(',')[5];
                }
                else
                {
                    MessageBox.Show("No existe el aparato", "Error");
                }
            }
            else
            {
                MessageBox.Show("Ingresa un numero valido", "Error");
            }
        }

        private void todosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OcultaPaneles();
            panel_equip_show_all.BringToFront();
            panel_equip_show_all .Visible = true;
            DataSet datos = C.dataGridView("Aparatos", "idaparato");
            dataGridView_equip.DataSource = datos.Tables[0];
            dataGridView_equip.Columns[0].HeaderCell.Value = "Id";
            dataGridView_equip.Columns[1].HeaderCell.Value = "Nombre";
            dataGridView_equip.Columns[2].HeaderCell.Value = "Numero de serie";
            dataGridView_equip.Columns[3].HeaderCell.Value = "Tipo";
            dataGridView_equip.Columns[4].HeaderCell.Value = "Fecha de compra";
            dataGridView_equip.Columns[5].HeaderCell.Value = "Fecha de mantenimiento";
        }

        private void buscarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            String Linea;
            OcultaPaneles();
            LimpiaDatos(panel_equip_show_one);
            try
            {
                n = Microsoft.VisualBasic.Interaction.InputBox("Aparato a buscar: ");
                if (Convert.ToInt32(n) > 0 || n != null)
                {
                    Linea = C.Selecciona("aparatos", "idaparato", n);
                    if (Linea != null)
                    {
                        panel_equip_show_one.Visible = true;
                        textBoxME_Nom.Text = Linea.Split(',')[1];
                        textBoxME_NS.Text = Linea.Split(',')[2];
                        comboBoxME_T.Text = Linea.Split(',')[3];
                        dateTimePickerME_FC.Text = Linea.Split(',')[4];
                        dateTimePickerME_FM.Text = Linea.Split(',')[5];
                    }
                    else
                    {
                        MessageBox.Show("No existe el aparato", "Error");
                    }
                }
                else
                {
                    MessageBox.Show("Ingresa un numero valido", "Error");
                }
            }
            catch (Exception ex)
            {

            }
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
            RevisaDatos(panel_client_edit);
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
                String[] DatosC = {textBoxE_Nombre.Text,textBoxE_ApellidoP.Text,textBoxE_ApellidoM.Text,textBoxE_Tel.Text,
                    textBoxE_mail.Text,comboBoxE_TPago.Text,dateTimePickerE_FPago.Text,comboBoxE_TSangre.Text,textBoxE_Pass.Text};
                String[] DatosD = { textBoxE_Calle.Text, textBoxE_Num.Text, textBoxE_Int.Text, textBoxE_Col.Text, textBoxE_Ciudad.Text };
                C.updateC(idd,n,DatosC, DatosD);
                OcultaPaneles();
                
            }
            else
            {
                MessageBox.Show("Error", "Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OcultaPaneles();
            panel_inform.Visible = true;
            panel_inform.BringToFront();
            dataGridView_Pagos.Visible = true;
            dataGridView_Mantenimiento.Visible = false;
            label36.Text = "Cortes: ";
            DataSet datos = C.consultapagos(dataGridView_Pagos);
            
        }

        private void aparatosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OcultaPaneles();
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
                string[] DatosA = { textBoxee_nombre.Text, textBoxee_numserie.Text, comboBoxee_tipo.Text, dateTimePickeree_fcompra.Text, dateTimePickeree_fmant.Text };
                C.updateA(DatosA , Convert.ToInt32(n));
                OcultaPaneles();
            }
            else
            {
                MessageBox.Show("Error", "Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cortesCercanosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OcultaPaneles();
            panel_inform.Visible = true;
            panel_inform.BringToFront();
            dataGridView_Pagos.Visible = true;
            dataGridView_Mantenimiento.Visible = false;
            label36.Text = "Cortes cercanos: ";
            DataSet datos = C.consultacortes(dataGridView_Pagos);
        }

        private void Personal_Recepcion_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }


        private void IC(object sender, EventArgs e)
        {
            TextBox b = (TextBox)sender;
            try
            {
                int a = Convert.ToInt32(b.Text);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Ingrese un numero entero", "Numero invalido");
                b.Focus();
            }
        }
    }
}
