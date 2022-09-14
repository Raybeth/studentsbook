class Utils
{
    public static string LeerString(string mensaje)
    {
        Console.Write(mensaje);
        return Console.ReadLine() ?? "";
    }
    public static double LeerDouble(string mensaje)
    {
        Console.WriteLine(mensaje);
        double num = 0;
        while (!double.TryParse(Console.ReadLine(), out num))
        {
            MostrarMensaje("Ingrese un numero valido", ConsoleColor.Red);
        }
        return num;
    }

    public static void MostrarMensajeError(string mensaje)
    {
        MostrarMensaje(mensaje, ConsoleColor.Red);
    }
    public static void MostrarMensaje(string mensaje, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write(mensaje);
        Console.ResetColor();
        Console.ReadKey();

    }
    public static void LineaColor(string linea, ConsoleColor color){
    Console.ForegroundColor = color;
    Console.Write(linea);
    Console.ResetColor();
    }


    public static void Reproducir(string audio){
        audio = $"audio";
        System.Diagnostics.Process.Start(@"powershell",$@-c (New-Object Media.SoundPlayer '{audio}').PlaySync();");
    }
}