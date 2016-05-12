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
        private String datosCarlos = "Server=localhost; Port=5432; User Id=postgres; Password=23c17m; Database=smartgym";
        private String data = "Server=www.johnny.heliohost.org;Port=5432;User Id=itmoreli_user;Password=12345678;Database=itmoreli_smartgym";
        private Conexion con = new Conexion("Server=www.johnny.heliohost.org;Port=5432;User Id=itmoreli_user;Password=12345678;Database=itmoreli_smartgym");

        public Consultas()
        {
            //colocar su ruta
            con = new Conexion(datosCarlos);
        }

        public void inserta()
        {

        }

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
                String consultaD = "INSERT INTO direcciones (iddireccion, calle, numero, interior, colonia, ciudad) Values('"+
                     IDD + "','" + DatosD[0] + "','" + DatosD[1] + "','" + DatosD[2] 
                     + "','" + DatosC[3] + "','" + DatosC[4]+"');";
                NpgsqlCommand cmdD = new NpgsqlCommand(consultaD, con.Conn);
                NpgsqlCommand cmdIDC = new NpgsqlCommand(consultaIDC, con.Conn);
                reader = cmdIDC.ExecuteReader();
                reader.Read();
                IDC = Convert.ToInt32(reader.GetInt32(0)) + 1;
                String consultaC = "INSERT INTO clientes (idcliente, nombres, apellido_1, apellido_2, telefono_movil, correo_electronico, iddireccion, tipo_de_pago, fecha_de_corte, tipo_de_sangre, contraseña, idrutina) Values('" +
                    IDC + "','" + DatosC[0] + "','" + DatosC[1] + "','" + DatosC[2] +
                    "','" + DatosC[3] + "','" + DatosC[4] + "','" + IDD + "','" + DatosC[5] +
                    "','" + DatosC[6] + "','" + DatosC[7] + 1 + "');";
                NpgsqlCommand cmdC = new NpgsqlCommand(consultaC, con.Conn);
                MessageBox.Show("Cliente guardado ", ("Id= " + IDC + "\n Contraseña= " + DatosC[7]), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                con.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error", e.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
                return false;
            }
        }

        public bool insertaA(String [] DatosA)//Aparatos
        {
            try
            {
                NpgsqlDataReader reader;
                int IDA;
                con.Open();
                String consultaIDA = "SELECT * FROM aparatos ORDER BY idaparato DESC LIMIT 1;";
                NpgsqlCommand cmdIDA = new NpgsqlCommand(consultaIDA, con.Conn);
                reader = cmdIDA.ExecuteReader();
                reader.Read();
                IDA = Convert.ToInt32(reader.GetInt32(0)) + 1;
                String consulta = "INSERT INTO Aparatos (idaparato, nombre, numero_serie, tipo, fecha_de_compra, fecha_de_mantenimiento) Values('" +
                    IDA + "','" + DatosA[0] + "','" + DatosA[1] + "','" + DatosA[2] +
                    "','" + DatosA[3] + "','" + DatosA[4]+ "');";
                NpgsqlCommand cmd = new NpgsqlCommand(consulta, con.Conn);
                MessageBox.Show("Aparato guardado ","Se guardo con exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                con.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error", e.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public String Selecciona(String tabla, String idt, String id)
        {
            try
            {
            NpgsqlDataReader reader;
            con.Open();
            String consulta = "SELECT * FROM" + tabla+ "WEHERE "+idt+" = "+id+";";
            NpgsqlCommand cmd = new NpgsqlCommand(consulta, con.Conn);
            reader = cmd.ExecuteReader();
            reader.Read();
            con.Close();
                return reader.ToString();
            }
            catch(Exception e)
            {
                return null;
            }
        }

        public void Elimina(String tabla, String id) 
        {
            tabla = tabla.ToLower();
            String consulta = "";
            switch (tabla)
            {
                case "clientes":
                    try
                    {
                        consulta = ("delete from clientes where idcliente= '" + id + "';");
                        con.Open();
                        NpgsqlCommand cmd = new NpgsqlCommand(consulta, con.Conn);
                        con.Close();
                        MessageBox.Show("Cliente eliminado ", "Se elimino con exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    catch(Exception e)
                    {
                        MessageBox.Show("Error", e.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case "aparatos":
                    try
                    {
                        consulta = ("delete from aparatos where idaparato= '" + id + "';");
                        con.Open();
                        NpgsqlCommand cmd = new NpgsqlCommand(consulta, con.Conn);
                        con.Close();
                        MessageBox.Show("Aparato eliminado ", "Se elimino con exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Error", e.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case "rutina":
                    string consulta2= ("delete from rut_ejer where idrut= '" + id + "';");
                    ejecutarConsulta(consulta2);
                    consulta = ("delete from rutina where idrutina= '"+id+"';");
                    break;
                default:
                    break;
            }

            ejecutarConsulta(consulta);
        }

        private void ejecutarConsulta(string consulta)
        {
            con.Open();
            try
            {              
                NpgsqlCommand cmd = new NpgsqlCommand(consulta, con.Conn);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                reader.Close();
                
            }
            catch(Exception){ MessageBox.Show("error de consulta"); }
            con.Close();
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
                case "clientes":
                    consulta = ("select * from " + tabla + " order by " + nombreId + "");
                    break;
                case "aparatos":
                    consulta = ("select * from " + tabla + " order by " + nombreId + "");
                    break;
                case "rutina":
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

        internal void ActualizarRutina(string id, string nombre, string horas)
        {
            String cmd= ("update rutina set nombre= '"+nombre+"', horas= '"+horas+"' where idrutina = '"+id+"'");
            ejecutarConsulta(cmd);
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

        public void insertaEjercicio(string idaparato, string nombre, string desc)
        {
            int id = -1;
            con.Open();
            try
            {
                NpgsqlCommand cmd2 = new NpgsqlCommand("select * from ejercicio order by idejercicio desc limit 1;", con.Conn);
                NpgsqlDataReader reader2 = cmd2.ExecuteReader();
               
                if (reader2.Read())
                {
                    id = Convert.ToInt32(reader2.GetInt32(0)) + 1;
                }
                else
                {
                    id = 1;
                }

                reader2.Close();
                if (id > -1)
                {
                    NpgsqlCommand cmd = new NpgsqlCommand("insert into ejercicio (idejercicio,idparato, repeticiones, descripcion) values('" + id + "','" + idaparato + "','" + nombre + "','" + desc + "') ", con.Conn);
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    reader.Close();
                }
            }
            catch (Exception) { con.Close(); MessageBox.Show("Error al agregar ejercicio"); }
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
            NpgsqlCommand cmd = new NpgsqlCommand("Insert into rut_ejer values( '"+idrutina+"' , '"+idejercicio+"')", con.Conn);
            //NpgsqlDataReader lector = cmd.Read();
            //lector.Read();
            //lector.close();
             con.Close(); 
        }


    }
}


