using Data.Interfaces;
using Entity.Context;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Implements
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly ApplicationDbContext _context;

        public PermissionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Permission>> GetAllAsync()
        {
            return await _context.Permission.ToListAsync();
        }

        public async Task<Permission> GetByIdAsync(int id)
        {
            var permission = await _context.Permission.FirstOrDefaultAsync(c => c.PermissionId == id);
            if (permission == null)
                throw new InvalidOperationException($"No se encontró un Permission con el id {id}.");
            return permission;
        }

        public async Task<Permission> CreateAsync(Permission permission)
        {
            _context.Permission.Add(permission);
            await _context.SaveChangesAsync();
            return permission;
        }

        public async Task<Permission> UpdateAsync(Permission permission)
        {
            _context.Permission.Update(permission);
            await _context.SaveChangesAsync();
            return permission;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var permission = await _context.Permission.FindAsync(id);
            if (permission == null) return false;
            _context.Permission.Remove(permission);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}