using Newtonsoft.Json;

namespace Domain.Models.Request;

public class SaveResult
{
    [JsonProperty("username")]
    public string? Username { get; set; }
    
    [JsonProperty("questionId")]
    public int? QuestionId { get; set; }
    
    [JsonProperty("answerId")]
    public int? AnswerId { get; set; }
}