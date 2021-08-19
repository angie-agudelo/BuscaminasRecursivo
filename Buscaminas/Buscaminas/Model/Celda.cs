using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Buscaminas.Model
{
    public class Celda : Button
    {
        public bool TieneBomba { get; set; }
        public int Columna { get; set; }
        public int Fila { get; set; }
    }
}
