using MongoDB.Driver;

namespace BlazorServerWithAuthAndDatabase.Services;

public interface IWeatherService
{
    Task<List<WeatherEntity>> GetWeather();
}

public class WeatherService(IMongoCollection<WeatherEntity> weather) : IWeatherService
{
    public async Task<List<WeatherEntity>> GetWeather() => 
        await weather.Find(_ => true).ToListAsync();
}