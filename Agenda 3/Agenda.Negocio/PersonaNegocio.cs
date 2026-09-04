using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agenda.Datos;
using Agenda.Entidades;

namespace Agenda.Negocio
{
    public class PersonaNegocio
    {
        private PersonaDatos datos = new PersonaDatos();

        public void Agregar(Persona persona)
        {
            if (persona.DNI <= 0)
                throw new Exception("El DNI debe ser mayor a 0.");

            if (string.IsNullOrWhiteSpace(persona.APELLIDO))
                throw new Exception("El apellido es obligatorio.");

            if (string.IsNullOrWhiteSpace(persona.NOMBRES))
                throw new Exception("El nombre es obligatorio.");

            datos.Agregar(persona);
        }

        public List<Persona> Buscar(string campo, string valor)
        {
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