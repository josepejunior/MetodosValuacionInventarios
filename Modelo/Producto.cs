using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Producto
    {
        public DateTime FechaMovimiento { get; set; }
        public string Concepto { get; set; }
        public int Cantidad { get; set; }
        public double PrecioUnitario { get; set; }
        public double PrecioTotal { get; set; }

        Stack<Producto>? productos;

        public void MetodoPEPS(string concepto, int cantidadAVender)
        {
            while (Concepto == "Compra")
            {
                productos = new Stack<Producto>();
            }

            if (Concepto == "Venta")
            {
                Producto temp = productos.Peek();

                if (temp.Cantidad > cantidadAVender) 
                {

                }
            }
        }
    }
}
