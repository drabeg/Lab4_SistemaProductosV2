using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace drabeg_Forms_14_03
{
    //La palabra clave partial permite dividir la definición de una clase, estructura o interfaz en varios archivos.
    //Creación de Form1 que hereda de la clase Form, lo que significa que Form1 es un tipo de formulario de Windows Forms.
    public partial class Form1: Form
    {
        //Crear una lista que almacene objeto del producto
        List<Producto> listProducto = new List<Producto>();
        public Form1()

        { 
            InitializeComponent();
        }

        //Creación de un método manejador de eventos (event handler) que se ejecuta cuando se hace clic en el botón "Agregar".

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Verificador de datos ingresados en los textboxes, para evitar errores al momento de agregar un producto a la lista y al DataGridView.
            if (string.IsNullOrWhiteSpace(txtCodigo.Text) || string.IsNullOrWhiteSpace(txtProducto.Text) ||
                string.IsNullOrWhiteSpace(txtCantidad.Text) || string.IsNullOrWhiteSpace(txtPrecio.Text) ||
                string.IsNullOrWhiteSpace(txtStock.Text) || string.IsNullOrWhiteSpace(txtGarantia.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Ingreso de datos
            string codigo = txtCodigo.Text;
            string producto = txtProducto.Text;
            int cantidad = int.Parse(txtCantidad.Text);
            double precio = double.Parse(txtPrecio.Text);
            int stock = int.Parse(txtStock.Text);
            string garantia = txtGarantia.Text;
            DateTime fecha = dtpGarantia.Value;

            //Crear objeto y guardar
            Producto p = new Producto(codigo, producto, cantidad, precio, stock, garantia, fecha);
            listProducto.Add(p);

            //Mostrar en la tabla
            dgvProducto.Rows.Add(codigo, producto, cantidad, precio, stock, garantia, fecha.ToShortDateString());

            //Llamar al método para limpiar los textboxes después de agregar un producto.
            Limpiar();

            //Mensaje de confirmación
            MessageBox.Show("Producto agregado correctamente.");
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //Creación de condicional para verificar si en DataGrid View
            //hay al menos una fila antes de ejecutar alguna acción sobre ella.
            if (dgvProducto.SelectedRows.Count > 0)
            {
                DialogResult resultado = MessageBox.Show(
                    "¿Está seguro de eliminar el producto seleccionado?", 
                    "Confirmar eliminación", 
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    dgvProducto.Rows.RemoveAt(dgvProducto.SelectedRows[0].Index);
                    MessageBox.Show("Producto eliminado correctamente.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un producto para eliminar.");
            }
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        //Creación de método para limpiar los textboxes
        private void Limpiar()
        {
            txtCodigo.Clear();
            txtProducto.Clear();
            txtCantidad.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
            txtGarantia.Clear();

            txtCodigo.Focus();
        }    
        //Creación de método para llenar formulario
        private void Form1_Load(object sender, EventArgs e) 
        {
            //Título del formulario
            this.Text = "Sistem de Control de Productos - V 2.0";

            dgvProducto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducto.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProducto.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            dgvProducto.Columns.Add("Código", "Código");
            dgvProducto.Columns.Add("Producto", "Producto");
            dgvProducto.Columns.Add("Cantidad", "Cantidad");
            dgvProducto.Columns.Add("Precio", "Precio");
            dgvProducto.Columns.Add("Stock", "Stock");
            dgvProducto.Columns.Add("Garantía", "Garantía");
            dgvProducto.Columns.Add("Fecha", "Fecha Garantía");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
