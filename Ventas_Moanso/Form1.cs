using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Ventas_Moanso
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dgvVentas.ColumnCount = 5;
            dgvVentas.Columns[0].Name = "Código";
            dgvVentas.Columns[1].Name = "Nombre";
            dgvVentas.Columns[2].Name = "Precio Unitario";
            dgvVentas.Columns[3].Name = "Cantidad";
            dgvVentas.Columns[4].Name = "Total";
        }
   
 

        //FUNCIÓN REGISTRAR
        private void btnRegistrar_Click_1(object sender, EventArgs e)
        {
            try
            {
                string codigo = txtCodigo.Text.Trim();
                string nombre = txtNombre.Text.Trim();

                // Validar campos vacíos primero
                if (codigo == "" || nombre == "" || txtCantidad.Text == "" || txtPrecio.Text == "")
                {
                    MessageBox.Show("Completa todos los campos antes de registrar la venta.");
                    return;
                }

                // Validar cantidad
                int cantidad;
                if (!int.TryParse(txtCantidad.Text, out cantidad) || cantidad <= 0)
                {
                    MessageBox.Show("La cantidad debe ser un número entero positivo.");
                    txtCantidad.Focus();
                    return;
                }

                // Validar precio
                decimal precio;
                if (!decimal.TryParse(txtPrecio.Text, out precio) || precio <= 0)
                {
                    MessageBox.Show("El precio debe ser un número positivo.");
                    txtPrecio.Focus();
                    return;
                }

                decimal total = precio * cantidad;

                // Agregar fila a la tabla
                dgvVentas.Rows.Add(codigo, nombre, precio.ToString("0.00"), cantidad.ToString(), total.ToString("0.00"));

                // Limpiar campos
                txtCodigo.Clear();
                txtNombre.Clear();
                txtPrecio.Clear();
                txtCantidad.Clear();
                txtTotal.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar: " + ex.Message);
            }
        }
      //FUNCIÓN CALCULAR 
        private void btnCalcular_Click_1(object sender, EventArgs e)
        {
            decimal totalGeneral = 0;

            foreach (DataGridViewRow row in dgvVentas.Rows)
            {

                if (!row.IsNewRow && row.Cells["Total"].Value != null)
                {
                    try
                    {
                        decimal totalFila = Convert.ToDecimal(row.Cells["Total"].Value);
                        totalGeneral += totalFila;
                    }
                    catch
                    {
                        MessageBox.Show("Error al calcular el total. Verifique los valores en la tabla.");
                        return;
                    }
                }
            }

            txtTotal.Text = totalGeneral.ToString("0.00");
        }

    }
}
