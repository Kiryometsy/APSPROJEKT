using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Data.Entities;
using Data;
using ASPPROJEKT.Models;

namespace ASPPROJEKT.Services
{
    public class PhotoService
    {
        private readonly AppDbContext _context;

        public PhotoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PagingList<PhotoEntity>> FindPage(int page, int size)
        {
            return PagingList<PhotoEntity>.Create( 
                    (p, s) => _context.Photos
                            .Include(a => a.Author)
                            .OrderByDescending(photo => photo.CreatedDate)
                            .Skip((p - 1) * size)
                            .Take(s)
                            .ToList(),
                    _context.Photos.Count(),
                    page,
                    size);
        }

        public async Task<PagingList<PhotoEntity>> FindFilteredPage(string filter, int page, int size)
        {
            // Start with the base query without filtering
            IQueryable<PhotoEntity> baseQuery = _context.Photos
                .Include(photo => photo.Author)
                .OrderByDescending(photo => photo.CreatedDate);

            // Apply filter if provided
            if (!string.IsNullOrEmpty(filter))
            {
                baseQuery = baseQuery
                    .Where(photo => photo.Description.Contains(filter) || photo.Author.Name.Contains(filter));
            }

            // Explicitly convert the result to IOrderedQueryable<Data.Entities.PhotoEntity>
            IOrderedQueryable<PhotoEntity> orderedQuery = baseQuery as IOrderedQueryable<PhotoEntity>;

            // Calculate total count for pagination
            var totalPhotos = await baseQuery.CountAsync();

            // Apply pagination
            var photos = await orderedQuery
                .Skip((page - 1) * size)
                .Take(size)
                .ToListAsync();

            // Change this line to use a lambda expression that matches the required Func signature
            return PagingList<PhotoEntity>.Create((p, s) => photos, totalPhotos, page, size);
        }
        public async Task<List<PhotoEntity>> GetAllPhotosAsync()
        {
            return await _context.Photos
                .Include(p => p.Author)
                .ThenInclude(a => a.Address)
                .ToListAsync();
        }

        public virtual async Task<PhotoEntity?> GetPhotoDetailsAsync(int photoId)
        {
            //var photo =await _context.Photos.FindAsync(photoId);
            //photo.Author = await _context.Authors.FindAsync(photo.AuthorId);
            var photo = await _context.Photos
                .Include(p => p.Author)
                .ThenInclude(a => a.Address)
                .FirstOrDefaultAsync(m => m.PhotoId == photoId);

            return photo;
        }
        public async Task<List<AuthorEntity>> FindAllAuthorsForViewModel()
        {
            return await _context.Authors.ToListAsync();
        }
        public async Task CreatePhotoAsync(PhotoEntity photo)
        {
            _context.Photos.Add(photo);
            await _context.SaveChangesAsync();
        }

        public async Task<PhotoEntity> FindById(int id)
        {
            var model = await _context.Photos.FindAsync(id);
            model.Author = await _context.Authors.FindAsync(model.AuthorId);
            return model;
        }
        public async Task UpdatePhotoAsync(PhotoEntity photo)
        {
            _context.Entry(photo).Reference(p => p.Author).Load();

            _context.Update(photo).State = EntityState.Modified;
            //_context.Photos.Update(photo);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePhotoAsync(int id)
        {
            PhotoEntity? find =await _context.Photos.FindAsync(id);

            if (find != null)
            {
                _context.Photos.Remove(find);
                await _context.SaveChangesAsync();
            }
        }
    }
}
