using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Trabajo_Practico_1
{
    class Comision
    {
        public int IDcomi { get; set; }
        public Horario hs { get; set; }
        public int LegajoAlumno { get; set; }
        public int LegajoProfesor { get; set; }
        public Aula aula { get; set; }

    }
}
