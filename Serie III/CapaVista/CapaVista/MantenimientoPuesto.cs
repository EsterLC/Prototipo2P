using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaControlador;

namespace CapaVista
{
    public partial class MantenimientoPuesto : Form
    {
        public MantenimientoPuesto()
        {
            InitializeComponent();
        }

        Controlador cn = new Controlador();
        string tabla = "puesto";

        public void actualizardatagriew()
        {
            DataTable dt = cn.llenarTbl(tabla);
            dgv_tabla.DataSource = dt;

        }
        private void MantenimientoPuesto_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            actualizardatagriew();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TextBox[] textbox = { txtCodigo, txtPuesto, txtEstatus };
            cn.ingresar(textbox, dgv_tabla);
            actualizardatagriew();
            txtCodigo.Text = "";
            txtPuesto.Text = "";
            txtEstatus.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TextBox[] textbox = { txtCodigo, txtEstatus, txtPuesto};
            cn.delete(textbox, dgv_tabla);
            MessageBox.Show("¿Esta seguro de eliminar el registro?");
            actualizardatagriew();
            txtCodigo.Text = "";
            txtPuesto.Text = "";
            txtEstatus.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TextBox[] textbox = { txtCodigo, txtEstatus, txtPuesto };
            cn.actualizar(textbox, dgv_tabla);
            actualizardatagriew();
            txtCodigo.Text = "";
            txtPuesto.Text = "";
            txtEstatus.Text = "";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
