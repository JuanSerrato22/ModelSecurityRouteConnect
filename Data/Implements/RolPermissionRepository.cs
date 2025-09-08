using Data.Interfaces;
using Entity.Context;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Implements
{
    public class RolPermissionRepository : IRolPermissionRepository
    {
        private readonly ApplicationDbContext _context;

        public RolPermissionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<RolPermission>> GetAllAsync()
        {
            return await _context.RolPermission.ToListAsync();
        }

        public async Task<RolPermission> GetByIdAsync(int id)
        {
            var rolPermission = await _context.RolPermission.FirstOrDefaultAsync(c => c.Id == id);
            if (rolPermission == null)
                throw new InvalidOperationException($"No se encontró un RolPermission con el id {id}.");
            return rolPermission;
        }

        public async Task<RolPermission> CreateAsync(RolPermission rolPermission)
        {
            _context.RolPermission.Add(rolPermission);
            await _context.SaveChangesAsync();
            return rolPermission;
        }

        public async Task<RolPermission> UpdateAsync(RolPermission rolPermission)
        {
            _context.RolPermission.Update(rolPermission);
            await _context.SaveChangesAsync();
            return rolPermission;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var rolPermission = await _context.RolPermission.FindAsync(id);
            if (rolPermission == null) return false;
            _context.RolPermission.Remove(rolPermission);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}