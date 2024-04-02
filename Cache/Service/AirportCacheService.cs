using Microsoft.Extensions.Caching.Memory;

namespace Cache.Service;

public class AirportCacheService:IAirportCacheService
{
    private readonly IMemoryCache _cache;

    public AirportCacheService(IMemoryCache cache)
    {
        _cache = cache;
    }

    public async Task<List<Airport>> GetAirportsAsync()
    {
        Random random = new Random();
                int randomNumber = random.Next(10);
        if (!_cache.TryGetValue("Airports", out List<Airport> airports))
        {
            airports = await FetchAirportsFromSource();

            _cache.Set("Airports", airports, TimeSpan.FromMinutes(randomNumber)); // Adjust the TTL as needed
        }

        return airports;
    }
    
    private async Task<List<Airport>> FetchAirportsFromSource()
    {
        return new List<Airport>
        {
            new Airport("LAX", "Los Angeles International Airport"),
            new Airport("JFK", "John F. Kennedy International Airport"),
        };
    }
}