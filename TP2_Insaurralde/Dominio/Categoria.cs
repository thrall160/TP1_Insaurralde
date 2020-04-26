using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Categoria
    {
        public int id { get; set; }
        public string NombreCategoria { get; set; }

        public Categoria() { }

        public Categoria(int ide, string Categoria) {

            id = ide;

            NombreCategoria = Categoria;

        
        }
        public override string ToString()
        {
            return NombreCategoria;
        }

    }
}
