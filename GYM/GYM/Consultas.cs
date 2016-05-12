using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GYM
{
    class Consultas
    {
        private String data = "Server=www.johnny.heliohost.org;Port=5432;User Id=itmoreli_user;Password=12345678;Database=itmoreli_smartgym";
        private Conexion con = new Conexion("Server=www.johnny.heliohost.org;Port=5432;User Id=itmoreli_user;Password=12345678;Database=itmoreli_smartgym");

        public bool insertaC(String[] DatosC, String[] DatosD)//Clientes
        {
            try
            {
                int IDD, IDC;
                NpgsqlDataReader reader;
                con.Open();
                String consultaIDC = "SELECT * FROM clientes ORDER BY idcliente DESC LIMIT 1;";
                String consultaIDD = "SELECT * FROM direcciones ORDER BY iddireccion DESC LIMIT 1;";
                NpgsqlCommand cmdIDD = new NpgsqlCommand(consultaIDD, con.Conn);
                reader = cmdIDD.ExecuteReader();
                reader.Read();
                IDD = Convert.ToInt32(reader.GetInt32(0)) + 1;
                String consultaD = "INSERT INTO direcciones () Values('";
                NpgsqlCommand cmdD = new NpgsqlCommand(consultaD, con.Conn);
                NpgsqlCommand cmdIDC= new NpgsqlCommand(consultaIDC, con.Conn);
                reader = cmdIDC.ExecuteReader();
                reader.Read();
                IDC = Convert.ToInt32(reader.GetInt32(0)) + 1;
                String consultaC = "INSERT INTO clientes (idcliente, nombre, apellidop, apellidom, telefono, email, iddireccion, tipodepago, fechadepago, tipodesangre, contraseña) Values('"+
                    IDC+"','"+DatosC[0]+ "','" + DatosC[1]+ "','" + DatosC[2]+
                    "','" + DatosC[3]+ "','" + DatosC[4]+ "','" +IDD+ "','" + DatosC[5]+ 
                    "','" + DatosC[6]+ "','" + DatosC[7];
                NpgsqlCommand cmdC = new NpgsqlCommand(consultaC, con.Conn);
                MessageBox.Show("Cliente guardado ",("Id= "+IDC+"\n Contraseña= "+DatosC[7]),MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error", e.ToString() , MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
                return false;
            }
        }

        public void insertaA()//Aparatos
        {
            try
            {
                con.Open();
                String consulta = "";
                NpgsqlCommand cmd = new NpgsqlCommand(consulta, con.Conn);
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error", e.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Selecciona()
        {

        }

        public void Elimina()
        {

        }

        public void Modifica()
        {

        }

        public DataSet dataGridView(String tabla, String nombreId)
        {
            tabla = tabla.ToLower();
            nombreId = nombreId.ToLower();
            con.Open();
            String consulta = "";
            switch (tabla)
            {
                case "rutinas":
                    consulta = ("select * from " + tabla + " order by " + nombreId + "");
                    break;
                case "clientes":
                    consulta = ("select * from " + tabla + " order by " + nombreId + "");
                    break;
                case "aparatos":
                    consulta = ("select * from " + tabla + " order by " + nombreId + "");
                    break;
                case "rut_ejer":
                        consulta = ("select (idaparato, repeticiones, descripcion) from  Rut_Ejer, ejercicios where idrut= '" + nombreId + " and "
                + " Rut_Ejer.idejer = ejercicios.idejercicio");
                    break;
                default:
                    break;
            }
            NpgsqlCommand cmd = new NpgsqlCommand(consulta, con.Conn);
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd);
            DataSet datos = new DataSet();
            adapter.Fill(datos);
            con.Close();
            return datos;
        }

        public void AgregarEjercicios(String idrutina, String idejercicio)
        {
            con.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("Insert into rut_ejer values( '"+idrutina+"' , '"+idejercicio+"')", con.Conn);
            con.Close(); 
        }
    }
}


