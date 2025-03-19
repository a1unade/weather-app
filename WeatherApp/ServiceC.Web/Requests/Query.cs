using ServiceC.Web.Contexts;
using ServiceC.Web.Entities;

namespace ServiceC.Web.Requests;

public class Query(ApplicationDbContext context)
{
    public List<WeatherRecord> GetLastWeatherData() =>
        context.WeatherRecords.OrderByDescending(w => w.Id).Take(10).ToList();
}