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
            var photo = await _context.Photos
                .Include(p => p.Author)
                .ThenInclude(a => a.Address)
                .FirstOrDefaultAsync(m => m.PhotoId == photoId);

            return photo;
        }

        public async Task CreatePhotoAsync(PhotoEntity photo)
        {
            _context.Photos.Add(photo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePhotoAsync(PhotoEntity photo)
        {
            _context.Entry(photo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletePhotoAsync(int id)
        {
            var photo = await _context.Photos.FindAsync(id);
            if (photo != null)
            {
                _context.Photos.Remove(photo);
                await _context.SaveChangesAsync();
            }
        }
    }
}
