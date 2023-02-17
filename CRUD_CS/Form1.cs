using System;
using System.Windows.Forms;

namespace CRUD_CS
{
    public partial class Form1 : Form
    {
        private Consultas consulta = new Consultas();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void MostrarDatos()
        {
            try
            {
                tabla.DataSource = Consultas.mostrarTabla().Tables[0];
            }
            catch (Exception e)
            {

                MessageBox.Show("No se pudo conectar a la base de datos \n Error: " + e.ToString());

            }
        }

        private void Limpiar()
        {
            txt_productos.Text = "";
            txt_categoria.Text = "";
            txt_seccion.Text = "";
            txt_monto.Text = "";
            txt_id.Text = "";
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            MostrarDatos();
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {

            string producto = txt_productos.Text;
            string categoria = txt_categoria.Text;
            string seccion = txt_seccion.Text;
            double monto = Convert.ToDouble(txt_monto.Text);
            if (producto == "") producto = "ProductoSinNombre";
            Consultas.Agregar(producto, categoria, seccion, monto);
            Limpiar();
            MostrarDatos();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txt_id.Text);
            Consultas.Eliminar(id);
            Limpiar();
            MostrarDatos();
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txt_id.Text);
            string producto = txt_productos.Text;
            string categoria = txt_categoria.Text;
            string seccion = txt_seccion.Text;
            double monto = Convert.ToDouble(txt_monto.Text);
            if (producto == "") producto = "ProductoSinNombre";
            Consultas.Modificar(id, producto, categoria, seccion, monto);
            Limpiar();
            MostrarDatos();
        }

        private void tabla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = tabla.CurrentRow;
            string id = Convert.ToString(fila.Cells[0].Value);
            string producto = Convert.ToString(fila.Cells[1].Value);
            string categoria = Convert.ToString(fila.Cells[2].Value);
            string seccion = Convert.ToString(fila.Cells[3].Value);
            string monto = Convert.ToString(fila.Cells[4].Value);

            txt_id.Text = id;
            txt_productos.Text = producto;
            txt_categoria.Text = categoria;
            txt_seccion.Text = seccion;
            txt_monto.Text = monto;

        }
    }
}
