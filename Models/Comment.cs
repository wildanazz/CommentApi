using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace CommentApi.Models;

public class Comment
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string Name { get; set; } = null!;

    [BsonElement("Comment")]
    [JsonPropertyName("Comment")]
    [Required]
    [StringLength(500, ErrorMessage = "Comment cannot be longer than 500 characters.")]
    public string Description { get; set; } = null!;

    [BsonElement("CreatedAt")]
    [JsonPropertyName("CreatedAt")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [BsonElement("UpdatedAt")]
    [JsonPropertyName("UpdatedAt")]
    public DateTime? UpdatedAt { get; set; }
}