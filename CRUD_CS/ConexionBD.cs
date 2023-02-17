using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
namespace CRUD_CS
{
    internal class ConexionBD
    {
        private static NpgsqlConnection conex = new NpgsqlConnection("server=localhost;port=5432;User Id=postgres;Password=joseandres10; Database=productos");

        public static NpgsqlConnection establecerConexion()
        {
            try
            {
                if (conex.State == ConnectionState.Closed)
                { 
                    conex.Open();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("No se pudo conectar a la base de datos \n Error: " + e.ToString());
            }

            return conex;

        }

        public static void cerrarConexion()
        {
            if (conex.State == ConnectionState.Open) conex.Close();
        }

       
    }
}