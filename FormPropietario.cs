using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio_7
{
    public partial class FormPropietario : Form
    {
        List<clasePropietario> listaPropietario = new List<clasePropietario>();
        public FormPropietario()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 formprincipal = new Form1();
            formprincipal.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clasePropietario Propietario = new clasePropietario();
            Propietario.Dpi = textBoxDpi.Text;
            Propietario.Nombre = textBoxNombre.Text;
            Propietario.Apellido = textBoxApellido.Text;

            listaPropietario.Add(Propietario);

            string nombreArchivo = "Propietarios.txt";
            FileStream stream = new FileStream(nombreArchivo, FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);

            // Escribir el último propietario agregado en el archivo
            writer.WriteLine(Propietario.Dpi);
            writer.WriteLine(Propietario.Nombre);
            writer.WriteLine(Propietario.Apellido);

            // Cerrar el StreamWriter
            writer.Close();
            MessageBox.Show("Se guardaron los datos en el archivo", "Propietarios");
        }
    }
}
