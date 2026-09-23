using System;
using System.Collections.Generic;
using Agenda.Entidades;
using Agenda.Negocio;

PersonaNegocio negocio = new PersonaNegocio();

int opcion;

do
{
    Console.Clear();

    Console.WriteLine("===== AGENDA =====");
    Console.WriteLine("1. Agregar");
    Console.WriteLine("2. Buscar");
    Console.WriteLine("3. Modificar");
    Console.WriteLine("4. Eliminar");
    Console.WriteLine("5. Salir");
    Console.Write("Opción: ");

    if (!int.TryParse(Console.ReadLine(), out opcion))
    {
        Console.WriteLine("Debe ingresar un número.");
        Console.WriteLine("\nPresione ENTER para continuar...");
        Console.ReadLine();
        continue;
    }

    try
    {
        switch (opcion)
        {
            case 1:
                Agregar();
                break;

            case 2:
                Buscar();
                break;

            case 3:
                Modificar();
                break;

            case 4:
                Eliminar();
                break;

            case 5:
                Console.WriteLine("Programa finalizado.");
                break;

            default:
                Console.WriteLine("Opción incorrecta.");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("ERROR: " + ex.Message);
    }

    if (opcion != 5)
    {
        Console.WriteLine("\nPresione ENTER para continuar...");
        Console.ReadLine();
    }

} while (opcion != 5);


void Agregar()
{
    Persona persona = new Persona();

    Console.Write("DNI: ");

    if (!int.TryParse(Console.ReadLine(), out int dni))
        throw new Exception("El DNI debe ser un número.");

    persona.Dni = dni;

    Console.Write("Apellido: ");
    persona.Apellido = Console.ReadLine();

    Console.Write("Nombres: ");
    persona.Nombres = Console.ReadLine();

    Console.Write("Calle: ");
    persona.Calle = Console.ReadLine();

    Console.Write("Depto: ");
    persona.Depto = Console.ReadLine();

    Console.Write("Piso: ");

    if (!int.TryParse(Console.ReadLine(), out int piso))
        throw new Exception("El piso debe ser un número.");

    persona.Piso = piso;

    Console.Write("Ciudad: ");
    persona.Ciudad = Console.ReadLine();

    Console.Write("Teléfono: ");
    persona.Telefono = Console.ReadLine();

    Console.Write("Email: ");
    persona.Email = Console.ReadLine();


    // CUENTA CORRIENTE

    CuentaCte cuenta = new CuentaCte();

    Console.Write("ID de la cuenta corriente: ");

    if (!int.TryParse(Console.ReadLine(), out int idCuenta))
        throw new Exception("El ID de la cuenta debe ser un número.");

    cuenta.Id = idCuenta;

    Console.Write("ID de Agenda: ");

    if (!int.TryParse(Console.ReadLine(), out int idAgenda))
        throw new Exception("El ID de Agenda debe ser un número.");

    cuenta.IdAgenda = idAgenda;

    Console.Write("Fecha de apertura (dd/MM/yyyy): ");

    if (!DateTime.TryParse(Console.ReadLine(), out DateTime fechaApertura))
        throw new Exception("La fecha de apertura no es válida.");

    cuenta.FechaApertura = fechaApertura;

    Console.Write("Límite de crédito: ");

    if (!decimal.TryParse(Console.ReadLine(), out decimal limiteCredito))
        throw new Exception("El límite de crédito debe ser un número.");

    cuenta.LimiteCredito = limiteCredito;

    Console.Write("Estado de crédito (Activo/Suspendido): ");
    cuenta.EstadoCredito = Console.ReadLine();


    // GUARDA PERSONA + CUENTA MEDIANTE TRANSACCIÓN

    negocio.AgregarConCuenta(persona, cuenta);

    Console.WriteLine("\nPersona y cuenta corriente agregadas correctamente.");
}


void Buscar()
{
    Console.WriteLine("===== BUSCAR =====");
    Console.WriteLine("1. DNI");
    Console.WriteLine("2. Apellido");
    Console.WriteLine("3. Nombres");
    Console.WriteLine("4. Calle");

    Console.Write("Opción: ");

    if (!int.TryParse(Console.ReadLine(), out int opcion))
    {
        Console.WriteLine("Debe ingresar un número.");
        return;
    }

    string campo = "";

    switch (opcion)
    {
        case 1:
            campo = "DNI";
            break;

        case 2:
            campo = "APELLIDO";
            break;

        case 3:
            campo = "NOMBRES";
            break;

        case 4:
            campo = "CALLE";
            break;

        default:
            Console.WriteLine("Opción incorrecta.");
            return;
    }

    Console.Write("Ingrese el dato a buscar: ");
    string valor = Console.ReadLine();

    List<Persona> personas = negocio.Buscar(campo, valor);

    if (personas.Count == 0)
    {
        Console.WriteLine("No se encontraron personas.");
    }
    else
    {
        foreach (Persona persona in personas)
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine("DNI: " + persona.Dni);
            Console.WriteLine("Apellido: " + persona.Apellido);
            Console.WriteLine("Nombres: " + persona.Nombres);
            Console.WriteLine("Calle: " + persona.Calle);
            Console.WriteLine("Depto: " + persona.Depto);
            Console.WriteLine("Piso: " + persona.Piso);
            Console.WriteLine("Ciudad: " + persona.Ciudad);
            Console.WriteLine("Teléfono: " + persona.Telefono);
            Console.WriteLine("Email: " + persona.Email);
        }
    }
}


void Modificar()
{
    Persona persona = new Persona();

    Console.Write("Ingrese el DNI de la persona a modificar: ");

    if (!int.TryParse(Console.ReadLine(), out int dni))
        throw new Exception("El DNI debe ser un número.");

    persona.Dni = dni;

    Console.Write("Nuevo apellido: ");
    persona.Apellido = Console.ReadLine();

    Console.Write("Nuevos nombres: ");
    persona.Nombres = Console.ReadLine();

    Console.Write("Nueva calle: ");
    persona.Calle = Console.ReadLine();

    Console.Write("Nuevo depto: ");
    persona.Depto = Console.ReadLine();

    Console.Write("Nuevo piso: ");

    if (!int.TryParse(Console.ReadLine(), out int piso))
        throw new Exception("El piso debe ser un número.");

    persona.Piso = piso;

    Console.Write("Nueva ciudad: ");
    persona.Ciudad = Console.ReadLine();

    Console.Write("Nuevo teléfono: ");
    persona.Telefono = Console.ReadLine();

    Console.Write("Nuevo email: ");
    persona.Email = Console.ReadLine();

    negocio.Modificar(persona);

    Console.WriteLine("Persona modificada correctamente.");
}


void Eliminar()
{
    Console.Write("Ingrese el DNI a eliminar: ");

    if (!int.TryParse(Console.ReadLine(), out int dni))
        throw new Exception("El DNI debe ser un número.");

    negocio.Eliminar(dni);

    Console.WriteLine("Persona eliminada correctamente.");
}

