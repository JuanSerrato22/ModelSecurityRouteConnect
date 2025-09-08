using Data.Interfaces;
using Entity.Context;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Implements
{
    public class UserActivityRepository : IUserActivityRepository
    {
        private readonly ApplicationDbContext _context;

        public UserActivityRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserActivity>> GetAllAsync()
        {
            return await _context.UserActivity.ToListAsync();
        }

        public async Task<UserActivity> GetByIdAsync(int id)
        {
            var userActivity = await _context.UserActivity.FirstOrDefaultAsync(c => c.Id == id);
            if (userActivity == null)
                throw new InvalidOperationException($"No se encontró un UserActivity con el id {id}.");
            return userActivity;
        }

        public async Task<UserActivity> CreateAsync(UserActivity userActivity)
        {
            _context.UserActivity.Add(userActivity);
            await _context.SaveChangesAsync();
            return userActivity;
        }

        public async Task<UserActivity> UpdateAsync(UserActivity userActivity)
        {
            _context.UserActivity.Update(userActivity);
            await _context.SaveChangesAsync();
            return userActivity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var userActivity = await _context.UserActivity.FindAsync(id);
            if (userActivity == null) return false;
            _context.UserActivity.Remove(userActivity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}