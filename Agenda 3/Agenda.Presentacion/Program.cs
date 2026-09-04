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

    opcion = int.Parse(Console.ReadLine());

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
    persona.DNI = int.Parse(Console.ReadLine());

    Console.Write("Apellido: ");
    persona.APELLIDO = Console.ReadLine();

    Console.Write("Nombres: ");
    persona.NOMBRES = Console.ReadLine();

    Console.Write("Calle: ");
    persona.CALLE = Console.ReadLine();

    Console.Write("Depto: ");
    persona.DEPTO = Console.ReadLine();

    Console.Write("Piso: ");
    persona.PISO = int.Parse(Console.ReadLine());

    Console.Write("Ciudad: ");
    persona.CIUDAD = Console.ReadLine();

    Console.Write("Teléfono: ");
    persona.TELEFONO = Console.ReadLine();

    Console.Write("Email: ");
    persona.EMAIL = Console.ReadLine();

    negocio.Agregar(persona);

    Console.WriteLine("\nPersona agregada correctamente.");
}


void Buscar()
{
    Console.WriteLine("===== BUSCAR =====");
    Console.WriteLine("1. DNI");
    Console.WriteLine("2. Apellido");
    Console.WriteLine("3. Nombres");
    Console.WriteLine("4. Calle");

    Console.Write("Opción: ");
    int opcion = int.Parse(Console.ReadLine());

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
            Console.WriteLine("DNI: " + persona.DNI);
            Console.WriteLine("Apellido: " + persona.APELLIDO);
            Console.WriteLine("Nombres: " + persona.NOMBRES);
            Console.WriteLine("Calle: " + persona.CALLE);
            Console.WriteLine("Depto: " + persona.DEPTO);
            Console.WriteLine("Piso: " + persona.PISO);
            Console.WriteLine("Ciudad: " + persona.CIUDAD);
            Console.WriteLine("Teléfono: " + persona.TELEFONO);
            Console.WriteLine("Email: " + persona.EMAIL);
        }
    }
}


void Modificar()
{
    Persona persona = new Persona();

    Console.Write("Ingrese el DNI de la persona a modificar: ");
    persona.DNI = int.Parse(Console.ReadLine());

    Console.Write("Nuevo apellido: ");
    persona.APELLIDO = Console.ReadLine();

    Console.Write("Nuevos nombres: ");
    persona.NOMBRES = Console.ReadLine();

    Console.Write("Nueva calle: ");
    persona.CALLE = Console.ReadLine();

    Console.Write("Nuevo depto: ");
    persona.DEPTO = Console.ReadLine();

    Console.Write("Nuevo piso: ");
    persona.PISO = int.Parse(Console.ReadLine());

    Console.Write("Nueva ciudad: ");
    persona.CIUDAD = Console.ReadLine();

    Console.Write("Nuevo teléfono: ");
    persona.TELEFONO = Console.ReadLine();

    Console.Write("Nuevo email: ");
    persona.EMAIL = Console.ReadLine();

    negocio.Modificar(persona);

    Console.WriteLine("Persona modificada correctamente.");
}


void Eliminar()
{
    Console.Write("Ingrese el DNI a eliminar: ");
    int dni = int.Parse(Console.ReadLine());

    negocio.Eliminar(dni);

    Console.WriteLine("Persona eliminada correctamente.");
}