using AutoMapper;
using Business.Interfaces;
using Data.Interfaces;
using Entity.Model;
using Entity.DTO;
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

        public async Task<bool> DeleteAsync(int id)
        {
            return await _rolPermissionRepository.DeleteAsync(id);
        }
    }
}