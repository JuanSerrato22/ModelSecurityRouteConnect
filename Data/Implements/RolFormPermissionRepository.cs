using Data.Interfaces;
using Entity.Context;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Implements
{
    public class RolFormPermissionRepository : IRolFormPermissionRepository
    {
        private readonly ApplicationDbContext _context;

        public RolFormPermissionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<RolFormPermission>> GetAllAsync()
        {
            return await _context.RolFormPermission.ToListAsync();
        }

        public async Task<RolFormPermission> GetByIdAsync(int id)
        {
            var rolFormPermission = await _context.RolFormPermission.FirstOrDefaultAsync(c => c.Id == id);
            if (rolFormPermission == null)
                throw new InvalidOperationException($"No se encontró un RolFormPermission con el id {id}.");
            return rolFormPermission;
        }

        public async Task<RolFormPermission> CreateAsync(RolFormPermission rolFormPermission)
        {
            _context.RolFormPermission.Add(rolFormPermission);
            await _context.SaveChangesAsync();
            return rolFormPermission;
        }

        public async Task<RolFormPermission> UpdateAsync(RolFormPermission rolFormPermission)
        {
            _context.RolFormPermission.Update(rolFormPermission);
            await _context.SaveChangesAsync();
            return rolFormPermission;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var rolFormPermission = await _context.RolFormPermission.FindAsync(id);
            if (rolFormPermission == null) return false;
            _context.RolFormPermission.Remove(rolFormPermission);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}