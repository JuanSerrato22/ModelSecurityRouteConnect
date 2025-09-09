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
    public class UserRolService : IUserRolService
    {
        private readonly IUserRolRepository _userRolRepository;
        private readonly IMapper _mapper;

        public UserRolService(IUserRolRepository userRolRepository, IMapper mapper)
        {
            _userRolRepository = userRolRepository;
            _mapper = mapper;
        }

        public async Task<List<UserRolDTO>> GetAllAsync()
        {
            var userRol = await _userRolRepository.GetAllAsync();
            return _mapper.Map<List<UserRolDTO>>(userRol);
        }

        public async Task<UserRolDTO> GetByIdAsync(int id)
        {
            var userRol = await _userRolRepository.GetByIdAsync(id);
            return _mapper.Map<UserRolDTO>(userRol);
        }

        public async Task<UserRolDTO> CreateAsync(UserRolDTO userRolDto)
        {
            var userRol = _mapper.Map<UserRol>(userRolDto);
            var userRolCreado = await _userRolRepository.CreateAsync(userRol);
            return _mapper.Map<UserRolDTO>(userRolCreado);
        }

        public async Task<UserRolDTO> UpdateAsync(int id, UserRolDTO userRolDto)
        {
            var userRol = await _userRolRepository.GetByIdAsync(id);
            if (userRol == null) return null!; // Devuelve null forzando la nulabilidad, pero cumple la firma

            userRol.Name = userRolDto.Name;

            var actualizado = await _userRolRepository.UpdateAsync(userRol);
            return _mapper.Map<UserRolDTO>(actualizado);
        }

        public async Task<UserRolDTO> UpdatePartialAsync(int id, JsonPatchDocument<UserRolDTO> patchDoc)
        {
            var userRol = await _userRolRepository.GetByIdAsync(id);
            if (userRol == null) return null!;

            var userRolDto = _mapper.Map<UserRolDTO>(userRol);
            patchDoc.ApplyTo(userRolDto);

            // Mapea de nuevo a la entidad y actualiza
            _mapper.Map(userRolDto, userRol);
            var updated = await _userRolRepository.UpdateAsync(userRol);
            return _mapper.Map<UserRolDTO>(updated);
        }

        public async Task<bool> SoftDeleteAsync(int id)
        {
            var userRol = await _userRolRepository.GetByIdAsync(id);
            if (userRol == null) return false;

            if (userRol.Active)
            {
                userRol.Active = false;
                userRol.DeleteAt = DateTime.Now;
            }
            else
            {
                userRol.Active = true;
                userRol.DeleteAt = null;
            }

            await _userRolRepository.UpdateAsync(userRol);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _userRolRepository.DeleteAsync(id);
        }
    }
}