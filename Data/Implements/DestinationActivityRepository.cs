using Data.Interfaces;
using Entity.Context;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Implements
{
    public class DestinationActivityRepository : IDestinationActivityRepository
    {
        private readonly ApplicationDbContext _context;

        public DestinationActivityRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<DestinationActivity>> GetAllAsync()
        {
            return await _context.DestinationActivity.ToListAsync();
        }

        public async Task<DestinationActivity> GetByIdAsync(int id)
        {
            var destinationActivity = await _context.DestinationActivity.FirstOrDefaultAsync(c => c.Id == id);
            if (destinationActivity == null)
                throw new InvalidOperationException($"No se encontró un DestinationActivity con el id {id}.");
            return destinationActivity;
        }

        public async Task<DestinationActivity> CreateAsync(DestinationActivity destinationActivity)
        {
            _context.DestinationActivity.Add(destinationActivity);
            await _context.SaveChangesAsync();
            return destinationActivity;
        }

        public async Task<DestinationActivity> UpdateAsync(DestinationActivity destinationActivity)
        {
            _context.DestinationActivity.Update(destinationActivity);
            await _context.SaveChangesAsync();
            return destinationActivity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var destinationActivity = await _context.DestinationActivity.FindAsync(id);
            if (destinationActivity == null) return false;
            _context.DestinationActivity.Remove(destinationActivity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}