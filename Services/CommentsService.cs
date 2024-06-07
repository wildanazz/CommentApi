using CommentApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CommentApi.Services;

public class CommentsService
{
    private readonly IMongoCollection<Comment> _commentsCollection;

    public CommentsService(IOptions<CommentDatabaseSettings> CommentDatabaseSettings)
    {
        var mongoClient = new MongoClient(CommentDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(CommentDatabaseSettings.Value.DatabaseName);

        _commentsCollection = mongoDatabase.GetCollection<Comment>(CommentDatabaseSettings.Value.CommentsCollectionName);
    }

    public async Task<List<Comment>> GetAsync() => await _commentsCollection.Find(_ => true).ToListAsync();

    public async Task<Comment?> GetAsync(string id) => await _commentsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Comment newComment) => await _commentsCollection.InsertOneAsync(newComment);

    public async Task UpdateAsync(string id, Comment updatedComment) => await _commentsCollection.ReplaceOneAsync(x => x.Id == id, updatedComment);

    public async Task RemoveAsync(string id) => await _commentsCollection.DeleteOneAsync(x => x.Id == id);
}