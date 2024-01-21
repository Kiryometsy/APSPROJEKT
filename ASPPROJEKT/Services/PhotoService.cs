using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Data.Entities;
using Data;

namespace ASPPROJEKT.Services
{
    public class PhotoService
    {
        private readonly AppDbContext _context;

        public PhotoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<PhotoEntity>> GetAllPhotosAsync()
        {
            return await _context.Photos
                .Include(p => p.Author)
                .ThenInclude(a => a.Address)
                .ToListAsync();
        }

        public async Task<PhotoEntity?> GetPhotoDetailsAsync(int photoId)
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
