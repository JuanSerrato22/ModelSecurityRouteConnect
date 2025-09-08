using Data.Interfaces;
using Entity.Context;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Implements
{
    public class FormRepository : IFormRepository
    {
        private readonly ApplicationDbContext _context;

        public FormRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Form>> GetAllAsync()
        {
            return await _context.Form.ToListAsync();
        }

        public async Task<Form> GetByIdAsync(int id)
        {
            var form = await _context.Form.FirstOrDefaultAsync(c => c.Id == id);
            if (form == null)
                throw new InvalidOperationException($"No se encontró un Formulario con el id {id}.");
            return form;
        }

        public async Task<Form> CreateAsync(Form form)
        {
            _context.Form.Add(form);
            await _context.SaveChangesAsync();
            return form;
        }

        public async Task<Form> UpdateAsync(Form form)
        {
            _context.Form.Update(form);
            await _context.SaveChangesAsync();
            return form;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var form = await _context.Form.FindAsync(id);
            if (form == null) return false;
            _context.Form.Remove(form);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}