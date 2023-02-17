using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
namespace Apartado_Grafico
{
    internal class ConexionBD
    {
        NpgsqlConnection conex = new NpgsqlConnection();
        static String servidor = "localhost";
        static String bd = "productos";
        static String user = "postgres";
        static String pass = "joseandres10";
        static String port = "5432";

        String cadenaConexion = "server=" + servidor + ";port=" + port + ";user id=" + user + ";password=" + pass + ";database=" + bd + ";";

        public NpgsqlConnection establecerConexion()
        {
            try
            {
                conex.ConnectionString = cadenaConexion;
                conex.Open();
                MessageBox.Show("Se conecto correctamente a la base de datos");
            }
            catch (Exception e)
            {
                MessageBox.Show("No se pudo conectar a la base de datos \n Error: " + e.ToString());
            }

            return conex;
        }
    }
}
