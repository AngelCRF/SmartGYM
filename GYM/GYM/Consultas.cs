using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM
{
    class Consultas
    {
        private String data = "Server=www.johnny.heliohost.org;Port=5432;User Id=itmoreli_user;Password=12345678;Database=itmoreli_smartgym";
        private Conexion con = new Conexion("Server=www.johnny.heliohost.org;Port=5432;User Id=itmoreli_user;Password=12345678;Database=itmoreli_smartgym");

        public void inserta()
        {

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
            NpgsqlCommand cmd = new NpgsqlCommand("Insert into rut_ejer values( '"+idrutina+"' , '"+idejercicio+"')", con.Conn);
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd);
            DataSet datos = new DataSet();
            adapter.Fill(datos);
            con.Close();
            

        }


    }
}


