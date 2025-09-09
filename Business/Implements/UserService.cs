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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserDTO>> GetAllAsync()
        {
            var user = await _userRepository.GetAllAsync();
            return _mapper.Map<List<UserDTO>>(user);
        }

        public async Task<UserDTO> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> CreateAsync(UserDTO userDto)
        {
            var user = _mapper.Map<User>(userDto);
            var userCreado = await _userRepository.CreateAsync(user);
            return _mapper.Map<UserDTO>(userCreado);
        }

        public async Task<UserDTO> UpdateAsync(int id, UserDTO userDto)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return null!; // Devuelve null forzando la nulabilidad, pero cumple la firma

            user.Username = userDto.Username;
            user.Password = userDto.Password;

            var updated = await _userRepository.UpdateAsync(user);
            return _mapper.Map<UserDTO>(updated);
        }

        public async Task<UserDTO> UpdatePartialAsync(int id, JsonPatchDocument<UserDTO> patchDoc)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return null!;

            var userDto = _mapper.Map<UserDTO>(user);
            patchDoc.ApplyTo(userDto);

            // Mapea de nuevo a la entidad y actualiza
            _mapper.Map(userDto, user);
            var updated = await _userRepository.UpdateAsync(user);
            return _mapper.Map<UserDTO>(updated);
        }

        public async Task<bool> SoftDeleteAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return false;

            if (user.Active)
            {
                user.Active = false;
                user.DeleteAt = DateTime.Now;
            }
            else
            {
                user.Active = true;
                user.DeleteAt = null;
            }

            await _userRepository.UpdateAsync(user);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _userRepository.DeleteAsync(id);
        }
    }
}