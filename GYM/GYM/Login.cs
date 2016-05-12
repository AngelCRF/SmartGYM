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
    public partial class Login : Form
    {
        private Consultas con = new Consultas();
        private String data = "Server=www.johnny.heliohost.org;Port=5432;User Id=itmoreli_user;Password=12345678;Database=itmoreli_smartgym";

        public Login()
        {
            InitializeComponent();
            radioButton_Personal.Checked = false;
            radioButton_Cliente.Checked = false;
            
        }

        private void radioButton_Personal_CheckedChanged(object sender, EventArgs e)
        {
            radioButton_Cliente.Checked = false;
            textBox_user.Focus();
        }

        private void radioButton_Cliente_CheckedChanged(object sender, EventArgs e)
        {
            radioButton_Personal.Checked = false;
            textBox_user.Focus();
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            if (radioButton_Cliente.Checked)
            {
                if (con.BuscarContraseña("cliente", Convert.ToInt32(textBox_user.Text), textBox_password.Text)) {
                    Cliente aux = new Cliente(Convert.ToInt32(textBox_user.Text));
                    aux.Show();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos, vuelva a intentar");
                }
            }
            else
            {
                if (radioButton_Personal.Checked)
                {
                    if (con.BuscarContraseña("trabajador", Convert.ToInt32(textBox_user.Text), textBox_password.Text))
                    {
                        Personal_Recepcion PR = new Personal_Recepcion();
                        PR.Show();
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña incorrectos, vuelva a intentar");
                    }
                }
                else
                {
                    if (radioButton_Instructor.Checked)
                    {
                        if (con.BuscarContraseña("instructor", Convert.ToInt32(textBox_user.Text),textBox_password.Text))
                        {
                            Instructor tres = new Instructor();
                            tres.Show();
                        }
                        else
                        {
                            MessageBox.Show("Usuario o contraseña incorrectos, vuelva a intentar");
                        }

                    }
                }
            }
        }

        private void label_user_Click(object sender, EventArgs e)
        {

        }

        private void textBox_user_Leave(object sender, EventArgs e)
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
    }
}
