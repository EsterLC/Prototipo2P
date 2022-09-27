using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Odbc;
using CapaModelo;
using System.Windows.Forms;

namespace CapaControlador
{
    public class Controlador
    {
        Sentencias sn = new Sentencias();

        public DataTable llenarTbl(string tabla)
        {
            OdbcDataAdapter dtable = sn.llenarTbl(tabla);
            DataTable table = new DataTable();
            dtable.Fill(table);
            return table;
        }

        public void limpiar(Control control)// limpia Componentes
        {
            foreach (var txt in control.Controls)
            {
                if (txt is TextBox)
                {
                    ((TextBox)txt).Clear();
                }
                else if (txt is ComboBox)
                {
                    ((ComboBox)txt).SelectedItem = 0;
                }
                else if (txt is CheckBox)
                {
                    ((CheckBox)txt).Checked = false;
                }
            }
        }

        public void ingresar(TextBox[] textbox, DataGridView tabla)//Crea cadenas de datos para la insercion
        {

                string dato = " ";
                string tipo = " ";
                for (int x = 0; x < textbox.Length; x++)
                {

                    if (x == textbox.Length - 1)
                    {
                        dato += "'" + textbox[x].Text + "'";
                        tipo += textbox[x].Tag.ToString();
                    }
                    else
                    {
                        dato += "'" + textbox[x].Text + "',";
                        tipo += textbox[x].Tag.ToString() + ",";
                    }

                }

                sn.insertar(dato, tipo, tabla.Tag.ToString());
                //MessageBox.Show("Dato Insertado");
               
        }

        public void actualizar(TextBox[] textbox, DataGridView tabla)//Crea cadenas de datos para la actualizacion
        {
            string dato = " ";
            string condicion = "(" + textbox[0].Tag.ToString() + " = '" + textbox[0].Text + "')";

            for (int x = 1; x < textbox.Length; x++)
            {

                if (x == textbox.Length - 1)
                {
                    dato += " " + textbox[x].Tag.ToString() + " = '" + textbox[x].Text + "' ";

                }
                else if (x == 1)
                {
                    dato += "SET " + textbox[x].Tag.ToString() + " = '" + textbox[x].Text + "', ";

                }
                else
                {
                    dato += " " + textbox[x].Tag.ToString() + " = '" + textbox[x].Text + "', ";

                }

            }
            sn.actualizar(dato, condicion, tabla.Tag.ToString());
            MessageBox.Show("Dato actualizado");
        }

        public void delete(TextBox[] textbox, DataGridView tabla)
        {
                string campo = textbox[0].Tag.ToString();
                int clave = int.Parse(textbox[0].Text);

                sn.eliminar(clave, campo, tabla.Tag.ToString());
                MessageBox.Show("Dato Eliminado");
              
        }
    }
}
    