namespace Tracker.Models
{
    public class Stat
    {
        public Stat(string? countryName, double distance)
        {
            Country = countryName;
            Distance = distance;
            Times = 1;
        }

        public String Country { get; set; }
        public double Distance { get; set; }
        public int Times { get; set; }
    }
}