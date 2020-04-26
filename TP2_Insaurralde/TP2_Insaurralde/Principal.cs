using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

/*
 *
 
  
 Listar (Falta mostrar precio) y preguntar IdMarca, IdCategoria
 Eliminar (Chequear)
 Buscar (Chequear)
 Agregar (Faltan Validaciones) y preguntar sobre idmarca, idcategoria
 Modificar (Chequear)

    Si queda tiempo hacer la interfaz un poco mas amigable a los ojos
     
    19/4/2020
     */

namespace TP2_Insaurralde
{
    public partial class Principal : Form
    {

        private List<Producto> Lista;
        
        public Principal()
        {

            InitializeComponent();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            Form AbrirAgregar = new Agregar();

            AbrirAgregar.ShowDialog();
            CargarDatos();
        }

        private void PbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            NegocioProducto negocio = new NegocioProducto();
            
            try
            {
                int id = ((Producto)DgvArticulos.CurrentRow.DataBoundItem).Id;
                
                negocio.Eliminar(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            CargarDatos();

        }

      

        private void Principal_Load_1(object sender, EventArgs e)
        {

            CargarDatos();
        }

        private void CargarDatos()
        {


            NegocioProducto Listame = new NegocioProducto();
    
            try
            {

                Lista = Listame.Listar();
                
                DgvArticulos.DataSource = Listame.Listar();
                DgvArticulos.Columns[6].Visible = false;
                DgvArticulos.Columns[0].Visible = false;

            }
            catch (Exception ex)
            {


                throw ex;
            }

        }

        private void DgvArticulos_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {

                Producto P;

                P = (Producto)DgvArticulos.CurrentRow.DataBoundItem;

                PbFoto.Load(P.ImagenUrl);

            }
            catch (Exception)
            {

                PbFoto.Load("https://lh6.ggpht.com/q6ZdwPZqnglxkwCSeVkKpNfqKn0ztX6ukBik0tb8MCdr-RNq96dtk-zADWj5k3Nyhq_1=w300");

                
            }
        }

 

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            Producto modificar;
            
            modificar = (Producto)DgvArticulos.CurrentRow.DataBoundItem;
            Agregar FrmAgregar = new Agregar(modificar);
            FrmAgregar.Text = "Modificar";
            FrmAgregar.ShowDialog();
            CargarDatos(); 
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            List<Producto> Pikachu;

            try
            {
                if (TxtBuscar.Text == "") Pikachu = Lista;
                else Pikachu = Lista.FindAll(Meteoro => Meteoro.Nombre.ToLower().Contains(TxtBuscar.Text.ToLower())); DgvArticulos.DataSource = Pikachu;

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

        private void BtnAgregar_Click_1(object sender, EventArgs e)
        {
            Form AbrirAgregar = new Agregar();

            AbrirAgregar.ShowDialog();
            CargarDatos();
        }

        private void PbSalir_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
