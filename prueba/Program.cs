using System;
using System.Collections.Generic;

class Inventario
{ /*
    static void Main()
    {
        /*List<int> inventario = new List<int>();

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

        Console.WriteLine("Gracias por usar el sistema de control de inventario.");*/
    /*
        Queue<double> copiaCantidad = new Queue<double>(QcantidadSaldos);
        Queue<double> copiaValor = new Queue<double>(QValorSaldos);


        string converValor1 = copiaValor.Dequeue().ToString();
        double conver22 = double.Parse(converValor1);


        string valor1 = QcantidadSaldos.Dequeue().ToString();
        double valor11 = double.Parse(valor1);
        if (double.Parse(txtCantidad.Text) <= valor11)
        {
            double aux1 = valor11 - double.Parse(txtCantidad.Text);
            double aux2 = conver22 * aux1;

            ListViewItem Saldos = new ListViewItem(aux1.ToString());
            Saldos.SubItems.Add(conver22.ToString());
            Saldos.SubItems.Add(aux2.ToString());
            lvSaldos.Items.Add(Saldos);

            double aux3 = double.Parse(txtCantidad.Text) * conver22;

            ListViewItem salida = new ListViewItem(txtCantidad.Text);
            salida.SubItems.Add(conver22.ToString());
            salida.SubItems.Add(aux3.ToString());
            lvSalidas.Items.Add(salida);

            QcantidadSaldos.Clear();

            QcantidadSaldos.Enqueue(aux1);

            QValorSaldos.Clear();

            QValorSaldos.Enqueue(conver22);



            ListViewItem entrada = new ListViewItem("--------");
            entrada.SubItems.Add("--------");
            entrada.SubItems.Add("---------");
            lvEntradas.Items.Add(entrada);

            DateTime fecha = DateTime.Now;

            ListViewItem time = new ListViewItem(fecha.ToString());
            lvFecha.Items.Add(time);



        }
        else if (double.Parse(txtCantidad.Text) > valor11)
        {



            string converCantidad2 = QcantidadSaldos.Dequeue().ToString();
            double conver2 = double.Parse(converCantidad2);

            string converValor2 = copiaValor.Dequeue().ToString();
            double convervalor2 = double.Parse(converValor2);




            ListViewItem salida = new ListViewItem(valor11.ToString());
            salida.SubItems.Add(conver22.ToString());
            salida.SubItems.Add((valor11 * conver22).ToString());
            lvSalidas.Items.Add(salida);

            double aux1 = double.Parse(txtCantidad.Text) - valor11;

            ListViewItem salida2 = new ListViewItem(aux1.ToString());
            salida2.SubItems.Add(convervalor2.ToString());
            salida2.SubItems.Add((aux1 * convervalor2).ToString());
            lvSalidas.Items.Add(salida2);

            ListViewItem saldo = new ListViewItem("-----------");
            saldo.SubItems.Add("---------");
            saldo.SubItems.Add("---------");
            lvSaldos.Items.Add(saldo);

            ListViewItem entrada = new ListViewItem("-----------");
            entrada.SubItems.Add("---------");
            entrada.SubItems.Add("---------");
            lvEntradas.Items.Add(entrada);

            ListViewItem entrada2 = new ListViewItem("-----------");
            entrada2.SubItems.Add("---------");
            entrada2.SubItems.Add("---------");
            lvEntradas.Items.Add(entrada2);

            double aux2 = conver2 - aux1;

            ListViewItem saldo2 = new ListViewItem(aux2.ToString());
            saldo2.SubItems.Add(convervalor2.ToString());
            saldo2.SubItems.Add((aux2 * convervalor2).ToString());
            lvSaldos.Items.Add(saldo2);

            QcantidadSaldos.Clear();

            QcantidadSaldos.Enqueue(aux2);

            QValorSaldos.Clear();

            QValorSaldos.Enqueue(convervalor2);

        }
        */

