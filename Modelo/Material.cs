using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Material
    {
        public string Concepto { get; set; }
        public int Cantidad { get; set; }
        public double PrecioUnitario { get; set; }

        public double CalculaPrecioTotal()
        {
            return  Cantidad * PrecioUnitario;
        }
    }
}
