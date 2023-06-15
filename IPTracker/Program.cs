using Microsoft.Extensions.Configuration;
using Tracker;
using Tracker.Util;

internal class Program
{
    private static async Task Main(string[] args)
    {
        bool stop = false;
        var iptracker = new IPTracker();

        Console.WriteLine($"{AppSettings.Get("ConnectionString")}");

        while (!stop)
        {
            Console.WriteLine("---- MENÚ ----");
            Console.WriteLine("1. Rastrear IP");
            Console.WriteLine("2. Obtener estadísticas");
            Console.WriteLine("3. Salir");
            Console.Write("Elige una opción: ");
            string? opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    await TraceIPAsync(iptracker);
                    break;
                case "2":
                    GetStats(iptracker);
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

    private static async Task TraceIPAsync(IPTracker iptracker)
    {
        Console.Write("Ingresa la IP a rastrear: ");
        string? ipToTrack = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(ipToTrack))
        {
            Console.WriteLine("IP inválida. Inténtalo nuevamente.");
            return;
        }

        await iptracker.TrackIPAsync(ipToTrack);
    }

    private static void GetStats(IPTracker iptracker) 
    {
        iptracker.ShowStats();
    }
}