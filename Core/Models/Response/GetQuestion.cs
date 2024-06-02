using Newtonsoft.Json;

namespace Domain.Models;

public class GetQuestion
{
    [JsonProperty("id")]
    public int? Id { get; set; }
    
    [JsonProperty("content")]
    public string? Content { get; set; }
    
    [JsonProperty("answers")]
    public List<AnswerModel>? Answers { get; set; }
}

public class AnswerModel
{
    [JsonProperty("id")]
    public int? Id { get; set; }
    
    [JsonProperty("content")]
    public string? Content { get; set; }
}