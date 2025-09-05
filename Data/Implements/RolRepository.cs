using Data.Interfaces;
using Entity.Context;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Implements
{
    public class RolRepository : IRolRepository
    {
        private readonly ApplicationDbContext _context;

        public RolRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Rol>> GetAllAsync()
        {
            return await _context.Rol.ToListAsync();
        }

        public async Task<Rol> GetByIdAsync(int id)
        {
            var rol = await _context.Rol.FirstOrDefaultAsync(c => c.RolId == id);
            if (rol == null)
                throw new InvalidOperationException($"No se encontró un Rol con el id {id}.");
            return rol;
        }

        public async Task<Rol> CreateAsync(Rol rol)
        {
            _context.Rol.Add(rol);
            await _context.SaveChangesAsync();
            return rol;
        }

        public async Task<Rol> UpdateAsync(Rol rol)
        {
            _context.Rol.Update(rol);
            await _context.SaveChangesAsync();
            return rol;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var rol = await _context.Rol.FindAsync(id);
            if (rol == null) return false;
            _context.Rol.Remove(rol);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}