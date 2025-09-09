using AutoMapper;
using Business.Interfaces;
using Data.Implements;
using Data.Interfaces;
using Entity.DTO;
using Entity.Model;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Implements
{
    public class RolService : IRolService
    {
        private readonly IRolRepository _rolRepository;
        private readonly IMapper _mapper;

        public RolService(IRolRepository rolRepository, IMapper mapper)
        {
            _rolRepository = rolRepository;
            _mapper = mapper;
        }

        public async Task<List<RolDTO>> GetAllAsync()
        {
            var rol = await _rolRepository.GetAllAsync();
            return _mapper.Map<List<RolDTO>>(rol);
        }

        public async Task<RolDTO> GetByIdAsync(int id)
        {
            var rol = await _rolRepository.GetByIdAsync(id);
            return _mapper.Map<RolDTO>(rol);
        }

        public async Task<RolDTO> CreateAsync(RolDTO rolDto)
        {
            var rol = _mapper.Map<Rol>(rolDto);
            var rolCreado = await _rolRepository.CreateAsync(rol);
            return _mapper.Map<RolDTO>(rolCreado);
        }

        public async Task<RolDTO> UpdateAsync(int id, RolDTO rolDto)
        {
            var rol = await _rolRepository.GetByIdAsync(id);
            if (rol == null) return null!; // Devuelve null forzando la nulabilidad, pero cumple la firma

            rol.RolName = rolDto.RolName;
            rol.Description = rolDto.Description;

            var actualizado = await _rolRepository.UpdateAsync(rol);
            return _mapper.Map<RolDTO>(actualizado);
        }

        public async Task<RolDTO> UpdatePartialAsync(int id, JsonPatchDocument<RolDTO> patchDoc)
        {
            var rol = await _rolRepository.GetByIdAsync(id);
            if (rol == null) return null!;

            var rolDto = _mapper.Map<RolDTO>(rol);
            patchDoc.ApplyTo(rolDto);

            // Mapea de nuevo a la entidad y actualiza
            _mapper.Map(rolDto, rol);
            var updated = await _rolRepository.UpdateAsync(rol);
            return _mapper.Map<RolDTO>(updated);
        }

        public async Task<bool> SoftDeleteAsync(int id)
        {
            var rol = await _rolRepository.GetByIdAsync(id);
            if (rol == null) return false;

            if (rol.Active)
            {
                rol.Active = false;
                rol.DeleteAt = DateTime.Now;
            }
            else
            {
                rol.Active = true;
                rol.DeleteAt = null;
            }

            await _rolRepository.UpdateAsync(rol);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _rolRepository.DeleteAsync(id);
        }
    }
}