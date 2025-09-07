using Data.Interfaces;
using Entity.Context;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Implements
{
    public class ModuleRepository : IModuleRepository
    {
        private readonly ApplicationDbContext _context;

        public ModuleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Module>> GetAllAsync()
        {
            return await _context.Module.ToListAsync();
        }

        public async Task<Module> GetByIdAsync(int id)
        {
            var module = await _context.Module.FirstOrDefaultAsync(c => c.ModuleId == id);
            if (module == null)
                throw new InvalidOperationException($"No se encontró un Module con el id {id}.");
            return module;
        }

        public async Task<Module> CreateAsync(Module module)
        {
            _context.Module.Add(module);
            await _context.SaveChangesAsync();
            return module;
        }

        public async Task<Module> UpdateAsync(Module module)
        {
            _context.Module.Update(module);
            await _context.SaveChangesAsync();
            return module;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var module = await _context.Module.FindAsync(id);
            if (module == null) return false;
            _context.Module.Remove(module);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}