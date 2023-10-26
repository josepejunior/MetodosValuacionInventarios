using Microsoft.VisualBasic;
using Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValuacionInventarios
{
    public partial class frmControlDeInventarios : Form
    {
        Material MaterialEntrante = new Material();

        Stack<Material> MaterialesUEPS = new Stack<Material>();
        Queue<Material> MaterialesPEPS = new Queue<Material>();

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
            txtCantidad.Enabled = false;
            txtValorUnitario.Enabled = false;
            btnRegistrar.Enabled = false;
        }

        private void cmbConcepto_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Si hay cambios en el cmbConcepto y es compra desactiva el cmbTipoMetodo y activa los demás txt´s
            if (cmbConcepto.SelectedIndex != -1 && cmbConcepto.Text == "Compra")
            {
                cmbTipoMetodo.Enabled = false;
                txtCantidad.Enabled = true;
                txtValorUnitario.Enabled = true;
                btnRegistrar.Enabled = true;
            }

            // Si hay cambios en el cmbConcepto y es venta desactiva el cmbTipoMetodo y
            // txtValorUnitario y activa los demás txt´s
            if (cmbConcepto.SelectedIndex != -1 && cmbConcepto.Text == "Venta")
            {
                cmbTipoMetodo.Enabled = false;
                txtCantidad.Enabled = true;
                txtValorUnitario.Enabled = false;
                btnRegistrar.Enabled = true;
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Agregar();
        }

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

            }
        }

        private void CapturarDatos()
        {
            if (cmbConcepto.Text == "Compra")
            {
                MaterialEntrante.Concepto = cmbConcepto.Text;
                MaterialEntrante.Cantidad = int.Parse(txtCantidad.Text);
                MaterialEntrante.PrecioUnitario = double.Parse(txtValorUnitario.Text);

                MaterialesPEPS.Enqueue(MaterialEntrante);
            }

            MaterialEntrante.Concepto = cmbConcepto.Text;
            MaterialEntrante.Cantidad = int.Parse(txtCantidad.Text);
        }

        private void LimpiarControles()
        {
            cmbConcepto.SelectedIndex = -1;
            txtCantidad.Clear();
            txtValorUnitario.Clear();
            cmbConcepto.Focus();
        }
    }
}
