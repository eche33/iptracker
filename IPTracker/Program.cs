internal class Program
{
    private static void Main(string[] args)
    {
        bool stop = false;

        var iptracker = new IPTracker();

        while (!stop)
        {
            Console.WriteLine("---- MENÚ ----");
            Console.WriteLine("1. Rastrear IP");
            Console.WriteLine("2. Obtener estadísticas");
            Console.WriteLine("3. Salir");
            Console.Write("Elige una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    TraceIP(iptracker);
                    break;
                case "2":
                    Console.WriteLine("Rastrear IP");
                    break;
                case "3":
                    stop = true;
                    break;
                default:
                    Console.WriteLine("Opción inválida. Inténtalo nuevamente.");
                    break;
            }

            Console.WriteLine();
        }
    }

    private static void TraceIP(IPTracker iptracker)
    {
        Console.Write("Ingresa la IP a rastrear: ");
        string ipToTrack = Console.ReadLine();

        iptracker.TrackIP(ipToTrack);
    }
}