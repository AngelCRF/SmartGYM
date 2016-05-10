using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Windows.Forms;

namespace GYM
{
    class Conexion
    {
        private NpgsqlConnection conn;
        String Data;

        public NpgsqlConnection Conn
        {
            get
            {
                return conn;
            }
        }

        public Conexion(String Data)
        {
            this.Data = Data;
            conn = new NpgsqlConnection(Data);

        }



        public bool Open()
        {
            try
            {
                conn.Open();
                MessageBox.Show("Conexión exitosa");
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir la base de datos\n"+ ex.Message);
                return false;
            }
        }

        public bool Close()
        {
            try
            {
                conn.Close();
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cerrar la base de datos");
                return false;
            }
        }
    }
}
