using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace Negocio
{
    public class NegocioMarca
    {


		public List<Marca> CargarMarcas()
		{

			List<Marca> Listado = new List<Marca>();
			SqlConnection Conexion = new SqlConnection();
			SqlCommand Comando = new SqlCommand();
			SqlDataReader Leeme;

			try
			{
				Conexion.ConnectionString = "data source=DESKTOP-91LML6F\\SQLEXPRESS; initial catalog=CATALOGO_DB; integrated security=sspi";
				Comando.CommandType = System.Data.CommandType.Text;
				Comando.CommandText = "select *from marcas";
				Comando.Connection = Conexion;
				Conexion.Open();

				Leeme = Comando.ExecuteReader();

				while (Leeme.Read())
				{
					Marca aux = new Marca();

					aux.Id = Leeme.GetInt32(0);
					aux.NombreMarca = Leeme.GetString(1);

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
