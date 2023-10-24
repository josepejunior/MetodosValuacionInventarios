using System;
using System.Collections.Generic;

class Inventario
{
    static void Main()
    {
        List<int> inventario = new List<int>();

        Console.WriteLine("Sistema de Control de Inventario (PEPS y UEPS)");
        Console.WriteLine("Ingrese 1 para agregar un producto.");
        Console.WriteLine("Ingrese 2 para vender un producto.");
        Console.WriteLine("Ingrese 0 para salir.");

        while (true)
        {
            Console.Write("Opción: ");
            int opcion = Convert.ToInt32(Console.ReadLine());

            if (opcion == 0)
                break;

            if (opcion == 1)
            {
                Console.Write("Ingrese la cantidad de productos a agregar: ");
                int cantidad = Convert.ToInt32(Console.ReadLine());
                inventario.Add(cantidad);
            }
            else if (opcion == 2)
            {
                Console.Write("Ingrese la cantidad de productos a vender: ");
                int cantidad = Convert.ToInt32(Console.ReadLine());

                if (inventario.Count == 0)
                {
                    Console.WriteLine("El inventario está vacío. No hay productos para vender.");
                }
                else
                {
                    int cantidadVendida = 0;

                    if (opcion == 1)
                    {
                        // Método PEPS: se venden los productos más antiguos primero.
                        cantidadVendida = inventario[0];
                        inventario.RemoveAt(0);
                    }
                    else if (opcion == 2)
                    {
                        // Método UEPS: se venden los productos más recientes primero.
                        cantidadVendida = inventario[inventario.Count - 1];
                        inventario.RemoveAt(inventario.Count - 1);
                    }

                    if (cantidadVendida >= cantidad)
                    {
                        Console.WriteLine($"Se vendieron {cantidad} productos.");
                    }
                    else
                    {
                        Console.WriteLine($"No hay suficientes productos para vender. Se vendieron {cantidadVendida} productos.");
                    }
                }
            }
        }

        Console.WriteLine("Gracias por usar el sistema de control de inventario.");
    }
}