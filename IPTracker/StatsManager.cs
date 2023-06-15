using Tracker.Models;

namespace Tracker
{
    public class StatsManager
    {
        public List<Stat> Stats { get; set; }

        public StatsManager() { Stats = new List<Stat>(); }

        public void SaveStat(string? countryName, double distance)
        {
            var index = Stats.FindIndex(x => x.Country.Equals(countryName, StringComparison.InvariantCultureIgnoreCase));
            if (index >= 0) 
            {
                Stats[index].Times++;
            }
            else
            {
                Stats.Add(new Stat(countryName, distance));
            }
        }

        public double FarestDistance()
        {
            if (Stats.Any())
            {
                return Stats.Max(x => x.Distance);
            }
            else { return 0; }
        }

        public double ClosestDistanceToBuenosAires()
        {
            if (Stats.Any())
            {
                return Stats.Min(x => x.Distance);
            }
            else { return 0; }
        }

        public double AverageDistance()
        {
            if (Stats.Any())
            {
                double sum = 0;
                foreach (var stat in Stats)
                {
                    sum += (stat.Distance * stat.Times);
                }

                return sum / Stats.Sum(x => x.Times);
            }
            else { return 0; }
        }
    }
}
