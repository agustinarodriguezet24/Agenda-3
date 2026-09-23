
using System;
using System.Collections.Generic;
using Agenda.Datos;
using Agenda.Entidades;

namespace Agenda.Negocio
{
    public class PersonaNegocio
    {
        private PersonaDatos datos = new PersonaDatos();

        public void Agregar(Persona persona)
        {
            if (persona.Dni <= 0)
                throw new Exception("El DNI debe ser mayor a 0.");

            if (string.IsNullOrWhiteSpace(persona.Apellido))
                throw new Exception("El apellido es obligatorio.");

            if (string.IsNullOrWhiteSpace(persona.Nombres))
                throw new Exception("El nombre es obligatorio.");

            datos.Agregar(persona);
        }

        public void AgregarConCuenta(Persona persona, CuentaCte cuenta)
        {
            if (persona.Dni <= 0)
                throw new Exception("El DNI debe ser mayor a 0.");

            if (string.IsNullOrWhiteSpace(persona.Apellido))
                throw new Exception("El apellido es obligatorio.");

            if (string.IsNullOrWhiteSpace(persona.Nombres))
                throw new Exception("El nombre es obligatorio.");

            if (cuenta.LimiteCredito < 0)
                throw new Exception("El límite de crédito no puede ser negativo.");

            if (cuenta.EstadoCredito != "Activo" &&
                cuenta.EstadoCredito != "Suspendido")
            {
                throw new Exception("El estado debe ser Activo o Suspendido.");
            }

            datos.AgregarConCuenta(persona, cuenta);
        }

        public List<Persona> Buscar(string campo, string valor)
        {
            List<string> camposPermitidos = new List<string>
            {
                "DNI",
                "APELLIDO",
                "NOMBRES",
                "CALLE"
            };

            if (!camposPermitidos.Contains(campo))
                throw new Exception("Campo de búsqueda no permitido.");

            return datos.Buscar(campo, valor);
        }

        public void Eliminar(int dni)
        {
            datos.Eliminar(dni);
        }

        public void Modificar(Persona persona)
        {
            datos.Modificar(persona);
        }
    }
}

