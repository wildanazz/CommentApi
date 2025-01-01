using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace CommentApi.Models;

public class Comment
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string Name { get; set; } = null!;

    [BsonElement("Comment")]
    [JsonPropertyName("Comment")]
    public string Description { get; set; } = null!;

    [BsonElement("CreatedAt")]
    [JsonPropertyName("CreatedAt")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [BsonElement("UpdatedAt")]
    [JsonPropertyName("UpdatedAt")]
    public DateTime? UpdatedAt { get; set; }
}