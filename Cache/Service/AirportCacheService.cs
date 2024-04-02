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
        if (!_cache.TryGetValue("Airports", out List<Airport> airports))
        {
            airports = await FetchAirportsFromSource();

            _cache.Set("Airports", airports, TimeSpan.FromMinutes(10)); // Adjust the TTL as needed
        }

        return airports;
    }
    
    private async Task<List<Airport>> FetchAirportsFromSource()
    {
        await Task.Delay(100); 
        return new List<Airport>
        {
            new Airport("LAX", "Los Angeles International Airport"),
            new Airport("JFK", "John F. Kennedy International Airport"),
        };
    }
}