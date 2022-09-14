class Procesos
{
    public static List<Estudiante> Modificar(List<Estudiante> estudiantes) //Modofificar Estudiante //
    {
        var n = 0;
        Console.Clear();
        Console.WriteLine("Listado de Estudiante...");
        foreach (var estudiante in estudiantes)
        {
            Console.WriteLine(@$" {n} {estudiante.matricula} {estudiante.nombre} {estudiante.apellido}");
            n++;
        }
        var eleccion = (int)Utils.LeerDouble("Ingrese el numero del estudiante que desea modificar: ");

        if (eleccion >= 0 && eleccion < estudiantes.Count)
        {
            var estudiante = estudiantes[eleccion];
            var posible = "";
            Utils.MostrarMensaje($"La matricula actual es {estudiante.matricula} digite una nueva matricula o presione Enter para continuar.", ConsoleColor.DarkGreen);
            posible = Utils.LeerString("Ingrese la matricula: ");
            if (posible.Length > 0)
            {
                estudiante.matricula = posible;
            }
            Utils.MostrarMensaje($"El nombre actual es {estudiante.nombre} digite un nuevo nombre o presione Enter para continuar.", ConsoleColor.DarkGreen);
            posible = Utils.LeerString("Ingrese el nombre: ");
            if (posible.Length > 0)
            {
                estudiante.nombre = posible;
            }
            Utils.MostrarMensaje($"El apellido actual es {estudiante.apellido} digite un nuevo apellido o presione Enter para continuar.", ConsoleColor.DarkGreen);
            posible = Utils.LeerString("Ingrese el apellido: ");
            if (posible.Length > 0)
            {
                estudiante.apellido = posible;
            }
            Utils.MostrarMensaje($"La edad actual es {estudiante.edad} digite una nueva edad o presione Enter para continuar.", ConsoleColor.DarkGreen);
            posible = Utils.LeerString("Ingrese la edad: ");
            if (posible.Length > 0)
            {
                estudiante.edad = posible;
            }
            Utils.MostrarMensaje($"La nota 1 actual es {estudiante.N1} digite una nueva NOTA 1 o presione Enter para continuar.", ConsoleColor.DarkGreen);
            posible = Utils.LeerString("Ingrese la Nota 1: ");
            if (posible.Length > 0)
            {
                estudiante.N1 = Convert.ToDouble(posible);
            }
            Console.WriteLine($"La nota 2 actual es {estudiante.N2} digite una nueva NOTA 2 o presione Enter para continuar.");
            posible = Utils.LeerString("Ingrese la Nota 2: ");
            if (posible.Length > 0)
            {
                estudiante.N2 = Convert.ToDouble(posible);
            }
            estudiantes[eleccion] = estudiante;
            Utils.MostrarMensaje("Estudiante modificado", ConsoleColor.Blue);
            Procesos.GuardarEstudiantes(estudiantes);

        }
        else
        {
            Utils.MostrarMensajeError("El numero ingresado no es valido");
        }

        return estudiantes;
    }

    public static void GuardarEstudiantes(List<Estudiante> estudiantes)
    {        //Guardar estudiante//
        var tmp = Newtonsoft.Json.JsonConvert.SerializeObject(estudiantes);
        System.IO.File.WriteAllText("datos.json", tmp);
    }

    public static List<Estudiante> Eliminar(List<Estudiante> estudiantes)
    { //Eliminar estudiante//
        Console.Clear();
        Console.WriteLine("Listado de estudiantes: ");
        var n = 0;
        foreach (var estudiante in estudiantes)
        {
            Utils.MostrarMensaje(@$" {n} {estudiante.matricula} {estudiante.nombre} {estudiante.apellido}", ConsoleColor.Blue);
            n++;
        }
        var eleccion = (int)Utils.LeerDouble("Ingrese el numero del estudiante que desea eliminar:  ");
        if (eleccion >= 0 && eleccion < estudiantes.Count)
        {
            estudiantes.RemoveAt(eleccion);
            Utils.MostrarMensaje("Estudiante Eliminado", ConsoleColor.DarkRed);
            Procesos.GuardarEstudiantes(estudiantes);
        }

        return estudiantes;
    }

    //Exportar los datos
    public static void Exportar(List<Estudiante> estudiantes)
    {
        Utils.MostrarMensaje("Exportando datos", ConsoleColor.DarkGreen);

        var filas = "";

        foreach (var est in estudiantes)
        {
            filas += @$"
            <tr>
                <td>{est.matricula}</td>
                <td>{est.nombre}</td>
                <td>{est.apellido}</td>
                <td>{est.edad}</td>
                <td>{est.N1}</td>
                <td>{est.N2}</td>
                <td>{est.promedio()}</td>
                <td>{est.literal()}</td>
            </tr>
            
            ";

        }

        var html = @$"
        <html>
            <head>
                <title>Listado de Estudiantes</title>


                <!-- Compiled and minified CSS -->
                <link rel='stylesheet' href='https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0/css/materialize.min.css'>
            </head>
            <body>
                <div class='container'>
                <h1>Listado de Estudiantes</h1>
                <table class='table'>
                    <tr>
                        <th>Matricula</th>
                        <th>Nombre</th>
                        <th>Apellido</th>
                        <th>Edad</th>
                        <th>Nota 1</th>
                        <th>Nota 2</th>
                        <th>Promedio</th>
                        <th>Literal</th>
                    </tr>
                    {filas}
                </table>
                </div>

            </body>

        </html>
    
    ";
        System.IO.File.WriteAllText("datos.html", html);
        var uri = "datos.html";
        var psi = new System.Diagnostics.ProcessStartInfo();
        psi.UseShellExecute = true;
        psi.FileName = uri;
        System.Diagnostics.Process.Start(psi);

        Utils.MostrarMensaje("Proceso finalizado", ConsoleColor.DarkCyan);
    }

    //Acerca del programador
    public static void AcercaDe()
    {
        Utils.MostrarMensaje(@"
               ......               
            .:||||||||:.            
           /            \           
          (   o      o   )          
--@@@@----------:  :----------@@@@--


PRESIONA *ENTER* PARA DESCUBRIR EL INTRUSO...
", ConsoleColor.Magenta);

        Utils.LineaColor("      Ada", ConsoleColor.Green);
        Utils.LineaColor(" Jimenez", ConsoleColor.Blue);
        Utils.LineaColor(" 20220790", ConsoleColor.Cyan);

        Console.ReadKey();
    }

}