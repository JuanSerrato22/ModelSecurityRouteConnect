using Data.Interfaces;
using Entity.Context;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Implements
{
    public class ChangeLogRepository : IChangeLogRepository
    {
        private readonly ApplicationDbContext _context;

        public ChangeLogRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ChangeLog>> GetAllAsync()
        {
            return await _context.ChangeLog.ToListAsync();
        }

        public async Task<ChangeLog> GetByIdAsync(int id)
        {
            var changelog = await _context.ChangeLog.FirstOrDefaultAsync(c => c.ChangeLogId == id);
            if (changelog == null)
                throw new InvalidOperationException($"No se encontró un ChangeLog con el id {id}.");
            return changelog;
        }

        public async Task<ChangeLog> CreateAsync(ChangeLog changelog)
        {
            _context.ChangeLog.Add(changelog);
            await _context.SaveChangesAsync();
            return changelog;
        }

        public async Task<ChangeLog> UpdateAsync(ChangeLog changelog)
        {
            _context.ChangeLog.Update(changelog);
            await _context.SaveChangesAsync();
            return changelog;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var changelog = await _context.ChangeLog.FindAsync(id);
            if (changelog == null) return false;
            _context.ChangeLog.Remove(changelog);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}