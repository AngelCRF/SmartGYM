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

        public void inserta(String table, String val, String val2, String val3, String val4, String val5, String val6, String val7, String val8, String val9, String val10, String val11)
        {
            table = table.ToLower();
            string consulta = "";
            switch (table)
            {
                case "ejercicio":
                    con.Open();             
                    NpgsqlCommand cmd = new NpgsqlCommand("select * from ejercicio order by idejercicio desc limit 1;", con.Conn);
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    int id = -1;
                    if (reader.Read()) { id = Convert.ToInt32(reader.GetInt32(0)) + 1; } else { id = 1; }                  
                    reader.Close();
                    con.Close();
                    consulta = ("insert into ejercicio (idejercicio, idaparato, repeticiones, descripcion)values('"+id+"', '"+val+"', '"+val2+"', '"+val3+"')");
                    break;
                default:
                    break;

            }
            ejecutarConsulta(consulta);
        }

        public void Selecciona()
        {

        }

        public void Elimina(String tabla, String id) 
        {
            tabla = tabla.ToLower();
            string consulta = "";
            switch (tabla)
            {
                case "rutina":
                    string consulta2= ("delete from rut_ejer where idrut= '" + id + "'");
                    ejecutarConsulta(consulta2);
                    consulta = ("delete from rutina where idrutina= '"+id+"'");
                    break;
                default:
                    break;
            }

            ejecutarConsulta(consulta);
        }

        public void Modifica()
        {

        }

        public DataSet dataGridView(String tabla, String nombreId, DataGridView aux)
        {
            tabla = tabla.ToLower();
            nombreId = nombreId.ToLower();
            con.Open();
            String consulta = "";
            switch (tabla)
            {
                case "rutina":
                    consulta = ("select * from " + tabla + " order by " + nombreId + "");
                    break;
                case "rut_ejer":               
                        consulta = ("select (ejercicios.idejercicio, ejercicios.idaparato, ejercicios.repeticiones, ejercicios.descripcion) from  Rut_Ejer, ejercicios where idrut= '" + nombreId + " and "
                + " Rut_Ejer.idejer = ejercicios.idejercicio");                  
                    break;
                case "ejercicio":
                    consulta = ("select * from " + tabla + " order by " + nombreId + "");
                    break;


                default:
                    break;
            }
            NpgsqlCommand cmd = new NpgsqlCommand(consulta, con.Conn);
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd);
            DataSet datos = new DataSet();
            adapter.Fill(datos);
            aux.DataSource = datos.Tables[0];
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
                    MessageBox.Show("Error de consulta en agregar ejercicios a rutinas");
                }
                reader.Close();
            }
            catch (Exception )
            {
                MessageBox.Show("No se pudo realizar la consulta de agregar ejercicio", "Error");

            }
            con.Close(); 
        }

        public string CrearRutina(string nombre, string horas)
        {
            int id = -1;
            con.Open();
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("select * from rutina order by idrutina desc limit 1;", con.Conn);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read()) { id = Convert.ToInt32(reader.GetInt32(0)) + 1; } else { id = 1; }
                reader.Close();
                NpgsqlCommand cmd2 = new NpgsqlCommand("insert into rutina(idrutina, nombre, horas) values ('" + id + "', '" + nombre + "', '" + horas + "');", con.Conn);
                NpgsqlDataReader reader2 = cmd.ExecuteReader();
                if (reader.Read()) { } else { MessageBox.Show("Error de consulta"); }
                reader.Close();
                MessageBox.Show("Rutina agregada exitosamente");
            }
            catch (Exception) { MessageBox.Show("Error al crear rutina"); }
            con.Close();
            return Convert.ToString(id);
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

        private void ejecutarConsulta(String consulta)
        {
            con.Open();
            try
            {
                NpgsqlCommand comando = new NpgsqlCommand(consulta, con.Conn);
                if (comando.ExecuteNonQuery() > 0)
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo realizar la operacion \n\n" + ex.Message);
            }
            con.Close();
        }

        internal void ActualizarRutina(string id, string nombre, string hora)
        {
            con.Open();
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("update rutina set nombre ='"+nombre+"', hora '"+ hora+"' where idrutina = '"+id+"'", con.Conn);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                reader.Close();    
            }
            catch (Exception) { MessageBox.Show("Error en la consulta"); }
            con.Close();
        }
    }
}


