using ServiceC.Web.Entities;

namespace ServiceC.Web.Types;

public class WeatherRecordType : ObjectType<WeatherRecord>
{
    protected override void Configure(IObjectTypeDescriptor<WeatherRecord> descriptor)
    {
        descriptor.Field(x => x.TemperatureC).Name("temperatureC");
        descriptor.Field(x => x.WindSpeed).Name("windSpeed");
        descriptor.Field(x => x.Humidity).Name("humidity");
        descriptor.Field(x => x.Pressure).Name("pressure");
        descriptor.Field(x => x.DewPoint).Name("dewPoint");
    }
}
