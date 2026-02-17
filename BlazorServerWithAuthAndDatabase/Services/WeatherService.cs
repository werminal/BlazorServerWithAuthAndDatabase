using MongoDB.Driver;

namespace BlazorServerWithAuthAndDatabase.Services;

public interface IWeatherService
{
    Task<List<WeatherEntity>> GetWeather(CancellationToken ct = default);
}

public class WeatherService(IMongoCollection<WeatherEntity> weather) : IWeatherService
{
    public async Task<List<WeatherEntity>> GetWeather(CancellationToken ct = default) => 
        await weather.Find(_ => true).ToListAsync(cancellationToken: ct);
}