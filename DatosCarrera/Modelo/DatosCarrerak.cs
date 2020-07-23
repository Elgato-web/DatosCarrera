using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.Runtime.CompilerServices;
namespace DatosCarrera.Modelo
{
    class DatosCarrerak
    {
        private static string cadenaConexion = "server = DESKTOP-U1CHEML; database = TI2020; user id = sa; password = ayapamba259";
        public static int carrera(DatosCarrera datosCarrera)
        {
            //1.configurar la conexion de datos  con una  fuente de datos 
            //string cadenaConexion="Server=DatosCarrera;database=TI2020;user id=sa; password=ayapamba259;";
            //definir un objeto tipo conexion 
            SqlConnection conn = new SqlConnection(cadenaConexion);
            //2.definir la operacion a realizar en el motor sdd
            //scribir sentencia SQL
            string sql = "insert into DatosCarrera(Codigo,Materia,Creditos,Carrera," + "Nivel) values(@codigo,@materia,@creditos,@carrera,@nivel)";
            //definir un comnando para ejecutar esa sentencia sql 
            SqlCommand comando = new SqlCommand(sql, conn);
            comando.CommandType = System.Data.CommandType.Text; //valor por defecto
            comando.Parameters.AddWithValue("@codigo", datosCarrera.Codigo);
            comando.Parameters.AddWithValue("@materia", datosCarrera.Materia);
            comando.Parameters.AddWithValue("@creditos", datosCarrera.Creditos);
            comando.Parameters.AddWithValue("@carrera  ", datosCarrera.Carrera);
            comando.Parameters.AddWithValue("@nivel", datosCarrera.Nivel);
            //3. se habre la conexion y se ejecuta el comando
            conn.Open();
            int x = comando.ExecuteNonQuery();
            //4. cerrar la conexion
            conn.Close();
            return x;

        }

        public static int btnEliminar(string codigo)
        {
            SqlConnection conn = new SqlConnection(cadenaConexion);
            string sql = "delete from DatosCarrera where Codigo=@codigo";
            SqlCommand comando = new SqlCommand(sql, conn);
            comando.Parameters.AddWithValue("@codigo", codigo);
            conn.Open();
            int x = comando.ExecuteNonQuery();
            conn.Close();
            return x;
        }
        public static DataTable getAll()
        {


            //1. definir y configurar conexión
            SqlConnection conn = new SqlConnection(cadenaConexion);
            //2. Definir y Cinfigurar la operacion a realizar en el motor de BDD 
            //escribir sentencia sql
            string sql = "select Codigo,Materia,Creditos,Carrera,Nivel,FechadeCreacion " + "from DatosCarrera " +
                "order by Codigo,Materia";
            //2.1 Definir un adptador de datos: es un puente que permite pasa los datos de muestra , hacia el datatable
            SqlDataAdapter ad = new SqlDataAdapter(sql, conn);
            //3 recuperamos los datos 
            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;

        }
        public static DatosCarrera getcarrera(String Codigo)
        {
            SqlConnection conn = new SqlConnection(cadenaConexion);
            string sql = "select Codigo,Materia,Creditos,Carrera,Nivel,FechadeCreacion " + "from DatosCarrera " +
                "order by Codigo,Materia";
            SqlDataAdapter ad = new SqlDataAdapter(sql, conn);
            ad.SelectCommand.Parameters.AddWithValue("@codigo", Codigo);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            DatosCarrera carrera = new DatosCarrera();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow fila in dt.Rows)
                {
                    carrera.Codigo = fila["Codigo"].ToString();
                    carrera.Materia = fila["Materia"].ToString();
                    carrera.Creditos = int.Parse(fila["Creditos"].ToString());
                    carrera.Carrera = fila["Carrera"].ToString();
                    carrera.Nivel = int.Parse(fila["Nivel"].ToString());
                    break;

                }
            }
            return carrera;
        }
        public static int update(DatosCarrera datosCarrera)
        {
            SqlConnection conn = new SqlConnection(cadenaConexion);
            String sql = "UPDATE DatosCarrera SET Codigo=@Codigo, Materia=@Materia, Creditos=@Creditos,Carrera=@Carrera,Nivel=@Nivel";
            SqlCommand comando = new SqlCommand(sql, conn);
            comando.Parameters.AddWithValue("@Codigo", datosCarrera.Codigo);
            comando.Parameters.AddWithValue("@Materia",datosCarrera.Materia);
            comando.Parameters.AddWithValue("@Creditos",datosCarrera.Creditos);
            comando.Parameters.AddWithValue("@Carrera", datosCarrera.Carrera);
            comando.Parameters.AddWithValue("@Nivel",datosCarrera.Nivel);
            conn.Open();
            int x = comando.ExecuteNonQuery();
            conn.Close();
            return x;


        }

    }
}