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

        public void inserta(String table, String val, String val2, String val3, String val4, String val5, String val6)
        {
            table = table.ToLower();
            string consulta = "";
            switch (table)
            {
                case "ejercicio":
                    con.Open();             
                    NpgsqlCommand cmd = new NpgsqlCommand("select * from ejercicio order by idejercicio desc limit 1;", con.Conn);
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    int id = -1;
                    if (reader.Read()) { id = Convert.ToInt32(reader.GetInt32(0)) + 1; } else { id = 1; }                  
                    reader.Close();
                    con.Close();
                    consulta = ("insert into ejercicio (idejercicio, idaparato, repeticiones, descripcion)values('"+id+"', '"+val+"', '"+val2+"', '"+val3+"')");
                    break;
                default:
                    break;

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
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("Insert into rut_ejer (idrut, idejer)values( '" + idrutina + "' , '" + idejercicio + "')", con.Conn);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                { }
                else
                {
                    MessageBox.Show("Error de consulta");
                }
                reader.Close();
            }
            catch (Exception )
            {
                MessageBox.Show("No se pudo realizar la consulta", "Error");

            }
            con.Close(); 
        }

        public void eliminarEjercicios(String idrutina, String idejercicio)
        {
            con.Open();
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("delete from rut_ejer where idrut='" + idrutina + "' and idejer= '" + idejercicio + "')", con.Conn);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                { }
                else
                {
                    MessageBox.Show("Error de consulta");
                }
                reader.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("No se encontró el ejercicio en la rutina", "Verificar ejercicos de la rutina");

            }
            con.Close();
        }



        


    }
}


