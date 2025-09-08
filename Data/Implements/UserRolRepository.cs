using Data.Interfaces;
using Entity.Context;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Implements
{
    public class UserRolRepository : IUserRolRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRolRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserRol>> GetAllAsync()
        {
            return await _context.UserRol.ToListAsync();
        }

        public async Task<UserRol> GetByIdAsync(int id)
        {
            var userRol = await _context.UserRol.FirstOrDefaultAsync(c => c.Id == id);
            if (userRol == null)
                throw new InvalidOperationException($"No se encontró un Rol Usuario con el id {id}.");
            return userRol;
        }

        public async Task<UserRol> CreateAsync(UserRol userRol)
        {
            _context.UserRol.Add(userRol);
            await _context.SaveChangesAsync();
            return userRol;
        }

        public async Task<UserRol> UpdateAsync(UserRol userRol)
        {
            _context.UserRol.Update(userRol);
            await _context.SaveChangesAsync();
            return userRol;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var userRol = await _context.UserRol.FindAsync(id);
            if (userRol == null) return false;
            _context.UserRol.Remove(userRol);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}