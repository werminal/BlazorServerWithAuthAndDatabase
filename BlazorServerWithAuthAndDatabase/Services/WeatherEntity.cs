using MongoDB.Bson;

namespace BlazorServerWithAuthAndDatabase.Services;

public class WeatherEntity
{
    public ObjectId Id { get; set; }
    public string Summary { get; set; } = null!;
    public DateTime Date { get; set; }
    public int TemperatureC { get; set; }
}