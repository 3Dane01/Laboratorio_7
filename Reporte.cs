using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_7
{
    internal class Reporte
    {
        string nombrePropietario;
        string apellidoPropietario;
        string numeroCasaPropietario;
        string cuotaPropietario;

        public string NombrePropietario { get => nombrePropietario; set => nombrePropietario = value; }
        public string ApellidoPropietario { get => apellidoPropietario; set => apellidoPropietario = value; }
        public string NumeroCasaPropietario { get => numeroCasaPropietario; set => numeroCasaPropietario = value; }
        public string  CuotaPropietario { get => cuotaPropietario; set => cuotaPropietario = value; }
    }
}
