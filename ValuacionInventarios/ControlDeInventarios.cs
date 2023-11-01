using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using objExcel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.VisualBasic;

namespace ValuacionInventarios
{
    public partial class frmControlDeInventarios : Form
    {
        Stack cantidadSaldos = new Stack();
        Stack ValorSaldos = new Stack();
        List<double> LsCantidad = new List<double>();
        List<double> LsValorUnidad = new List<double>();
        List<double> lsTotal = new List<double>();
        Queue<double> QcantidadSaldos = new Queue<double>();
        Queue<double> QValorSaldos = new Queue<double>();


        public frmControlDeInventarios()
        {
            InitializeComponent();
        }

        private void ControlDeInventarios_Load(object sender, EventArgs e)
        {
            // Fecha y hora en sus etiquetas
            lblFecha.Text = DateTime.Now.ToShortDateString();
            lblHora.Text = DateTime.Now.ToShortTimeString();

            // ComboBox para el tipo de método
            cmbTipoMetodo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoMetodo.Items.Add("Promedio");
            cmbTipoMetodo.Items.Add("PEPS");
            cmbTipoMetodo.Items.Add("UEPS");

            // ComboBox para el concepto
            cmbConcepto.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbConcepto.Items.Add("Compra");
            cmbConcepto.Items.Add("Venta");

            // Desactivando cuadros de texto
            /* cmbConcepto.Enabled = false;
             txtCantidad.Enabled = false;
             txtValorUnitario.Enabled = false;
             btnRegistrar.Enabled = false;*/
        }