     else if (cmbConcepto.SelectedItem == "Venta")
                {
                    // Copia de los Queue
                    Queue<double> copiaCantidad = new Queue<double>(QcantidadSaldos);
    Queue<double> copiaValor = new Queue<double>(QValorSaldos);
    string converValor1 = copiaValor.Dequeue().ToString();
    double conver22 = double.Parse(converValor1);

    string valor1 = QcantidadSaldos.Dequeue().ToString();
    double valor11 = double.Parse(valor1);
                    if (double.Parse(txtCantidad.Text) <= valor11)
                    {
                        double aux1 = valor11 - double.Parse(txtCantidad.Text);
    double aux2 = conver22 * aux1;

    double aux3 = double.Parse(txtCantidad.Text) * conver22;

    // Imprime fecha
    ListViewItem fecha = new ListViewItem(DateTime.Now.ToShortDateString());
    lvFecha.Items.Add(fecha);

                        // Imprime entradas
                        ListViewItem entrada = new ListViewItem("----------------");
    entrada.SubItems.Add("----------------");
                        entrada.SubItems.Add("----------------");
                        lvEntradas.Items.Add(entrada);

                        // Imprime salidas
                        ListViewItem salida = new ListViewItem(txtCantidad.Text);
    salida.SubItems.Add(conver22.ToString("C"));
                        salida.SubItems.Add(aux3.ToString("C"));
                        lvSalidas.Items.Add(salida);

                        // Imprime saldos
                        ListViewItem Saldos = new ListViewItem(aux1.ToString());
    Saldos.SubItems.Add(conver22.ToString("C"));
                        Saldos.SubItems.Add(aux2.ToString("C"));
                        lvSaldos.Items.Add(Saldos);

                        QcantidadSaldos.Clear();
                        QcantidadSaldos.Enqueue(aux1);

                        QValorSaldos.Clear();
                        QValorSaldos.Enqueue(conver22);

                        LimpiarControles();
}
                    else if (double.Parse(txtCantidad.Text) > valor11)
{
    string converCantidad2 = QcantidadSaldos.Dequeue().ToString();
    double conver2 = double.Parse(converCantidad2);

    string converValor2 = copiaValor.Dequeue().ToString();
    double convervalor2 = double.Parse(converValor2);

    // Imprime fecha
    ListViewItem fecha = new ListViewItem(DateTime.Now.ToShortDateString());
    lvFecha.Items.Add(fecha);

    // Imprime entradas
    ListViewItem entrada = new ListViewItem("----------------");
    entrada.SubItems.Add("----------------");
    entrada.SubItems.Add("----------------");
    lvEntradas.Items.Add(entrada);

    // Imprime salidas
    ListViewItem salida = new ListViewItem(valor11.ToString());
    salida.SubItems.Add(conver22.ToString("C"));
    salida.SubItems.Add((valor11 * conver22).ToString("C"));
    lvSalidas.Items.Add(salida);

    // Imprime saldos
    ListViewItem saldo = new ListViewItem("----------------");
    saldo.SubItems.Add("----------------");
    saldo.SubItems.Add("----------------");
    lvSaldos.Items.Add(saldo);

    // Imprime fecha vacia
    ListViewItem time2 = new ListViewItem("----------------");
    lvFecha.Items.Add(time2);

    // Imprime entradas
    ListViewItem entrada2 = new ListViewItem("----------------");
    entrada2.SubItems.Add("----------------");
    entrada2.SubItems.Add("----------------");
    lvEntradas.Items.Add(entrada2);

    double aux1 = double.Parse(txtCantidad.Text) - valor11;

    // Imprime salidas
    ListViewItem salida2 = new ListViewItem(aux1.ToString());
    salida2.SubItems.Add(convervalor2.ToString("C"));
    salida2.SubItems.Add((aux1 * convervalor2).ToString("C"));
    lvSalidas.Items.Add(salida2);

    double aux2 = conver2 - aux1;

    // Imprime saldos
    ListViewItem saldo2 = new ListViewItem(aux2.ToString());
    saldo2.SubItems.Add(convervalor2.ToString("C"));
    saldo2.SubItems.Add((aux2 * convervalor2).ToString("C"));
    lvSaldos.Items.Add(saldo2);

    QcantidadSaldos.Clear();
    QcantidadSaldos.Enqueue(aux2);

    QValorSaldos.Clear();
    QValorSaldos.Enqueue(Tot);

    LimpiarControles();
}
                }
            }





 }