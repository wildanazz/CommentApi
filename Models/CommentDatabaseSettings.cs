namespace CommentApi.Models;

public class CommentDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string CommentsCollectionName { get; set; } = null!;
}
