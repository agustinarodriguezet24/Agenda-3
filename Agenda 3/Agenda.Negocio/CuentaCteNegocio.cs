using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using Datos;

namespace Negocio
{
    public class CuentaCteNegocio
    {
        private CuentaCteDatos datos = new CuentaCteDatos();

        public void Agregar(CuentaCte cuenta)
        {
            if (cuenta.LimiteCredito < 0)
            {
                throw new Exception("El límite de crédito no puede ser negativo.");
            }

            if (cuenta.EstadoCredito != "Activo" &&
                cuenta.EstadoCredito != "Suspendido")
            {
                throw new Exception("El estado debe ser Activo o Suspendido.");
            }

            datos.Agregar(cuenta);
        }
    }
}