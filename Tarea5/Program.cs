bool continuar = true;
List<Estudiante> Estudiantes = new List<Estudiante>();
if (System.IO.File.Exists("datos.json"))
{
    try
    {
        var json = System.IO.File.ReadAllText("datos.json");
        Estudiantes = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Estudiante>>(json);
    }
    catch (Exception)
    {
        Utils.MostrarMensajeError("Error al leer el archivo datos.json");
    }
}
else
{

    Utils.MostrarMensajeError("No existe el archivo datos.json");
}


while (continuar)
{
    Utils.Reproducir("greeting.wav");
    Console.Clear();
    Console.WriteLine(@"
    
    Le damos la bienvenida al sistema, elija la opcion deseada:

        1. Agregar estudiante
        2. Listado de estudiantes
        3. Modificar estudiantes
        4. Eliminar estudiantes
        5. Exportar estudiantes
        6. Acerca de
        x. Salir
    ");
    var opcion = Utils.LeerString("Ingresar una opcion: ");
    switch (opcion.ToLower())
    {
        case "1":
            Utils.Reproducir("agregar.wav");
            Console.Clear();
            Console.WriteLine("Vamos a agregar un estudiante. ");
            var e = new Estudiante();
            e.matricula = Utils.LeerString("Ingrese una matricula: ");
            e.nombre = Utils.LeerString("Ingrese el nombre: ");
            e.apellido = Utils.LeerString("Ingrese el apellido: ");
            e.edad = Utils.LeerString("Ingrese la edad: ");
            e.N1 = Utils.LeerDouble("Ingrese la nota 1: ");
            e.N2 = Utils.LeerDouble("Ingrese la nota 2: ");
            Estudiantes.Add(e);
            Procesos.GuardarEstudiantes(Estudiantes);
            Utils.MostrarMensaje("Estudiante agregado", ConsoleColor.Blue);
            break;
        case "2":
            Utils.Reproducir("listado.wav");
            Console.Clear();
            Console.WriteLine("Listado de Estudiantes");
            foreach (var estudiante in Estudiantes)
            {
                Console.WriteLine(@$"
                Matricula: {estudiante.matricula}
                Nombre: {estudiante.nombre}
                Apellido: {estudiante.apellido}
                Edad: {estudiante.edad}
                Nota 1: {estudiante.N1}
                Nota 2: {estudiante.N2}
                Promedio: {estudiante.promedio()}
                Literal: {estudiante.literal()}
                ----------------------------------------------------------------

                ");
            }
            Utils.MostrarMensaje("Presione ENTER para continuar", ConsoleColor.Red);

            break;
        case "3":
            Estudiantes = Procesos.Modificar(Estudiantes);
            break;
        case "4":
            Estudiantes = Procesos.Eliminar(Estudiantes);
            break;
        case "5":
            Procesos.Exportar(Estudiantes);
            break;
        case "6":
            Procesos.AcercaDe();
            break;
        case "x":
            continuar = false;

            Procesos.GuardarEstudiantes(Estudiantes);

            Utils.MostrarMensaje("Gracias por usas nuestro porgrama.", ConsoleColor.Blue);
            break;

    }
}