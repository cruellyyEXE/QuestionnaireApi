using Newtonsoft.Json;

namespace Domain.Models;

public class BaseModel
{
    [JsonProperty("result")]
    public string? Result { get; set; }
    
    [JsonProperty("value")]
    public int? Value { get; set; }
}