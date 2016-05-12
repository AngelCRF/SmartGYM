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
    public partial class Cliente : Form
    {
        int id;
        private Consultas con = new Consultas();
        public Cliente(int id)
        {
            InitializeComponent();
            this.id = id;
            label3.Text = con.fechaDePagoCliente(id);
            con.MostrarRutinaCliente(dataGridView1);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Cliente_Load(object sender, EventArgs e)
        {
            
        }
    }
}
