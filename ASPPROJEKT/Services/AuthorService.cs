using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Data.Entities;
using Data;

namespace ASPPROJEKT.Services
{
    public class AuthorService
    {
        private readonly AppDbContext _context;

        public AuthorService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<AuthorEntity>> GetAllAuthorsAsync()
        {
            return await _context.Authors
                .Include(a => a.Address)
                .ToListAsync();
        }

        public async Task<AuthorEntity?> GetAuthorDetailsAsync(int AuthorId)
        {
            var author = await _context.Authors
                .Include(a => a.Address)
                .FirstOrDefaultAsync(m => m.Id == AuthorId);  

            return author;
        }

        public async Task<List<AddressEntity>> FindAllAddressForViewModel()
        {
            return await _context.Address.ToListAsync();
        }

        public async Task CreateAuthorAsync(AuthorEntity author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAuthorAsync(AuthorEntity author)
        {
            _context.Update(author).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAuthorAsync(int id)
        {
            AuthorEntity? find = await _context.Authors.FindAsync(id);

            if (find != null)
            {
                _context.Authors.Remove(find);
                await _context.SaveChangesAsync();
            }
        }
    }
}
