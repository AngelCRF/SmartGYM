using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GYM
{
    class Consultas
    {
        private string datosCarlos = "Server=localhost; Port=5432; User Id=postgres; Password=23c17m; Database=smartgym";
        private string datosKevin = "Server=localhost; Port=5434; User Id=postgres; Password=23c17m; Database=smartgym";
        private string data = "Server=www.johnny.heliohost.org;Port=5432;User Id=itmoreli_user;Password=12345678;Database=itmoreli_smartgym";
        private Conexion con = new Conexion("Server=www.johnny.heliohost.org;Port=5432;User Id=itmoreli_user;Password=12345678;Database=itmoreli_smartgym");

        internal string fechaDePagoCliente(int id)
        {
            string fecha="";
            con.Open();
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(("select fecha_de_corte from cliente where idcliente = '"+id+"' "), con.Conn);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                fecha = Convert.ToString(reader.GetDateTime(0));
                reader.Close();
                con.Close();
            }
            catch (Exception ex) { MessageBox.Show("error de consulta en fecha de corte"+ex.Message); con.Close(); }
            con.Close();
            return fecha;
        }

        internal void MostrarTrabajadores(DataGridView aux)
        {
            con.Open();
            try
            {
                NpgsqlCommand cmd2 = new NpgsqlCommand(("select idtrabajador, nombre, apellido1, apellido2, sueldo, puesto  from trabajador "), con.Conn);
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd2);
                DataSet datos = new DataSet();
                adapter.Fill(datos);
                aux.DataSource = datos.Tables[0];
            }
            catch (Exception ex) { MessageBox.Show("error de consulta en mostrar trabajadores: " + ex.Message); con.Close(); }
            con.Close();
        }

        internal void MostrarRutinaCliente(DataGridView aux , int id)
        {
            int rutina = -1;
           
            con.Open();
            try
            {
                NpgsqlCommand cmd1 = new NpgsqlCommand(("select idrutina from cliente where idcliente= '" + id + "' "), con.Conn);
                NpgsqlDataReader reader1 = cmd1.ExecuteReader();
                reader1.Read();
                rutina = reader1.GetInt32(0);
                reader1.Close();             
                NpgsqlCommand cmd2 = new NpgsqlCommand(("select ejercicio.repeticiones, ejercicio.descripcion, ejercicio.idaparato from rut_eje, ejercicio where idrut= '" + rutina + "' and idejer = idejercicio "), con.Conn);
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd2);
                DataSet datos = new DataSet();
                adapter.Fill(datos);
                aux.DataSource = datos.Tables[0];
            }
            catch (Exception ex) { MessageBox.Show("error de consulta en rutina de usuario: "+ex.Message); con.Close(); }         
            con.Close();
        }

        internal bool InsertTrabajador(string nombre, string ap1, string ap2, string calle, string numero, string interior, string colonia, string ciudad, string contraseña, string sueldo, string puesto)
        {
            int idtrab = -1;
            int iddir = -1;
            con.Open();
            try
            {
                NpgsqlCommand cmd2 = new NpgsqlCommand("select * from trabajador order by idtrabajador desc limit 1;", con.Conn);
                NpgsqlDataReader reader2 = cmd2.ExecuteReader();
                if (reader2.Read())
                {
                    idtrab = Convert.ToInt32(reader2.GetInt32(0)) + 1;
                }
                else
                {
                    idtrab = 1;
                }
                reader2.Close();
                NpgsqlCommand cmd3 = new NpgsqlCommand("select iddireccion from direccion order by iddireccion desc limit 1;", con.Conn);
                NpgsqlDataReader reader3= cmd3.ExecuteReader();
                if (reader3.Read())
                {
                    iddir = Convert.ToInt32(reader3.GetInt32(0)) + 1;
                }
                else
                {
                    iddir = 1;
                }
                MessageBox.Show("id direcc   " + iddir);
                reader3.Close();
                if (idtrab > -1 && iddir>-1)
                {
                    try
                    {
                        NpgsqlCommand cmd = new NpgsqlCommand("insert into direccion (iddireccion,calle, numero, interior, colonia, ciudad) values ('" + iddir + "','" + calle + "', '" + numero + "' ,'" + interior + "', '"+colonia+"', '"+ciudad+"') ", con.Conn);
                        NpgsqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        reader.Close();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error con la dirección del trabajador");
                        return false;
                    }
                    try
                    {
                        NpgsqlCommand cmd = new NpgsqlCommand("insert into trabajador (idtrabajador,nombre, apellido1, apellido2, contraseña, iddireccion, sueldo, puesto) values ('" + idtrab + "','" + nombre + "', '" + ap1 + "' ,'" + ap2 + "', '" + contraseña + "', '" + iddir + "', '"+sueldo+"', '"+puesto+"') ", con.Conn);
                        NpgsqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        MessageBox.Show("Consulta realizada");
                        reader.Close();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error del trabajador");
                        NpgsqlCommand cmd = new NpgsqlCommand("delete from  direccion where iddireccion = '" + iddir + "' ", con.Conn);
                        NpgsqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        reader.Close();
                        return false;
                    }
                    
                }
            }
            catch (Exception ex) { con.Close(); MessageBox.Show("Error al consultar trabajadores y direcciones" + ex.Message); return false; }
            con.Close();
            return true;
        
    }

        internal void EliminarTrabajador(string id)
        {
            con.Open();
            NpgsqlTransaction trans = con.Conn.BeginTransaction(); ;

            try
            {

                NpgsqlCommand cmd = new NpgsqlCommand(("select iddireccion from trabajador where idtrabajador = '" + id + "'"), con.Conn);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                int dir = reader.GetInt32(0);
                reader.Close();

                NpgsqlCommand cmd2 = new NpgsqlCommand(("delete from trabajador where idtrabajador = '" + id + "'"), con.Conn);
                NpgsqlDataReader reader2 = cmd2.ExecuteReader();

                NpgsqlCommand cmd3 = new NpgsqlCommand(("delete from direccion where iddireccion = '" + dir + "'"), con.Conn);
                NpgsqlDataReader reader3 = cmd3.ExecuteReader();

                MessageBox.Show("Trabajador eliminado exitosamente ", "Eliminación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                trans.Commit();


            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar al trabajador " + ex.Message, "Error de liminación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                trans.Rollback();
                con.Close();
            }
            con.Close();
        }

        internal void ActualizarTrabajador(string idt, string idd, List<TextBox> aux, String puesto)
        {
            con.Open();
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("Update  trabajador  set nombre ='"+aux.ElementAt(0).Text+"', apellido1 = '"+aux.ElementAt(1).Text+
                    "', apellido2 = '"+aux.ElementAt(2).Text+"', contraseña = '"+aux.ElementAt(8).Text+"', sueldo = '"+aux.ElementAt(9).Text+"', puesto = '"+ puesto + "' where idtrabajador = '"+idt+"' ;", con.Conn);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                MessageBox.Show("Consulta realizada");
                reader.Close();
                NpgsqlCommand cmd2 = new NpgsqlCommand("update direccion set calle = '"+aux.ElementAt(3).Text+"', numero = '"+aux.ElementAt(4).Text+"', interior = '"+aux.ElementAt(5).Text+
                    "', colonia= '"+aux.ElementAt(6).Text+"', ciudad = ' "+aux.ElementAt(7).Text+"'  where iddireccion = '"+idd+"'", con.Conn);
                NpgsqlDataReader reader2 = cmd2.ExecuteReader();
                reader2.Read();
                MessageBox.Show("Consulta realizada");           
                reader2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el trabajaro" + ex.Message);
            }
            con.Close();
        }

        internal void ObtenerDirTrab(int direccion, List<TextBox> aux)
        {
            con.Open();
            try
            {
                NpgsqlCommand cmd2 = new NpgsqlCommand("select * from direccion where iddireccion = '" + direccion + "'", con.Conn);
                NpgsqlDataReader reader2 = cmd2.ExecuteReader();
                reader2.Read();
                aux.ElementAt(3).Text = reader2.GetString(1);
                aux.ElementAt(4).Text = reader2.GetInt32(2)+"";
                aux.ElementAt(5).Text = reader2.GetInt32(3)+"";
                aux.ElementAt(6).Text = reader2.GetString(4);
                aux.ElementAt(7).Text = reader2.GetString(5);


                reader2.Close();
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Ervror con la dirección");
                con.Close();
            }
        }

        public int  obtenerTrabajador(int id, List<TextBox> aux, ComboBox cb)
        {
            int dir = -1;
            con.Open();
            try
            {
                NpgsqlCommand cmd2 = new NpgsqlCommand("select * from trabajador where idtrabajador = '" + id + "'", con.Conn);
                NpgsqlDataReader reader2 = cmd2.ExecuteReader();
                reader2.Read();
                aux.ElementAt(0).Text = reader2.GetString(1);
                aux.ElementAt(1).Text = reader2.GetString(2);
                aux.ElementAt(2).Text = reader2.GetString(3);
                aux.ElementAt(8).Text = reader2.GetString(4);
                aux.ElementAt(9).Text = reader2.GetInt32(6)+ "";
                cb.Text = reader2.GetString(7);
                int a = reader2.GetInt32(5);
                reader2.Close();
                con.Close();
                return a;
            

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se encontró al trabajador "+ ex.Message);
                con.Close();
                return -1;
            }
            }

        internal bool BuscarContraseña(string tabla, int id, string password )
        {
            tabla = tabla.ToLower();
            con.Open();
            string consulta = "";
            switch (tabla)
            {
                case "cliente":
                    consulta = "select * from cliente where idcliente= '" + id + "' and contraseña = '" + password + "'";
                    break;
                case "trabajador":
                    consulta = "select * from trabajador where idtrabajador= '" + id + "' and contraseña = '" + password + "'  and puesto= 'Recepcionista'";
                    break;
                case "instructor":
                    consulta = "select * from trabajador where idtrabajador= '" + id + "' and contraseña = '" + password + "' and puesto= 'Instructor' ";
                    break;
                case "administrador":
                    consulta = "select * from trabajador where idtrabajador= '" + id + "' and contraseña = '" + password + "' and puesto= 'Administrador' ";
                    break;
            }
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(consulta, con.Conn);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    reader.Close();
                    con.Close();
                    return true;
                }
               else
                {
                    reader.Close();
                    con.Close();
                    return false;
                }
            }
            catch (Exception) { MessageBox.Show("error de consulta"); con.Close(); return false; }
            con.Close();
            return false;
        }

        public Consultas()
        {
            //colocar su ruta
            //con = new Conexion(datosCarlos);
            con = new Conexion(datosKevin);
        }

        public void inserta()
        {

        }

        public bool insertaC(string[] DatosC, string[] DatosD)//Clientes
        {
            con.Open();
            try
            {
                String Aux;
                int IDD, IDC,H;
                NpgsqlDataReader reader;
                NpgsqlTransaction T;
                String consultaIDC = "SELECT * FROM cliente ORDER BY idcliente DESC LIMIT 1;";
                String consultaIDD = "SELECT * FROM direccion ORDER BY iddireccion DESC LIMIT 1;";
                NpgsqlCommand cmdIDD = new NpgsqlCommand(consultaIDD, con.Conn);
                reader = cmdIDD.ExecuteReader();
                reader.Read();               
                IDD = Convert.ToInt32(reader.GetInt32(0)) + 1;
                reader.Close();
                String consultaD = "INSERT INTO direccion (iddireccion, calle, numero, interior, colonia, ciudad) Values ('" +
                     IDD + "','" + DatosD[0] + "','" + DatosD[1] + "','" + DatosD[2]
                     + "','" + DatosD[3] + "','" + DatosD[4] + "');";
                NpgsqlCommand cmdD = new NpgsqlCommand(consultaD, con.Conn);
                NpgsqlCommand cmdIDC = new NpgsqlCommand(consultaIDC, con.Conn);
                NpgsqlDataReader reader2 = cmdD.ExecuteReader();
                reader2.Read();
                reader2.Close();
                NpgsqlDataReader reader4 = cmdIDC.ExecuteReader();
                reader4.Read();
                IDC = Convert.ToInt32(reader4.GetInt32(0)) + 1;
                reader4.Close();
                try
                {
                    String consultaC = "INSERT INTO cliente (idcliente, nombres, apellido_1, apellido_2, telefono_movil, correo_electronico, iddireccion, tipo_de_pago, fecha_de_corte, tipo_de_sangre, contraseña, idrutina) Values('" +
                        IDC + "','" + DatosC[0] + "','" + DatosC[1] + "','" + DatosC[2] +
                        "','" + DatosC[3] + "','" + DatosC[4] + "','" + IDD + "','" + DatosC[5] +
                        "','" + DatosC[6] + "','" + DatosC[7] + "','" + DatosC[8] + "','" + 1 + "');";
                    NpgsqlCommand cmdC = new NpgsqlCommand(consultaC, con.Conn);
                    NpgsqlDataReader reader3 = cmdC.ExecuteReader();
                    reader3.Read();
                    reader3.Close();
                    H = Hora();
                    if (H != 0)
                    {
                        if (H <= 10)
                        {
                            Aux = H + ":00";
                        }
                        else
                        {
                            Aux = "0" + H + ":00";
                        }
                    }else
                    {
                        Aux = "No se encontro una hora";
                    }
                    MessageBox.Show(("Id= " + IDC + "\nContraseña= " + DatosC[8]+ "\nHora Sugerida: "+Aux),"Cliente guardado ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Mes(DatosC[0]);
                    con.Close();
                    return true;
                }
                catch (Exception e)
                {
                    String consultaE = "DELETE FROM direccion WHERE iddireccion="+IDD+";";
                    NpgsqlCommand cmdE = new NpgsqlCommand(consultaE, con.Conn);
                    reader = cmdE.ExecuteReader();
                    reader.Read();
                    reader.Close();
                    MessageBox.Show("Error" + e.Message);
                    con.Close();
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error "+ e.Message);
                con.Close();
                return false;
            }
        }

        private void Mes(String Nom)
        {
            // 19/06/2015 10:03:06
            DateTime T = DateTime.Now;
            String Aux=T.ToString().Split(' ')[0];
            Aux = Aux.Split('/')[1] + Aux.Split('/')[2];
            StreamWriter sw = new StreamWriter(Aux, true);
            StreamReader sr = new StreamReader(Aux+".txt");
            int i = 0;
            while (i != -1)
            {
                String Lin = sr.ReadLine();
                if (Lin != null)
                {
                    i++;
                }
                else
                {
                    i = 0;
                }
            }
            sr.Close();
            sw.WriteLine((i+1)+".- "+Nom.ToUpper());
            sw.Close();
        }

        private int Hora()
        {
            try
            {
                List<int> Hs = new List<int>();
                int H = 0;
                int[] Horas = new int[12];
                String consulta = "SELECT hora_de_llegada FROM cliente;";
                NpgsqlCommand cmd = new NpgsqlCommand(consulta, con.Conn);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Hs.Add(Convert.ToInt32(reader.NextResult().ToString().Split(':')[0]));
                }
                reader.Close();
                foreach (int ep in Hs)
                {
                    for (int i = 0; i < 12; i++)
                    {
                        if (ep==i)
                        {
                            Horas[i]++;
                        }
                    }
                }
                H = Horas.Min();
                return H;
            }
            catch (Exception ex)
            {
                con.Close();
                return 0;
            }
        }

        public bool updateC(int idd, string IDC,string[] DatosC, string[] DatosD)//Clientes
        {
            try
            {
                con.Open();
                String consultaD = "UPDATE direccion SET calle='" + DatosD[0] + "', numero=" + DatosD[1] + ", interior=" + DatosD[2]
                     + ", colonia='" + DatosD[3] + "', ciudad='" + DatosD[4] + "' WHERE iddireccion=" + idd + ";";
                NpgsqlCommand cmdD = new NpgsqlCommand(consultaD, con.Conn);
                NpgsqlDataReader reader2 = cmdD.ExecuteReader();
                reader2.Read();
                reader2.Close();
                String consultaC = "UPDATE cliente SET nombres='" + DatosC[0] + "', apellido_1='" + DatosC[1] +
                    "', apellido_2 ='" + DatosC[2] + "', telefono_movil='" + DatosC[3] + "', correo_electronico='" + DatosC[4] +
                    "', iddireccion='" + idd + "', tipo_de_pago='" + DatosC[5] + "', fecha_de_corte='" + DatosC[6] +
                    "', tipo_de_sangre='" + DatosC[7] + "', contraseña='" + DatosC[8] + "' WHERE idcliente = " + IDC + ";";
                MessageBox.Show(consultaC, "");
                NpgsqlCommand cmdC = new NpgsqlCommand(consultaC, con.Conn);
                NpgsqlDataReader reader3 = cmdC.ExecuteReader();
                reader3.Read();
                reader3.Close();
                MessageBox.Show("Cliente guardado ", ("Id= " + IDC + "\n Contraseña= " + DatosC[8]), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                con.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error"+e.Message);
                con.Close();
                return false;
            }
        }

        public bool insertaA(string[] DatosA)//Aparatos
        {
            con.Open();
            try
            {
                NpgsqlDataReader reader;
                int IDA;
                
                String consultaIDA = "SELECT * FROM aparatos ORDER BY idaparato DESC LIMIT 1;";
                NpgsqlCommand cmdIDA = new NpgsqlCommand(consultaIDA, con.Conn);
                reader = cmdIDA.ExecuteReader();
                reader.Read();
                IDA = Convert.ToInt32(reader.GetInt32(0)) + 1;
                reader.Close();
                String consulta = "INSERT INTO Aparatos (idaparato, nombre, numero_serie, tipo, fecha_de_compra, fecha_de_mantenimiento) Values('" +
                    IDA + "','" + DatosA[0] + "','" + DatosA[1] + "','" + DatosA[2] +
                    "','" + DatosA[3] + "','" + DatosA[4] + "');";
                NpgsqlCommand cmd = new NpgsqlCommand(consulta, con.Conn);
                NpgsqlDataReader reader1 = cmd.ExecuteReader();
                reader1.Read();
                reader1.Close();
                MessageBox.Show("Aparato guardado ", "Se guardo con exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                con.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error"+ e.Message);
                con.Close();
                return false;
            }
        }

        public bool updateA(string[] D, int id)
        {
            con.Open();
            try
            {
                String consulta = "UPDATE aparatos SET nombre ='" + D[0] + "', numero_serie =" + D[1] + ", tipo ='" + D[2] + "', fecha_de_compra ='" + D[3]
                    + "', fecha_de_mantenimiento ='" + D[4] + "' WHERE idaparato =" + id + ";";
                NpgsqlCommand cmd = new NpgsqlCommand(consulta, con.Conn);
                NpgsqlDataReader reader1 = cmd.ExecuteReader();
                reader1.Read();
                reader1.Close();
                MessageBox.Show("Aparato guardado ", "Se guardo con exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                con.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error" + e.Message);
                con.Close();
                return false;
            }
        }

        public string Selecciona(string tabla, string idt, string id)
        {
            tabla=tabla.ToLower();
            idt=idt.ToLower();
            try
            {
                String Cons, consulta;
                String [] Data;
                NpgsqlDataReader reader;
                NpgsqlCommand cmd;
                int idd;
                switch (tabla)
                {
                    case "cliente":
                        con.Open();
                        consulta = "SELECT * FROM cliente WHERE idcliente = '" + id + "';";
                        cmd = new NpgsqlCommand(consulta, con.Conn);
                        reader = cmd.ExecuteReader();
                        reader.Read();
                        Cons = ""+reader.GetInt32(0)+","+reader.GetString(1)+","+reader.GetString(2)+","+reader.GetString(3)+","+reader.GetString(4)+","+reader.GetString(5)+","+reader.GetString(6)+"," + reader.GetString(9)+","+reader.GetTimeStamp(10)+","+reader.GetString(11)+","+ reader.GetInt32(7)+",";
                        idd = reader.GetInt32(7);
                        consulta = "SELECT * FROM direccion WHERE iddireccion = '" + idd + "';";
                        reader.Close();
                        cmd = new NpgsqlCommand(consulta, con.Conn);
                        reader = cmd.ExecuteReader();
                        reader.Read();
                        Cons += reader.GetString(1) + "," + reader.GetInt32(2) + "," + reader.GetInt32(3) + "," + reader.GetString(4) + "," + reader.GetString(5);
                        reader.Close();
                        con.Close();
                        return Cons;
                        break;
                    case "aparatos":
                        con.Open();
                        consulta = "SELECT * FROM aparatos WHERE idaparato = '" + id + "';";
                        cmd = new NpgsqlCommand(consulta, con.Conn);
                        reader = cmd.ExecuteReader();
                        reader.Read();
                        Cons = ""+reader.GetInt32(0)+","+reader.GetString(1)+","+ reader.GetInt32(2) + ","+reader.GetString(3) + "," + reader.GetTimeStamp(4) + "," + reader.GetTimeStamp(5);
                        reader.Close();
                        con.Close();
                        return Cons;
                        break;
                }
            }
           
            catch (Exception e)
            {
                MessageBox.Show("Error" + e.Message);
                con.Close();
                return null;
            }
            return null;
        }

        public void Elimina(string tabla, string id)
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
                    catch (Exception e)
                    {
                        MessageBox.Show("Error", e.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        con.Close();
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
                        con.Close();
                    }
                    break;
                case "rutina":
                    string consulta2 = ("delete from rut_eje where idrut= '" + id + "';");
                    ejecutarConsulta(consulta2);
                    consulta = ("delete from rutina where idrutina= '" + id + "';");
                    break;
                default:
                    break;
            }
            ejecutarConsulta(consulta);
        }

        public void consultaClienteInst(DataGridView aux)
        {
            con.Open();
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(("select idcliente, nombres, apellido_1, apellido_2, idrutina from cliente order by idcliente"), con.Conn);
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd);
                DataSet datos = new DataSet();
                adapter.Fill(datos);
                aux.DataSource = datos.Tables[0];
            }
            catch(Exception ex) { MessageBox.Show("Error en consulta clientes: " + ex.Message); }
            con.Close();
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
            catch (Exception) { MessageBox.Show("error de consulta"); }
            con.Close();
        }

        public void Modifica()
        {
        }

        public DataSet dataGridView(string tabla, string nombreId)
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
                    consulta = ("select idaparato, repeticiones, descripcion from  Rut_Eje, ejercicios where idrut= '" + nombreId + " and "
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

        internal void updateRutinaCliente(string idcliente, string idrutina)
        {
            string consulta= "update cliente set idrutina= '"+idrutina+"' where idcliente= '"+idcliente+"'";
            ejecutarConsulta(consulta);
        }

        public DataSet consultaaparatos(DataGridView aux)
        {
            con.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(("select * from " + "aparatos" + " order by " + "idaparato" + ""), con.Conn);
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd);
            DataSet datos = new DataSet();
            adapter.Fill(datos);
            aux.DataSource = datos.Tables[0];
            con.Close();
            return datos;
        }

        public DataSet consultaClientes(DataGridView aux)
        {
            con.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(("Select idcliente, nombres, apellido_1, apellido_2, telefono_movil, correo_electronico, cliente.iddireccion, tipo_de_sangre, fecha_de_corte, tipo_de_pago, calle, numero, interior, colonia, ciudad From cliente, direccion where cliente.iddireccion = direccion.iddireccion order by idcliente;"), con.Conn);
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd);
            DataSet datos = new DataSet();
            adapter.Fill(datos);
            aux.DataSource = datos.Tables[0];
            con.Close();
            return datos;
        }

        public DataSet consultapagos(DataGridView aux)
        {
            con.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(("select  Nombres, Fecha_de_corte from " + "cliente" + " order by " + "idcliente" + ""), con.Conn);
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd);
            DataSet datos = new DataSet();
            adapter.Fill(datos);
            aux.DataSource = datos.Tables[0];
            con.Close();
            return datos;
       }

        public DataSet consultacortes(DataGridView aux)
        {
            var culture = new CultureInfo("en-GB");
            DateTime T = DateTime.Now;
            string fecha = T.ToString(culture);
            fecha = fecha.Split(' ')[0];
            int num = Convert.ToInt32(fecha.Split('/')[0])/10;
            con.Open();
            fecha = "%" + fecha.Split('/')[2] + "-"+fecha.Split('/')[1] + "-" + num + "_" + "%";
            String consulta = "select Nombres, Fecha_de_corte from cliente WHERE Fecha_de_corte::text LIKE '"+fecha+"' order by idcliente";
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(consulta, con.Conn);
                NpgsqlDataAdapter adapter1 = new NpgsqlDataAdapter(cmd);
                DataSet datos = new DataSet();
                adapter1.Fill(datos);
                aux.DataSource = datos.Tables[0];
                con.Close();
                return datos;
            }catch(Exception ex)
            {
                MessageBox.Show("No se encuentran cortes cercanos al dia de hoy", "Error");
                return null;
            }
        }

        public DataSet consultamant(DataGridView aux)
        {
            con.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(("select  Nombre, numero_serie, fecha_de_mantenimiento from " + "Aparatos" + " order by " + "idaparato" + ""), con.Conn);
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd);
            DataSet datos = new DataSet();
            adapter.Fill(datos);
            aux.DataSource = datos.Tables[0];
            con.Close();
            return datos;
        }

        public DataSet consultaEjercicios(DataGridView aux)
        {
            DataSet datos = new DataSet();
            con.Open();
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(("select * from ejercicio order by idejercicio" ), con.Conn);
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd);                
                adapter.Fill(datos);
                aux.DataSource = datos.Tables[0];
                con.Close();
            }catch(Exception ex) { MessageBox.Show("Error al mostrar ejercicios: "+ex.Message); }
            return datos;
        }

        public DataSet consultaRutinaEjercicios(DataGridView aux, int id)
        {
            con.Open();
            DataSet datos = new DataSet();
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(("select idaparato, repeticiones, descripcion from  Rut_Eje, ejercicio where idrut= '" + id + "' and "
                + " Rut_Eje.idejer = ejercicio.idejercicio"), con.Conn);
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd);
                datos = new DataSet();
                adapter.Fill(datos);
                aux.DataSource = datos.Tables[0];
                con.Close();
                return datos;
            }
            catch(Exception ex) { MessageBox.Show("Error en consulta de ejercicios de rutina " + ex.Message); con.Close(); }
            con.Close();
            return datos;
        }

        public DataSet consultaejerciciosContenidos(DataGridView aux, int id)
        {
            con.Open();
            DataSet datos = new DataSet();
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(("select ejercicio.idejercicio, ejercicio.idaparato, ejercicio.repeticiones, ejercicio.descripcion  from  Rut_Eje, ejercicio where idrut= '" + id + "' and "
                + " Rut_Eje.idejer = ejercicio.idejercicio"), con.Conn);
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd);
                datos = new DataSet();
                adapter.Fill(datos);
                aux.DataSource = datos.Tables[0];
                con.Close();
                return datos;
            }
            catch (Exception ex) { MessageBox.Show("Error en consulta de ejercicios de rutina " + ex.Message); con.Close(); }
            con.Close();
            return datos;
        }

        public void ActualizarRutina(string id, string nombre, string horas)
        {
            String cmd= ("update rutina set nombre= '"+nombre+"', horas= '"+horas+"' where idrutina = '"+id+"'");
            ejecutarConsulta(cmd);
        }

        public void AgregarEjercicios(string idrutina, string idejercicio)
        {
            con.Open();
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("Insert into rut_eje (idrut, idejer) values( '" + idrutina + "' , '" + idejercicio + "')", con.Conn);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                reader.Close();
            }
            catch (Exception ex )
            {
                MessageBox.Show("No se pudo realizar la consulta de agregar ejercicio"+ ex.Message);
            }
            con.Close(); 
        }

        public void insertaEjercicio(string idaparato, string repeticiones, string desc)
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
                    NpgsqlCommand cmd = new NpgsqlCommand("insert into ejercicio (idejercicio,idaparato, repeticiones, descripcion) values ('" + id + "','" + idaparato + "', " + repeticiones + " ,'" + desc + "') ", con.Conn);
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    reader.Close();
                }
            }
            catch (Exception ex) { con.Close(); MessageBox.Show("Error al agregar ejercicio"+ ex.Message); }
            con.Close();
        }

        public string CrearRutina(string nombre, string horas)
        {
            int id = -1;
            con.Open();
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("select * from rutina order by idrutina desc limit 1", con.Conn);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read()) { id = Convert.ToInt32(reader.GetInt32(0)) + 1; } else { id = 1; }
                reader.Close();
                NpgsqlCommand cmd2 = new NpgsqlCommand("insert into rutina(idrutina, nombre, hora) values ('" + id + "', '" + nombre + "', '" + horas + "');", con.Conn);
                NpgsqlDataReader reader2 = cmd2.ExecuteReader();
                reader2.Read();
                reader.Close();
                MessageBox.Show("Rutina agregada exitosamente");
            }
            catch (Exception ex) { MessageBox.Show("Error al crear rutina"+ ex.Message); }
            con.Close();
            return Convert.ToString(id);
        }

        public void eliminarEjercicios(string idrutina, string idejercicio)
        {
            con.Open();
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("delete from rut_eje where idrut='" + idrutina + "' and idejer = '" + idejercicio + "'", con.Conn);
                NpgsqlDataReader reader2 = cmd.ExecuteReader();
                reader2.Read();
            }
            catch (Exception ex) { MessageBox.Show("Error al elminar el ejercicio de la rutina"+ex.Message); }
            con.Close(); 
        }
    }
}


