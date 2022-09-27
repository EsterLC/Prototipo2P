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
    public partial class MantenimientoDepartamentos : Form
    {
        public MantenimientoDepartamentos()
        {
            InitializeComponent();
        }

        Controlador cn = new Controlador();

        string tabla = "departamento";

        public void actualizardatagriew()
        {
            DataTable dt = cn.llenarTbl(tabla);
            dgv_tablaDepartamento.DataSource = dt;

        }
        private void button4_Click(object sender, EventArgs e)
        {
            actualizardatagriew();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TextBox[] textbox = { txtCodigo, txtDepartamento, txtEstatus };
            cn.ingresar(textbox, dgv_tablaDepartamento);
            actualizardatagriew();
            txtCodigo.Text = "";
            txtDepartamento.Text = "";
            txtEstatus.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TextBox[] textbox = { txtCodigo, txtDepartamento, txtEstatus };
            cn.delete(textbox, dgv_tablaDepartamento);
            MessageBox.Show("¿Esta seguro de eliminar el registro?");
            actualizardatagriew();
            txtCodigo.Text = "";
            txtDepartamento.Text = "";
            txtEstatus.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TextBox[] textbox = { txtCodigo, txtDepartamento, txtEstatus };
            cn.actualizar(textbox, dgv_tablaDepartamento);
            actualizardatagriew();
            txtCodigo.Text = "";
            txtDepartamento.Text = "";
            txtEstatus.Text = "";
        }
    }
}
