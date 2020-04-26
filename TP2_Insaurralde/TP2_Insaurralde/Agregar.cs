using Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Negocio;
using System.Collections.Concurrent;

namespace TP2_Insaurralde
{
    public partial class Agregar : Form
    {

        private Producto producto = null;
        public Agregar()
        {
            InitializeComponent();
        }

        public Agregar(Producto p)
        {
            InitializeComponent();
            this.producto = p;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Agregar_Load(object sender, EventArgs e)
        {
            NegocioCategoria negocio = new NegocioCategoria();
            NegocioMarca negocio2 = new NegocioMarca();

            try
            {

                CmbCategoria.DataSource = negocio.CargarCategorias();
                CmbMarca.DataSource = negocio2.CargarMarcas();

                CmbCategoria.ValueMember = "Id";
                CmbCategoria.DisplayMember = "NombreCategoria";

                CmbMarca.ValueMember = "Id";
                CmbMarca.DisplayMember = "NombreMarca";

                if(producto != null)
                {
                    TxtCodigo.Text = producto.Codigo;
                    TxtNombre.Text = producto.Nombre;
                    TxtDescripcion.Text = producto.Descripcion;
                    TxtImagenUrl.Text = producto.ImagenUrl;
                    TxtPrecio.Text = Convert.ToString(producto.Precio);
                    CmbCategoria.SelectedValue = producto.categoria.id;
                    //CmbMarca.SelectedValue = producto.marca.Id;

                }


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void BtnAgregar_Click_1(object sender, EventArgs e)
        {
            NegocioProducto negocioProducto = new NegocioProducto();

            try
            {
                if (producto == null) producto = new Producto();

                producto.Codigo = TxtCodigo.Text;
                producto.Nombre = TxtNombre.Text;
                producto.Descripcion = TxtDescripcion.Text;
                producto.ImagenUrl = TxtImagenUrl.Text;

                producto.categoria = (Categoria)CmbCategoria.SelectedItem;
                producto.marca = (Marca)CmbMarca.SelectedItem;

                producto.Precio = double.Parse(TxtPrecio.Text);

                if (producto.Id == 0) negocioProducto.Agregar(producto);

                else   negocioProducto.Modificar(producto);

                this.Close();

            }
            catch (Exception ex)
            {

                throw ex;
            }



        }

        private void PbSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 59) && e.KeyChar != 8)
                e.Handled = true;
        }
    }
}
