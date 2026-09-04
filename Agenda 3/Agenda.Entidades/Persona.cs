using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Entidades
{
    public class Persona
    {
        public int DNI { get; set; }
        public string APELLIDO { get; set; }
        public string NOMBRES { get; set; }
        public string CALLE { get; set; }
        public string DEPTO { get; set; }
        public int PISO { get; set; }
        public string CIUDAD { get; set; }
        public string TELEFONO { get; set; }
        public string EMAIL { get; set; }
    }
}