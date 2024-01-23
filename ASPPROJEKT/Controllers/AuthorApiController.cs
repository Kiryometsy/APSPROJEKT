using ASPPROJEKT.Models;
using ASPPROJEKT.Services;
using Data;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ASPPROJEKT.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorApiController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly PhotoService _photoService;

        public AuthorApiController(AppDbContext context, PhotoService photoService)
        {
            _context = context;
            _photoService = photoService;
        }

        [HttpGet("paged")]
        public async Task<IActionResult> PagedIndex([FromQuery] string filter, [FromQuery] int page = 1, [FromQuery] int size = 3)
        {
            var result = await _photoService.FindFilteredPage(filter, page, size);
            return Ok(result); // Return the entire result object
        }

        [HttpGet("filtered")]
        public IActionResult GetFiltered(string filter, int page = 1, int size = 3)
        {
            IQueryable<AuthorEntity> query = _context.Authors;

            if (!string.IsNullOrEmpty(filter))
            {
                query = query
                    .Where(a => EF.Functions.Like(a.Name, $"{filter}%"));
            }

            query = query.Include(a => a.Photos);

            var totalAuthors = query.Count();
            var totalPages = (int)Math.Ceiling((double)totalAuthors / size);

            var filteredAuthors = query
                .Skip((page - 1) * size)
                .Take(size)
                .ToList();

            var result = new
            {
                authors = filteredAuthors.Select(author => new
                {
                    author.Name,
                    author.Id,
                    Photos = author.Photos.Select(photo => new
                    {
                        photo.PhotoId,
                        photo.Camera,
                        photo.Description,
                        photo.Resolution,
                        photo.CreatedDate,
                        photo.Format
                    })
                }),
                currentPage = page,
                totalPages = totalPages
            };

            return Ok(result);
        }


    }
}
