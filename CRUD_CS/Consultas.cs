using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_CS
{
    internal class Consultas
    {
        public static DataSet mostrarTabla()
        {
            NpgsqlConnection conex=ConexionBD.establecerConexion();
            DataSet datos = new DataSet();

            try
            {
                String sql = "select id, producto, categoria, seccion, monto from productos ;";
                NpgsqlDataAdapter add = new NpgsqlDataAdapter(sql, conex);
                add.Fill(datos);
                conex.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("No se pudo conectar a la base de datos \n Error: " + e.ToString());
            }
            return datos;
        }

        public static void Agregar(String producto, String Categoria, String Seccion, Double Monto)
        {
            NpgsqlConnection conex = ConexionBD.establecerConexion();

            String sentencia = "INSERT INTO productos(producto, categoria, seccion, monto) VALUES ('"+producto+"','"+Categoria+"','"+Seccion+"','"+Monto+"'); ";

            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(sentencia, conex);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Registro agregado correctamente");
                conex.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show("No se pudo ejecutar el query \n Error: " + e.ToString());
            }

        }

        public static void Modificar(int id, String producto, String Categoria, String Seccion, Double Monto)
        {
            NpgsqlConnection conex = ConexionBD.establecerConexion();

            String sentencia = "UPDATE productos SET producto = '"+producto+"',categoria = '"+Categoria+"',seccion = '"+Seccion+"', monto = '"+Monto+"' WHERE id ="+id+";";

            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(sentencia, conex);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Registro actualizado correctamente");
                conex.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("No se pudo ejecutar el query \n Error: " + e.ToString());
            }

        }

        public static void Eliminar(int id)
        {
            NpgsqlConnection conex = ConexionBD.establecerConexion();

            String sentencia = "Delete from productos where id="+id+";";

            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(sentencia, conex);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Registro eliminado correctamente");
                conex.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("No se pudo ejecutar el query \n Error: " + e.ToString());
            }
        }
    }
}
