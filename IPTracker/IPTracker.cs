using Newtonsoft.Json;
using Tracker.Util;

namespace Tracker
{
    public class IPTracker
    {
        public StatsManager ManagerStats { get; set; }
        public IPTracker()
        {
            ManagerStats = new StatsManager();
        }

        public async Task TrackIPAsync(string ipToTrack)
        {
            Console.WriteLine($"Rastreando IP: {ipToTrack}");

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string apiUrl = $"http://api.ipapi.com/api/{ipToTrack}?access_key=b0c69700324abd6628304595bd400faa";

                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        IPApiResponse? ipDetails = JsonConvert.DeserializeObject<IPApiResponse>(responseContent);

                        var countryName = ipDetails.Country_Name;
                        var distance = DistanceCalculator.CalculateDistanceToArgentina(new Util.Location(ipDetails.Latitude, ipDetails.Longitude));

                        Console.WriteLine($"País: {countryName}");
                        Console.WriteLine($"ISO Code: {ipDetails.Country_Code}");

                        var languagesNames = ipDetails.Location?.Languages.ConvertAll(l => l.Name);
                        Console.WriteLine($"Idiomas: {String.Join(", ", languagesNames.ToArray())}");

                        Console.WriteLine($"Moneda: {ipDetails.Currency?.Name}");
                        Console.WriteLine($"Hora actual: {ipDetails.TimeZone?.Current_Time}");
                        Console.WriteLine($"Distancia: {distance} kms");

                        ManagerStats.SaveStat(countryName, distance);
                    }
                    else
                    {
                        Console.WriteLine($"Request failed with status code {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }

        public void ShowStats()
        {
            Console.WriteLine($"Distancia más lejana a Buenos Aires: {ManagerStats.FarestDistance()} kms");
            Console.WriteLine($"Distancia más cercana a Buenos Aires: {ManagerStats.ClosestDistanceToBuenosAires()} kms");
            Console.WriteLine("Distancia promedio:");
        }
    }
}