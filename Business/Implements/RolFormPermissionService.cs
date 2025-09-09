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
    public class RolFormPermissionService : IRolFormPermissionService
    {
        private readonly IRolFormPermissionRepository _rolFormPermissionRepository;
        private readonly IMapper _mapper;

        public RolFormPermissionService(IRolFormPermissionRepository rolFormPermissionRepository, IMapper mapper)
        {
            _rolFormPermissionRepository = rolFormPermissionRepository;
            _mapper = mapper;
        }

        public async Task<List<RolFormPermissionDTO>> GetAllAsync()
        {
            var rolFormPermission = await _rolFormPermissionRepository.GetAllAsync();
            return _mapper.Map<List<RolFormPermissionDTO>>(rolFormPermission);
        }

        public async Task<RolFormPermissionDTO> GetByIdAsync(int id)
        {
            var rolFormPermission = await _rolFormPermissionRepository.GetByIdAsync(id);
            return _mapper.Map<RolFormPermissionDTO>(rolFormPermission);
        }

        public async Task<RolFormPermissionDTO> CreateAsync(RolFormPermissionDTO rolFormPermissionDto)
        {
            var rolFormPermission = _mapper.Map<RolFormPermission>(rolFormPermissionDto);
            var rolFormPermissionCreado = await _rolFormPermissionRepository.CreateAsync(rolFormPermission);
            return _mapper.Map<RolFormPermissionDTO>(rolFormPermissionCreado);
        }

        public async Task<RolFormPermissionDTO> UpdateAsync(int id, RolFormPermissionDTO rolFormPermissionDto)
        {
            var rolFormPermission = await _rolFormPermissionRepository.GetByIdAsync(id);
            if (rolFormPermission == null) return null!; // Devuelve null forzando la nulabilidad, pero cumple la firma

            rolFormPermission.Name = rolFormPermissionDto.Name;

            var actualizado = await _rolFormPermissionRepository.UpdateAsync(rolFormPermission);
            return _mapper.Map<RolFormPermissionDTO>(actualizado);
        }

        public async Task<RolFormPermissionDTO> UpdatePartialAsync(int id, JsonPatchDocument<RolFormPermissionDTO> patchDoc)
        {
            var rolFormPermission = await _rolFormPermissionRepository.GetByIdAsync(id);
            if (rolFormPermission == null) return null!;

            var rolFormPermissionDto = _mapper.Map<RolFormPermissionDTO>(rolFormPermission);
            patchDoc.ApplyTo(rolFormPermissionDto);

            // Mapea de nuevo a la entidad y actualiza
            _mapper.Map(rolFormPermissionDto, rolFormPermission);
            var updated = await _rolFormPermissionRepository.UpdateAsync(rolFormPermission);
            return _mapper.Map<RolFormPermissionDTO>(updated);
        }

        public async Task<bool> SoftDeleteAsync(int id)
        {
            var rolFormPermission = await _rolFormPermissionRepository.GetByIdAsync(id);
            if (rolFormPermission == null) return false;

            if (rolFormPermission.Active)
            {
                rolFormPermission.Active = false;
                rolFormPermission.DeleteAt = DateTime.Now;
            }
            else
            {
                rolFormPermission.Active = true;
                rolFormPermission.DeleteAt = null;
            }

            await _rolFormPermissionRepository.UpdateAsync(rolFormPermission);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _rolFormPermissionRepository.DeleteAsync(id);
        }
    }
}