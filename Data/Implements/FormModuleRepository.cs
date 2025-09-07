using Data.Interfaces;
using Entity.Context;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Implements
{
    public class FormModuleRepository : IFormModuleRepository
    {
        private readonly ApplicationDbContext _context;

        public FormModuleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<FormModule>> GetAllAsync()
        {
            return await _context.FormModule.ToListAsync();
        }

        public async Task<FormModule> GetByIdAsync(int id)
        {
            var formModule = await _context.FormModule.FirstOrDefaultAsync(c => c.FormModuleId == id);
            if (formModule == null)
                throw new InvalidOperationException($"No se encontró un FormModule con el id {id}.");
            return formModule;
        }

        public async Task<FormModule> CreateAsync(FormModule formModule)
        {
            _context.FormModule.Add(formModule);
            await _context.SaveChangesAsync();
            return formModule;
        }

        public async Task<FormModule> UpdateAsync(FormModule formModule)
        {
            _context.FormModule.Update(formModule);
            await _context.SaveChangesAsync();
            return formModule;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var formModule = await _context.FormModule.FindAsync(id);
            if (formModule == null) return false;
            _context.FormModule.Remove(formModule);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}