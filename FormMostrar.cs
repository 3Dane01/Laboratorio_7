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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Laboratorio_7
{
    public partial class FormMostrar : Form
    {
        List<clasePropietario> listaPropietario = new List<clasePropietario>();
        List<clasePropiedad> listaPropiedades = new List<clasePropiedad>();
        List<Reporte> resultados = new List<Reporte>();

        public FormMostrar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombreArchivo = "Propietarios.txt";
            FileStream stream = new FileStream(nombreArchivo, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                //leer datos
                clasePropietario lista = new clasePropietario();
                lista.Dpi = reader.ReadLine();
                lista.Nombre = reader.ReadLine();
                lista.Apellido = reader.ReadLine();
                listaPropietario.Add(lista);
            }
            //para que cierre despues de abrir el archivo y no se quede abierto
            reader.Close();

            string Archivo = "Propiedades.txt";
            FileStream escritura = new FileStream(Archivo, FileMode.Open, FileAccess.Read);
            StreamReader leer = new StreamReader(escritura);
            while (leer.Peek() > -1)
            {
                //leer datos
                clasePropiedad lista = new clasePropiedad();
                lista.NumeroCasa = leer.ReadLine();
                lista.DpiDueño = leer.ReadLine();
                lista.CuotaMantenimiento = leer.ReadLine();
                listaPropiedades.Add(lista);
            }
            //para que cierre despues de abrir el archivo y no se quede abierto
            leer.Close();

            resultados = (from propietario in listaPropietario
                                                  join propiedad in listaPropiedades on propietario.Dpi equals propiedad.DpiDueño
                                                  select new Reporte
                                                  {                                                      
                                                      NumeroCasaPropietario = propiedad.NumeroCasa,
                                                      NombrePropietario = propietario.Nombre,
                                                      ApellidoPropietario= propietario.Apellido,
                                                      CuotaPropietario = propiedad.CuotaMantenimiento
                                                  }).ToList();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = resultados.ToList();
            dataGridView1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 formprincipal = new Form1();
            formprincipal.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Orden ascendente
            resultados = resultados.OrderBy(r => r.CuotaPropietario).ToList();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = resultados;
            dataGridView1.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Que permita mostrar cuales son las 3 cuotas de mantenimiento más altas
            //PRIMERO SE ORDENA Y LUEGO SE TOMA LAS PRIMERAS TRES
            resultados = resultados.OrderByDescending(r => r.CuotaPropietario).ToList();
            // Tomar los primeros 3 elementos (las cuotas más altas)
            resultados = resultados.Take(3).ToList();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = resultados;
            dataGridView1.Refresh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Que permita mostrar cuales son las 3 cuotas de mantenimiento más bajas
            resultados = resultados.OrderBy(r => r.CuotaPropietario).ToList();
            resultados = resultados.Take(3).ToList();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = resultados;
            dataGridView1.Refresh();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Que permita mostrar quien es y cuanto deber pagar el propietario que tiene la cuotas total más alta.

        }
    }
}


