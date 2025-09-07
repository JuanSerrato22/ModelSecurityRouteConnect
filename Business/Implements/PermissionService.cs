using AutoMapper;
using Business.Interfaces;
using Data.Interfaces;
using Entity.Model;
using Entity.DTO;
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

        public async Task<bool> DeleteAsync(int id)
        {
            return await _permissionRepository.DeleteAsync(id);
        }
    }
}