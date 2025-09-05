using Data.Interfaces;
using Entity.Context;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Implements
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly ApplicationDbContext _context;

        public ActivityRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Activity>> GetAllAsync()
        {
            return await _context.Activity.ToListAsync();
        }

        public async Task<Activity> GetByIdAsync(int id)
        {
            var activity = await _context.Activity.FirstOrDefaultAsync(c => c.ActivityId == id);
            if (activity == null)
                throw new InvalidOperationException($"No se encontró un Activity con el id {id}.");
            return activity;
        }

        public async Task<Activity> CreateAsync(Activity activity)
        {
            _context.Activity.Add(activity);
            await _context.SaveChangesAsync();
            return activity;
        }

        public async Task<Activity> UpdateAsync(Activity activity)
        {
            _context.Activity.Update(activity);
            await _context.SaveChangesAsync();
            return activity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var activity = await _context.Activity.FindAsync(id);
            if (activity == null) return false;
            _context.Activity.Remove(activity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}