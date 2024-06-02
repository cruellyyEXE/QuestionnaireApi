using Newtonsoft.Json;

namespace Domain.Models;

public class GetSurveys
{
    [JsonProperty("list")]
    public List<SurveyModel>? List { get; set; }
}

public class SurveyModel
{
    [JsonProperty("id")]
    public int? Id { get; set; }
    
    [JsonProperty("name")]
    public string? Name { get; set; }
    
    [JsonProperty("content")]
    public string? Content { get; set; }
}