using System.Text.Json;

namespace Common.Middlewares.Models
{
    public class DataWrapperController
    {
        public object? values { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
