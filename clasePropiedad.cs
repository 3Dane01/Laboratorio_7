using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_7
{
    internal class clasePropiedad
    {
        string numeroCasa;
        string dpiDueño;
        string cuotaMantenimiento;

        public string NumeroCasa { get => numeroCasa; set => numeroCasa = value; }
        public string DpiDueño { get => dpiDueño; set => dpiDueño = value; }
        public string CuotaMantenimiento { get => cuotaMantenimiento; set => cuotaMantenimiento = value; }
    }
}
