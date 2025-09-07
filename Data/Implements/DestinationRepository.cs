using Data.Interfaces;
using Entity.Context;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Implements
{
    public class DestinationRepository : IDestinationRepository
    {
        private readonly ApplicationDbContext _context;

        public DestinationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Destination>> GetAllAsync()
        {
            return await _context.Destination.ToListAsync();
        }

        public async Task<Destination> GetByIdAsync(int id)
        {
            var destination = await _context.Destination.FirstOrDefaultAsync(c => c.DestinationId == id);
            if (destination == null)
                throw new InvalidOperationException($"No se encontró un Destination con el id {id}.");
            return destination;
        }

        public async Task<Destination> CreateAsync(Destination destination)
        {
            _context.Destination.Add(destination);
            await _context.SaveChangesAsync();
            return destination;
        }

        public async Task<Destination> UpdateAsync(Destination destination)
        {
            _context.Destination.Update(destination);
            await _context.SaveChangesAsync();
            return destination;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var destination = await _context.Destination.FindAsync(id);
            if (destination == null) return false;
            _context.Destination.Remove(destination);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}