using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Entities;
using Data;
using Microsoft.EntityFrameworkCore;

namespace ASPPROJEKT.Services
{
    public class AddressService
    {
        private readonly AppDbContext _context;

        public AddressService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<AddressEntity>> GetAllAddressAsync()
        {
            return await _context.Address
                .ToListAsync();
        }

        public async Task<AddressEntity?> GetAddressDetailsAsync(int AddressId)
        {
            var address = await _context.Address
                .FirstOrDefaultAsync(m => m.Id == AddressId);

            return address;
        }

        public async Task CreateAddressAsync(AddressEntity address)
        {
            _context.Address.Add(address);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAddressAsync(AddressEntity address)
        {
            _context.Update(address).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAddressAsync(int id)
        {
            AddressEntity? find = await _context.Address.FindAsync(id);

            if (find != null)
            {
                _context.Address.Remove(find);
                await _context.SaveChangesAsync();
            }
        }
    }
}