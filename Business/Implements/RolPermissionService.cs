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
    public class RolPermissionService : IRolPermissionService
    {
        private readonly IRolPermissionRepository _rolPermissionRepository;
        private readonly IMapper _mapper;

        public RolPermissionService(IRolPermissionRepository rolPermissionRepository, IMapper mapper)
        {
            _rolPermissionRepository = rolPermissionRepository;
            _mapper = mapper;
        }

        public async Task<List<RolPermissionDTO>> GetAllAsync()
        {
            var rolPermission = await _rolPermissionRepository.GetAllAsync();
            return _mapper.Map<List<RolPermissionDTO>>(rolPermission);
        }

        public async Task<RolPermissionDTO> GetByIdAsync(int id)
        {
            var rolPermission = await _rolPermissionRepository.GetByIdAsync(id);
            return _mapper.Map<RolPermissionDTO>(rolPermission);
        }

        public async Task<RolPermissionDTO> CreateAsync(RolPermissionDTO rolPermissionDto)
        {
            var rolPermission = _mapper.Map<RolPermission>(rolPermissionDto);
            var rolPermissionCreado = await _rolPermissionRepository.CreateAsync(rolPermission);
            return _mapper.Map<RolPermissionDTO>(rolPermissionCreado);
        }

        public async Task<RolPermissionDTO> UpdateAsync(int id, RolPermissionDTO rolPermissionDto)
        {
            var rolPermission = await _rolPermissionRepository.GetByIdAsync(id);
            if (rolPermission == null) return null!; // Devuelve null forzando la nulabilidad, pero cumple la firma

            rolPermission.Name = rolPermissionDto.Name;

            var actualizado = await _rolPermissionRepository.UpdateAsync(rolPermission);
            return _mapper.Map<RolPermissionDTO>(actualizado);
        }

        public async Task<RolPermissionDTO> UpdatePartialAsync(int id, JsonPatchDocument<RolPermissionDTO> patchDoc)
        {
            var rolPermission = await _rolPermissionRepository.GetByIdAsync(id);
            if (rolPermission == null) return null!;

            var rolPermissionDto = _mapper.Map<RolPermissionDTO>(rolPermission);
            patchDoc.ApplyTo(rolPermissionDto);

            // Mapea de nuevo a la entidad y actualiza
            _mapper.Map(rolPermissionDto, rolPermission);
            var updated = await _rolPermissionRepository.UpdateAsync(rolPermission);
            return _mapper.Map<RolPermissionDTO>(updated);
        }

        public async Task<bool> SoftDeleteAsync(int id)
        {
            var rolPermission = await _rolPermissionRepository.GetByIdAsync(id);
            if (rolPermission == null) return false;

            if (rolPermission.Active)
            {
                rolPermission.Active = false;
                rolPermission.DeleteAt = DateTime.Now;
            }
            else
            {
                rolPermission.Active = true;
                rolPermission.DeleteAt = null;
            }

            await _rolPermissionRepository.UpdateAsync(rolPermission);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _rolPermissionRepository.DeleteAsync(id);
        }
    }
}