using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Agenda.Entidades
{
    public class CuentaCte
    {
        public int Id { get; set; }

        public int Id_Agenda { get; set; }

        public DateTime FechaApertura { get; set; }

        public decimal LimiteCredito { get; set; }

        public string EstadoCredito { get; set; }
    }
}