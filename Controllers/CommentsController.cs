using CommentApi.Models;
using CommentApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CommentApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommentsController : ControllerBase
{
    private readonly CommentsService _commentsService;

    public CommentsController(CommentsService commentsService) => _commentsService = commentsService;

    [HttpGet]
    public async Task<List<Comment>> Get() => await _commentsService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Comment>> Get(string id)
    {
        var comment = await _commentsService.GetAsync(id);

        if (comment is null)
        {
            return NotFound();
        }

        return comment;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Comment newComment)
    {
        newComment.CreatedAt = DateTime.UtcNow;

        await _commentsService.CreateAsync(newComment);

        return CreatedAtAction(nameof(Get), new { id = newComment.Id }, newComment);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Comment updatedComment)
    {
        var comment = await _commentsService.GetAsync(id);

        if (comment is null)
        {
            return NotFound();
        }

        updatedComment.Id = comment.Id;

        updatedComment.UpdatedAt = DateTime.UtcNow;

        await _commentsService.UpdateAsync(id, updatedComment);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var comment = await _commentsService.GetAsync(id);

        if (comment is null)
        {
            return NotFound();
        }

        await _commentsService.RemoveAsync(id);

        return NoContent();
    }
}