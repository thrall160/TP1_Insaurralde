using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using Dominio;

namespace Negocio
{
    public class NegocioCategoria
    {

		public List<Categoria> CargarCategorias()
		{

			List<Categoria> Listado = new List<Categoria>();
			SqlConnection Conexion = new SqlConnection();
			SqlCommand Comando = new SqlCommand();
			SqlDataReader Leeme;

			try
			{
				Conexion.ConnectionString = "data source=DESKTOP-91LML6F\\SQLEXPRESS; initial catalog=CATALOGO_DB; integrated security=sspi";
				Comando.CommandType = System.Data.CommandType.Text;
				Comando.CommandText = "select *from categorias";
				Comando.Connection = Conexion;
				Conexion.Open();

				Leeme = Comando.ExecuteReader();

				while (Leeme.Read())
				{
					Categoria aux = new Categoria();

					aux.id = Leeme.GetInt32(0);
					aux.NombreCategoria = Leeme.GetString(1);

					Listado.Add(aux);


				}

				return Listado;
			}
			catch (Exception ex)
			{

				throw ex;
			}

		}
	}
}
