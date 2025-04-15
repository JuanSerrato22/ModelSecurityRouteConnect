﻿using Microsoft.Extensions.Logging;
using Entity.Model;
using Entity.Context;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    /// <summary>
    /// Repositorio encargado de la gestión de la entidad Usuario en la base de datos.
    /// </summary>
    public class DestinationActivityData
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<DestinationActivity> _logger;

        ///<summary>
        ///Constructor que recibe el contexto de base de datos.
        ///</summary>
        ///<param name="=context">Instancia de <see cref="ApplicationDbContext"/> para la conexión con la base de datos.</param>
        public DestinationActivityData(ApplicationDbContext context, ILogger<DestinationActivity> logger)
        {
            _context = context;
            _logger = logger;
        }

        ///<summary>
        ///Obtiene todos los destino actividad almacenados en la base de datos.
        ///</summary>
        ///<returns>Lista de destino actividad.</returns>
        public async Task<IEnumerable<DestinationActivity>> GetAllAsync()
        {
            return await _context.Set<DestinationActivity>().ToListAsync();
        }

        public async Task<DestinationActivity?> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Set<DestinationActivity>().FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener usuario con ID {UserId}", id);
                throw; //Re-lanza la excepción para que sea manejada en capas superiores
            }
        }

        ///<summary>
        ///Crea un nuevo rol en la base de datos.
        ///</summary>
        ///<param name="destinationActivity">Instancia del rol a crear.</param>
        ///<returns>El rol creado.</returns>
        public async Task<DestinationActivity> CreateAsync(DestinationActivity destinationActivity)
        {
            try
            {
                await _context.Set<DestinationActivity>().AddAsync(destinationActivity);
                await _context.SaveChangesAsync();
                return destinationActivity;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear el destino actividad: {ex.Message}");
                throw;
            }
        }

        ///<summary>
        ///Actualiza un rol existente en la base de datos.
        ///</summary>
        ///<param name="destinationActivity">Objeto con la información actualizada.</param>
        ///<returns>True si la operación fue exitosa, False en caso contrario.</returns>
        public async Task<bool> UpdateAsync(DestinationActivity destinationActivity)
        {
            try
            {
                _context.Set<DestinationActivity>().Update(destinationActivity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar el destino actividad: {ex.Message}");
                return false;
            }
        }

        ///<summary>
        ///Elimina un rol de la base de datos.
        ///</summary>
        ///<param name="id">Identificador único del rol a eliminar.</param>
        ///<returns>True si la operación fue exitosa, False en caso contrario.</returns>
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var destinationActivity = await _context.Set<DestinationActivity>().FindAsync(id);
                if (destinationActivity == null)
                    return false;

                _context.Set<DestinationActivity>().Remove(destinationActivity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar el destino actividad: {ex.Message}");
                return false;
            }
        }
    }
}