        private void cmbTipoMetodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Si hay cambios en el cmbConcepto y es compra desactiva el cmbTipoMetodo y activa los demás txt´s
            /* if (cmbTipoMetodo.SelectedIndex != -1)
             {
                 cmbTipoMetodo.Enabled = false;
                 cmbConcepto.Enabled = true;

                 if (cmbConcepto.Text == "Compra") 
                 {
                     txtCantidad.Enabled = true;
                     txtValorUnitario.Enabled = true;
                     btnRegistrar.Enabled = true;
                 }
                 else if (cmbConcepto.Text == "Venta")
                 {
                     txtCantidad.Enabled = true;
                     txtValorUnitario.Enabled = false;
                     btnRegistrar.Enabled = true;
                 }
             }*/
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (cmbTipoMetodo.Text == "UEPS")
            {
                if (cmbConcepto.Text == "Compra")
                {
                    // Calcula el precio total
                    double total = double.Parse(txtValorUnitario.Text) * double.Parse(txtCantidad.Text);

                    // Llena el Stack
                    ValorSaldos.Push(double.Parse(txtValorUnitario.Text));
                    cantidadSaldos.Push(double.Parse(txtCantidad.Text));

                    // Imprime fecha
                    ListViewItem fecha = new ListViewItem(DateTime.Now.ToShortDateString());
                    lvFecha.Items.Add(fecha);

                    // Imprime entradas
                    ListViewItem entrada = new ListViewItem(txtCantidad.Text);
                    entrada.SubItems.Add(double.Parse(txtValorUnitario.Text).ToString("C"));
                    entrada.SubItems.Add(total.ToString("C"));
                    lvEntradas.Items.Add(entrada);

                    // Imprime salidas
                    ListViewItem salida = new ListViewItem("----------------");
                    salida.SubItems.Add("----------------");
                    salida.SubItems.Add("----------------");
                    lvSalidas.Items.Add(salida);

                    // Imprime saldos
                    ListViewItem saldos = new ListViewItem(txtCantidad.Text);
                    saldos.SubItems.Add(double.Parse(txtValorUnitario.Text).ToString("C"));
                    saldos.SubItems.Add(total.ToString("C"));
                    lvSaldos.Items.Add(saldos);

                    LimpiarControles();
                }
                else if (cmbConcepto.Text == "Venta")
                {
                    // Copia temporal de los Stack´s
                    Stack CopiaCantidad = new Stack();
                    Stack CopiaValor = new Stack();
                    CopiaCantidad = (Stack)cantidadSaldos.Clone();
                    CopiaValor = (Stack)ValorSaldos.Clone();

                    string converValor1 = ValorSaldos.Pop().ToString();
                    double conver22 = double.Parse(converValor1);

                    string PrimerValorString = cantidadSaldos.Pop().ToString();
                    double PrimerValor = double.Parse(PrimerValorString);

                    if (double.Parse(txtCantidad.Text) < PrimerValor)
                    {
                        double Cantidad = PrimerValor - double.Parse(txtCantidad.Text);
                        double total = conver22 * Cantidad;

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
                        salida.SubItems.Add((double.Parse(txtCantidad.Text) * conver22).ToString("C"));
                        lvSalidas.Items.Add(salida);

                        // Imprime saldos
                        ListViewItem Saldos = new ListViewItem(Cantidad.ToString());
                        Saldos.SubItems.Add(conver22.ToString("C"));
                        Saldos.SubItems.Add(total.ToString("C"));
                        lvSaldos.Items.Add(Saldos);

                        LimpiarControles();
                    }
                    else if (double.Parse(txtCantidad.Text) > PrimerValor)
                    {
                        string Cantidad2 = cantidadSaldos.Pop().ToString();
                        double cantidad2 = double.Parse(Cantidad2);

                        string Valor2 = ValorSaldos.Pop().ToString();
                        double valor2 = double.Parse(Valor2);

                        double CantidadSalida2 = double.Parse(txtCantidad.Text) - PrimerValor;
                        double totalSalida2 = CantidadSalida2 * valor2;

                        double CantidadSaldos2 = (cantidad2 + PrimerValor) - double.Parse(txtCantidad.Text);
                        double totalSaldos2 = CantidadSaldos2 * valor2;

                        // Imprime fecha
                        ListViewItem fecha = new ListViewItem(DateTime.Now.ToShortDateString());
                        lvFecha.Items.Add(fecha);

                        // Imprime entradas
                        ListViewItem entrada = new ListViewItem("----------------");
                        entrada.SubItems.Add("----------------");
                        entrada.SubItems.Add("----------------");
                        lvEntradas.Items.Add(entrada);

                        // Imprime salidas
                        ListViewItem salida = new ListViewItem(PrimerValor.ToString());
                        salida.SubItems.Add(conver22.ToString("C"));
                        salida.SubItems.Add((PrimerValor * conver22).ToString("C"));
                        lvSalidas.Items.Add(salida);

                        // Imprime saldos
                        ListViewItem saldos = new ListViewItem("----------------");
                        saldos.SubItems.Add("----------------");
                        saldos.SubItems.Add("----------------");
                        lvSaldos.Items.Add(saldos);

                        // Imprime fecha vacia
                        ListViewItem time2 = new ListViewItem("----------------");
                        lvFecha.Items.Add(time2);

                        // Imprime entradas
                        ListViewItem entrada2 = new ListViewItem("----------------");
                        entrada2.SubItems.Add("----------------");
                        entrada2.SubItems.Add("----------------");
                        lvEntradas.Items.Add(entrada2);

                        // Imprime salidas
                        ListViewItem salida2 = new ListViewItem(CantidadSalida2.ToString());
                        salida2.SubItems.Add(valor2.ToString("C"));
                        salida2.SubItems.Add(totalSalida2.ToString("C"));
                        lvSalidas.Items.Add(salida2);

                        // Imprime saldos
                        ListViewItem saldo1 = new ListViewItem(CantidadSaldos2.ToString());
                        saldo1.SubItems.Add(valor2.ToString("C"));
                        saldo1.SubItems.Add(totalSaldos2.ToString("C"));
                        lvSaldos.Items.Add(saldo1);

                        cantidadSaldos.Clear();
                        cantidadSaldos.Push(CantidadSaldos2);

                        ValorSaldos.Clear();
                        ValorSaldos.Push(valor2);

                        LimpiarControles();
                    }
                }
            }
            else if (cmbTipoMetodo.Text == "PEPS")
            {
                if (cmbConcepto.Text == "Compra")
                {
                    double total = double.Parse(txtValorUnitario.Text) * double.Parse(txtCantidad.Text);

                    // Llenando los Queue
                    QValorSaldos.Enqueue(double.Parse(txtValorUnitario.Text));
                    QcantidadSaldos.Enqueue(double.Parse(txtCantidad.Text));

                    // Imprime fecha
                    ListViewItem fecha = new ListViewItem(DateTime.Now.ToShortDateString());
                    lvFecha.Items.Add(fecha);

                    // Imprime entradas
                    ListViewItem entrada = new ListViewItem(txtCantidad.Text);
                    entrada.SubItems.Add(double.Parse(txtValorUnitario.Text).ToString("C"));
                    entrada.SubItems.Add(total.ToString("C"));
                    lvEntradas.Items.Add(entrada);

                    // Imprime salidas
                    ListViewItem salida = new ListViewItem("----------------");
                    salida.SubItems.Add("----------------");
                    salida.SubItems.Add("----------------");
                    lvSalidas.Items.Add(salida);

                    // Imprime saldos
                    ListViewItem saldos = new ListViewItem(txtCantidad.Text);
                    saldos.SubItems.Add(double.Parse(txtValorUnitario.Text).ToString("C"));
                    saldos.SubItems.Add(total.ToString("C"));
                    lvSaldos.Items.Add(saldos);

                    LimpiarControles();
                }
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
                        QValorSaldos.Enqueue(convervalor2);

                        LimpiarControles();
                    }
                }
            }
            else if (cmbTipoMetodo.SelectedItem == "Promedio")
            {
                if (cmbConcepto.SelectedItem == "Compra")
                {
                    LsCantidad.Add(double.Parse(txtCantidad.Text));
                    LsValorUnidad.Add(double.Parse(txtValorUnitario.Text));

                    double result;
                    result = double.Parse(txtCantidad.Text) * double.Parse(txtValorUnitario.Text);
                    lsTotal.Add(result);

                    // Imprime fecha
                    ListViewItem fecha = new ListViewItem(DateTime.Now.ToShortDateString());
                    lvFecha.Items.Add(fecha);

                    // Imprime entradas
                    ListViewItem Cantidad = new ListViewItem(txtCantidad.Text);
                    Cantidad.SubItems.Add(double.Parse(txtValorUnitario.Text).ToString("C"));
                    Cantidad.SubItems.Add(result.ToString("C"));
                    lvEntradas.Items.Add(Cantidad);

                    // Imprime salidas
                    ListViewItem salida = new ListViewItem("----------------");
                    salida.SubItems.Add("----------------");
                    salida.SubItems.Add("----------------");
                    lvSalidas.Items.Add(salida);

                    LimpiarControles();

                    double result1 = 0;
                    double result2 = 0;
                    result1 = LsCantidad.Sum();
                    result2 = lsTotal.Sum();

                    double Result3 = 0;
                    Result3 = result2 / result1;

                    if (cantidadSaldos.Count == 1)
                    {
                        // Imprime saldos
                        ListViewItem Saldo = new ListViewItem(txtCantidad.Text);
                        Saldo.SubItems.Add(double.Parse(txtValorUnitario.Text).ToString("C"));
                        Saldo.SubItems.Add(result.ToString("C"));
                        lvSaldos.Items.Add(Saldo);

                        LimpiarControles();
                    }
                    else
                    {
                        // Imprime saldos
                        ListViewItem saldo2 = new ListViewItem(result1.ToString());
                        saldo2.SubItems.Add(Result3.ToString("C"));
                        saldo2.SubItems.Add(result2.ToString("C"));
                        lvSaldos.Items.Add(saldo2);

                        LimpiarControles();
                    }
                }
                else if (cmbConcepto.SelectedItem == "Venta")
                {
                    double SumaCant = 0;
                    double SumaTotal = 0;
                    SumaCant = LsCantidad.Sum();
                    SumaTotal = lsTotal.Sum();
                    double ValorUnit = 0;
                    ValorUnit = SumaTotal / SumaCant;
                    double Total = 0;
                    Total = ValorUnit * double.Parse(txtCantidad.Text);

                    // Imprime fecha
                    ListViewItem fecha = new ListViewItem(DateTime.Now.ToShortDateString());
                    lvFecha.Items.Add(fecha);

                    // Imprime entradas
                    ListViewItem Entrada = new ListViewItem("----------------");
                    Entrada.SubItems.Add("----------------");
                    Entrada.SubItems.Add("----------------");
                    lvEntradas.Items.Add(Entrada);

                    // Imprime salidas
                    ListViewItem Salida = new ListViewItem(txtCantidad.Text);
                    Salida.SubItems.Add(ValorUnit.ToString("C"));
                    Salida.SubItems.Add(Total.ToString("C"));
                    lvSalidas.Items.Add(Salida);

                    double CantidadSaldo = SumaCant - double.Parse(txtCantidad.Text);
                    double TSaldo = CantidadSaldo * ValorUnit;

                    // Imprime saldos
                    ListViewItem Saldo3 = new ListViewItem(CantidadSaldo.ToString());
                    Saldo3.SubItems.Add(ValorUnit.ToString("C"));
                    Saldo3.SubItems.Add(TSaldo.ToString("C"));
                    lvSaldos.Items.Add(Saldo3);

                    LimpiarControles();

                    LsCantidad.Clear();
                    LsCantidad.Add(CantidadSaldo);

                    lsTotal.Clear();
                    lsTotal.Add(TSaldo);
                }
            }
        }
        private void LimpiarControles()
        {
            cmbConcepto.SelectedIndex = -1;
            txtCantidad.Clear();
            txtValorUnitario.Clear();
            cmbConcepto.Focus();
        }

        private void frmControlDeInventarios_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show("¿Quieres salir del programa?", "Confirmar salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (r == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivo de Excel (*.xlsx)|*.xlsx";
            saveFileDialog.Title = "Guardar archivo de Excel";
            saveFileDialog.FileName = "ExcelPrueba.xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                Microsoft.Office.Interop.Excel.Application objAplicacion = new Microsoft.Office.Interop.Excel.Application();
                Workbook objLibro = objAplicacion.Workbooks.Add(XlSheetType.xlWorksheet);

                string seleccion = cmbTipoMetodo.Text;
                Worksheet objHoja = (Worksheet)objAplicacion.ActiveSheet;
                objHoja.Name = seleccion;

                objAplicacion.Visible = false;

                AgregarEncabezados(objHoja, seleccion);
                ExportarListViewAExcel(lvFecha, lvEntradas, lvSalidas, lvSaldos, objHoja, 4, 1);
                objLibro.SaveAs2(filePath);
                objAplicacion.Quit();

                MessageBox.Show("Datos exportados exitosamente a Excel en: " + filePath, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void ExportarListViewAExcel(System.Windows.Forms.ListView fechaListView, System.Windows.Forms.ListView entradasListView, System.Windows.Forms.ListView salidasListView, System.Windows.Forms.ListView saldosListView, Worksheet objHoja, int inicioRow, int inicioColumn)
        {
            objHoja.Cells[inicioRow, inicioColumn].Value = "Fechas";
            objHoja.Cells[inicioRow, inicioColumn + 3].Value = "Entradas";
            objHoja.Cells[inicioRow, inicioColumn + 6].Value = "Salidas";
            objHoja.Cells[inicioRow, inicioColumn + 9].Value = "Saldos";
            int rowActual = inicioRow + 1;

            for (int i = 0; i < fechaListView.Items.Count; i++)
            {
                objHoja.Cells[rowActual, inicioColumn].Value = fechaListView.Items[i].Text;

                for (int col = 0; col < 3; col++)
                {
                    objHoja.Cells[rowActual, inicioColumn + 2 + col].Value = entradasListView.Items[i].SubItems[col].Text;
                    objHoja.Cells[rowActual, inicioColumn + 5 + col].Value = salidasListView.Items[i].SubItems[col].Text;
                    objHoja.Cells[rowActual, inicioColumn + 8 + col].Value = saldosListView.Items[i].SubItems[col].Text;
                }

                rowActual++;
            }
        }
        private void AgregarEncabezados(Worksheet objHoja, string metodo)
        {
            objHoja.Cells[1, 1].Value = "Método: " + metodo;
        }



        /*
        private void Agregar()
        {
            
            CapturarDatos();

            double ValorTotal = MaterialEntrante.CalculaPrecioTotal();
            ImprimirDatos(ValorTotal);

        }

         private void ImprimirDatos(double valorTotal)
         {
             if (cmbConcepto.Text == "Compra")
             {
                 // Imprime fecha el lvFecha
                 ListViewItem filaFecha = new ListViewItem(DateTime.Now.ToShortDateString());
                 lvFecha.Items.Add(filaFecha);

                 // Imprime en Entradas
                 ListViewItem filaEntrada = new ListViewItem(MaterialEntrante.Cantidad.ToString());
                 filaEntrada.SubItems.Add(MaterialEntrante.PrecioUnitario.ToString("C"));
                 filaEntrada.SubItems.Add(valorTotal.ToString("C"));
                 lvEntradas.Items.Add(filaEntrada);

                 // Imprime espacios vacíos en Salidas
                 ListViewItem filaSalida = new ListViewItem("----------------");
                 filaSalida.SubItems.Add("----------------");
                 filaSalida.SubItems.Add("----------------");
                 lvSalidas.Items.Add(filaSalida);

                 // Imprime en Saldos
                 ListViewItem filaSaldos = new ListViewItem(MaterialEntrante.Cantidad.ToString());
                 filaSaldos.SubItems.Add(MaterialEntrante.PrecioUnitario.ToString("C"));
                 filaSaldos.SubItems.Add(valorTotal.ToString("C"));
                 lvSaldos.Items.Add(filaSaldos);

                 LimpiarControles();
             }
             else if (cmbTipoMetodo.Text == "UEPS" && cmbConcepto.Text == "Venta")
             {
                 Material copiaMaterial = MaterialesUEPS.Pop();
                 if (copiaMaterial.Cantidad == MaterialEntrante.Cantidad)
                 {
                     ListViewItem filaFecha = new ListViewItem(DateTime.Now.ToShortDateString());
                     lvFecha.Items.Add(filaFecha);

                     ListViewItem filaEntrada = new ListViewItem("----------------");
                     filaEntrada.SubItems.Add("----------------");
                     filaEntrada.SubItems.Add("----------------");
                     lvEntradas.Items.Add(filaEntrada);

                     ListViewItem filaSalida = new ListViewItem(MaterialEntrante.Cantidad.ToString());
                     filaSalida.SubItems.Add(copiaMaterial.PrecioUnitario.ToString("C"));
                     filaSalida.SubItems.Add(copiaMaterial.CalculaPrecioTotal().ToString("C"));
                     lvSalidas.Items.Add(filaSalida);

                     ListViewItem filaSaldos = new ListViewItem("----------------");
                     filaSaldos.SubItems.Add("----------------");
                     filaSaldos.SubItems.Add("----------------");
                     lvSaldos.Items.Add(filaSaldos);
                 }
                 else if (MaterialEntrante.Cantidad > copiaMaterial.Cantidad)
                 {
                     Material copiaMaterial2 = MaterialesUEPS.Pop();

                 }

             }
         }

         private void CapturarDatos()
         {
             if (cmbConcepto.Text == "Compra")
             {

                 if (cmbTipoMetodo.Text == "UEPS")
                 {
                     MaterialEntrante.Concepto = cmbConcepto.Text;
                     MaterialEntrante.Cantidad = int.Parse(txtCantidad.Text);
                     MaterialEntrante.PrecioUnitario = double.Parse(txtValorUnitario.Text);
                     MaterialesUEPS.Push(MaterialEntrante);
                 }
                 else
                     MaterialEntrante.Concepto = cmbConcepto.Text;
                 MaterialEntrante.Cantidad = int.Parse(txtCantidad.Text);
                 MaterialEntrante.PrecioUnitario = double.Parse(txtValorUnitario.Text);
                 MaterialesPEPS.Enqueue(MaterialEntrante);
             }
             else
             {
                 MaterialEntrante.Concepto = cmbConcepto.Text;
                 MaterialEntrante.Cantidad = int.Parse(txtCantidad.Text);
             }
         }*/
    }
}
