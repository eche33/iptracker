using System;
using System.Net.Http;
using System.Threading.Tasks;
using Tracker.Util;
using Newtonsoft.Json;

namespace Tracker
{
    public class IPTracker
{
    private const double  ARG_LATITUDE = -34.61050033569336;
    private const double  ARG_LONGITUDE = -58.39759826660156;

    public IPTracker()
    {

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

                    Console.WriteLine(responseContent);
                                        
                    Console.WriteLine($"País: {ipDetails.Country_Name}");
                    Console.WriteLine($"ISO Code: {ipDetails.Country_Code}");

                    Console.WriteLine($"Idiomas:");
                    foreach (var language in ipDetails.Location?.Languages)
                    {
                        Console.WriteLine($"{language.Name}");
                    }

                    Console.WriteLine($"Moneda: {ipDetails.Currency?.Name}");
                    Console.WriteLine($"Hora actual: {ipDetails.TimeZone?.Current_Time}");
                    Console.WriteLine($"Distancia: {DistanceCalculator.CalculateDistanceToArgentina(new Util.Location(ipDetails.Latitude, ipDetails.Longitude))} kms");

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
}
}