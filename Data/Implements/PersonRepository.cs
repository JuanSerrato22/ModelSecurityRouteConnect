using Data.Interfaces;
using Entity.Context;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Implements
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ApplicationDbContext _context;

        public PersonRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Person>> GetAllAsync()
        {
            return await _context.Person.ToListAsync();
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            var person = await _context.Person.FirstOrDefaultAsync(c => c.PersonId == id);
            if (person == null)
                throw new InvalidOperationException($"No se encontró un Person con el id {id}.");
            return person;
        }

        public async Task<Person> CreateAsync(Person person)
        {
            _context.Person.Add(person);
            await _context.SaveChangesAsync();
            return person;
        }

        public async Task<Person> UpdateAsync(Person person)
        {
            _context.Person.Update(person);
            await _context.SaveChangesAsync();
            return person;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var person = await _context.Person.FindAsync(id);
            if (person == null) return false;
            _context.Person.Remove(person);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}