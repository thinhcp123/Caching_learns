namespace Cache.Service;

public interface IAirportCacheService
{
    Task<List<Airport>> GetAirportsAsync();
}