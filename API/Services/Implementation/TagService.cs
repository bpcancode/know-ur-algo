using API.Dtos.Request;
using API.Persistence.Entities;
using API.Services.Interface;
using Microsoft.EntityFrameworkCore;

public class TagService : ITagService
{
	private readonly DbContext _context;

	public TagService(DbContext context)
	{
		_context = context;
	}

	public async Task<Tag> AddTagAsync(TagDto dto)
	{
		var tag = new Tag { Name = dto.Name };
		_context.Set<Tag>().Add(tag);
		await _context.SaveChangesAsync();
		return tag;
	}
}
