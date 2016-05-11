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
        private Conexion con;
        private String data = "Server=www.johnny.heliohost.org;Port=5432;User Id=itmoreli_user;Password=12345678;Database=itmoreli_smartgym";

        public Login()
        {
            InitializeComponent();
            radioButton_Personal.Checked = false;
            radioButton_Cliente.Checked = false;
            Personal_Recepcion PR = new Personal_Recepcion();
            //Lineas de Prueba
            PR.Show();
            Instructor MrSatan = new Instructor();
            MrSatan.Show();
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
            con = new Conexion(data);
            con.Open();//abrir conexión con la base de datos
            con.Close();
        }

        private void label_user_Click(object sender, EventArgs e)
        {

        }
    }
}
