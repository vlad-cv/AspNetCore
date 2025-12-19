namespace ConfigurationExample.Options
{
    public class WeatherApiOptions
    {
        // The properties must match the keys in the configuration section
        public Guid ClientId { get; set; }
        public Guid ClientSecret { get; set; }
    }
}
