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
    public partial class FormPropiedades : Form
    {
        List<clasePropiedad> listaPropiedades = new List<clasePropiedad>();
        public FormPropiedades()
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
            clasePropiedad Propiedad = new clasePropiedad();
            Propiedad.NumeroCasa = textBoxNumeroCasa.Text;
            Propiedad.DpiDueño = textBoxDpi.Text;
            Propiedad.CuotaMantenimiento = textBoxCuota.Text;

            listaPropiedades.Add(Propiedad);

            string nombreArchivo = "Propiedades.txt";
            FileStream stream = new FileStream(nombreArchivo, FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);

            // Escribir el último propietario agregado en el archivo
            writer.WriteLine(Propiedad.NumeroCasa);
            writer.WriteLine(Propiedad.DpiDueño);
            writer.WriteLine(Propiedad.CuotaMantenimiento);

            // Cerrar el StreamWriter
            writer.Close();
            MessageBox.Show("Se guardaron los datos en el archivo", "Propiedades");
        }
    }
}
