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
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository _permissionRepository;
        private readonly IMapper _mapper;

        public PermissionService(IPermissionRepository permissionRepository, IMapper mapper)
        {
            _permissionRepository = permissionRepository;
            _mapper = mapper;
        }

        public async Task<List<PermissionDTO>> GetAllAsync()
        {
            var permission = await _permissionRepository.GetAllAsync();
            return _mapper.Map<List<PermissionDTO>>(permission);
        }

        public async Task<PermissionDTO> GetByIdAsync(int id)
        {
            var permission = await _permissionRepository.GetByIdAsync(id);
            return _mapper.Map<PermissionDTO>(permission);
        }

        public async Task<PermissionDTO> CreateAsync(PermissionDTO permissionDto)
        {
            var permission = _mapper.Map<Permission>(permissionDto);
            var permissionCreado = await _permissionRepository.CreateAsync(permission);
            return _mapper.Map<PermissionDTO>(permissionCreado);
        }

        public async Task<PermissionDTO> UpdateAsync(int id, PermissionDTO permissionDto)
        {
            var permission = await _permissionRepository.GetByIdAsync(id);
            if (permission == null) return null!; // Devuelve null forzando la nulabilidad, pero cumple la firma

            permission.PermissionName = permissionDto.PermissionName;
            permission.Description = permissionDto.Description;

            var actualizado = await _permissionRepository.UpdateAsync(permission);
            return _mapper.Map<PermissionDTO>(actualizado);
        }

        public async Task<PermissionDTO> UpdatePartialAsync(int id, JsonPatchDocument<PermissionDTO> patchDoc)
        {
            var permission = await _permissionRepository.GetByIdAsync(id);
            if (permission == null) return null!;

            var permissionDto = _mapper.Map<PermissionDTO>(permission);
            patchDoc.ApplyTo(permissionDto);

            // Mapea de nuevo a la entidad y actualiza
            _mapper.Map(permissionDto, permission);
            var updated = await _permissionRepository.UpdateAsync(permission);
            return _mapper.Map<PermissionDTO>(updated);
        }

        public async Task<bool> SoftDeleteAsync(int id)
        {
            var permission = await _permissionRepository.GetByIdAsync(id);
            if (permission == null) return false;

            if (permission.Active)
            {
                permission.Active = false;
                permission.DeleteAt = DateTime.Now;
            }
            else
            {
                permission.Active = true;
                permission.DeleteAt = null;
            }

            await _permissionRepository.UpdateAsync(permission);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _permissionRepository.DeleteAsync(id);
        }
    }
}