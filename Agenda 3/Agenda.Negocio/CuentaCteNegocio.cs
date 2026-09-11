using System;
using Agenda.Datos;
using Agenda.Entidades;

namespace Agenda.Negocio
{
    public class CuentaCteNegocio
    {
        private CuentaCteDatos datos = new CuentaCteDatos();

        public void Agregar(CuentaCte cuenta)
        {
            if (cuenta.LimiteCredito < 0)
                throw new Exception("El límite de crédito no puede ser negativo.");

            if (cuenta.EstadoCredito != "Activo" &&
                cuenta.EstadoCredito != "Suspendido")
            {
                throw new Exception("El estado debe ser Activo o Suspendido.");
            }

            datos.Agregar(cuenta);
        }

        public void Modificar(CuentaCte cuenta)
        {
            if (cuenta.LimiteCredito < 0)
                throw new Exception("El límite de crédito no puede ser negativo.");

            if (cuenta.EstadoCredito != "Activo" &&
                cuenta.EstadoCredito != "Suspendido")
            {
                throw new Exception("El estado debe ser Activo o Suspendido.");
            }

            datos.Modificar(cuenta);
        }

        public void EliminarPorAgenda(int idAgenda)
        {
            datos.EliminarPorAgenda(idAgenda);
        }
    }
}