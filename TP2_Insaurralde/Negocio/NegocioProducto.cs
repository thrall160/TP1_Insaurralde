using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using Dominio;

namespace TP2_Insaurralde
{
    public class NegocioProducto
    {
		

		public List <Producto> Listar()
        {
		    SqlConnection Conexion = new SqlConnection("data source=DESKTOP-91LML6F\\SQLEXPRESS; initial catalog=CATALOGO_DB; integrated security=sspi");

		    List<Producto> Listado = new List<Producto>();
			SqlCommand Comando = new SqlCommand();
			SqlDataReader Leeme;

			try
			{
				Comando.CommandType = System.Data.CommandType.Text;
				//Comando.CommandText = "select *from articulos";

				Comando.CommandText = "select A.Id, A.Codigo,A.Nombre, A.Descripcion, M.Descripcion[Marca], C.Descripcion[Categoria], A.ImagenUrl,A.Precio from ARTICULOS A, MARCAS M, CATEGORIAS C where A.IdMarca = m.Id AND A.IdCategoria = C.Id";
				Comando.Connection = Conexion;

				Conexion.Open();

				Leeme = Comando.ExecuteReader();

				while (Leeme.Read())
				{
					Producto auxiliar = new Producto();

					////auxiliar.Nombre = (string)Leeme["Nombre"];
					auxiliar.Id = Leeme.GetInt32(0);
					auxiliar.Codigo = Leeme.GetString(1);
					auxiliar.Nombre = Leeme.GetString(2);
					auxiliar.Descripcion = Leeme.GetString(3);
					auxiliar.marca = new Marca();
					auxiliar.marca.NombreMarca = Leeme.GetString(4);
					auxiliar.categoria = new Categoria();
					auxiliar.categoria.NombreCategoria = Leeme.GetString(5);
					auxiliar.ImagenUrl = Leeme.GetString(6);
					auxiliar.Precio = (double)Leeme.GetDecimal(7);
					
					Listado.Add(auxiliar);

				}


				return Listado;
			}
			catch (Exception ex)
			{

				throw ex;
			}

			finally
			{

				Conexion.Close();
			}

			
		}

		public void Eliminar(int id)
		{

			SqlConnection Conexion = new SqlConnection("data source=DESKTOP-91LML6F\\SQLEXPRESS; initial catalog=CATALOGO_DB; integrated security=sspi");

			try
			{
				SqlCommand Comando = new SqlCommand();

				Comando.CommandType = System.Data.CommandType.Text;
				Comando.CommandText = ("delete from articulos where Id =" + id);
				Comando.Connection = Conexion;
				Conexion.Open();
				Comando.ExecuteNonQuery();


			}
			catch (Exception ex)
			{

				throw ex;
			}
			

		}

		public void Agregar(Producto Agregado)
		{
			SqlConnection Conexion = new SqlConnection("data source=DESKTOP-91LML6F\\SQLEXPRESS; initial catalog=CATALOGO_DB; integrated security=sspi");

			try
			{


				SqlCommand Comando = new SqlCommand();
				Comando.CommandType = System.Data.CommandType.Text;
				Comando.CommandText = "insert into articulos (Codigo,Nombre,Descripcion,IdMarca,IdCategoria,ImagenUrl,Precio) Values (@Codigo,@Nombre,@Descripcion,@IdMarca,@IdCategoria,@ImagenUrl,@Precio)";
				Comando.Parameters.Clear();
				Comando.Connection = Conexion;

				Comando.Parameters.AddWithValue("@Codigo", Agregado.Codigo);
				Comando.Parameters.AddWithValue("@Nombre", Agregado.Nombre);
				Comando.Parameters.AddWithValue("@Descripcion", Agregado.Descripcion);
				 
			    Comando.Parameters.AddWithValue("@IdMarca", Agregado.marca.Id);
				Comando.Parameters.AddWithValue("@IdCategoria", Agregado.categoria.id);


				Comando.Parameters.AddWithValue("@ImagenUrl", Agregado.ImagenUrl);
				Comando.Parameters.AddWithValue("@Precio", Agregado.Precio);

				Conexion.Open();

				Comando.ExecuteNonQuery();
				

			}
			catch (Exception ex)
			{

				throw ex;
			}

			finally
			{

				Conexion.Close();
			}

		}



		public void Buscar (string RegistroABuscar)
		{
			SqlConnection Conexion = new SqlConnection("data source=DESKTOP-91LML6F\\SQLEXPRESS; initial catalog=CATALOGO_DB; integrated security=sspi");

			try
			{
				SqlCommand Comando = new SqlCommand("Update from articulos");
				Comando.CommandType = System.Data.CommandType.Text;
				Comando.Connection = Conexion;
				Conexion.Open();
			}


			catch (Exception ex)
			{

				throw ex;
			}

			finally
			{

				Conexion.Close();

			}




		}

		public void Modificar(Producto modificar)
		{
			SqlConnection Conexion = new SqlConnection("data source=DESKTOP-91LML6F\\SQLEXPRESS; initial catalog=CATALOGO_DB; integrated security=sspi");

		     try
			{
				SqlCommand Comando = new SqlCommand();
				Comando.CommandType = System.Data.CommandType.Text;

				Comando.CommandText = "update articulos set Nombre=@nombre,@Codigo=codigo,Descripcion=@Descripcion,ImagenUrl=@Imagen,Precio=@Precio where Id=@id";
				Comando.Connection = Conexion;

				Comando.Parameters.AddWithValue("@nombre", modificar.Nombre);
				Comando.Parameters.AddWithValue("@id", modificar.Id);
				Comando.Parameters.AddWithValue("@Codigo", modificar.Codigo);
				Comando.Parameters.AddWithValue("@Precio", modificar.Precio);
				Comando.Parameters.AddWithValue("@Imagen", modificar.ImagenUrl);
				Comando.Parameters.AddWithValue("@Descripcion", modificar.Descripcion);



				Conexion.Open();
				Comando.ExecuteNonQuery();

				

			}
			catch (Exception ex)
			{

				throw ex;
			}

			finally
			{
				Conexion.Close();

			}


		}




	}
}
