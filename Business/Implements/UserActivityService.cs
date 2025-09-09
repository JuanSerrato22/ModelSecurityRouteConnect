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
    public class UserActivityService : IUserActivityService
    {
        private readonly IUserActivityRepository _userActivityRepository;
        private readonly IMapper _mapper;

        public UserActivityService(IUserActivityRepository userActivityRepository, IMapper mapper)
        {
            _userActivityRepository = userActivityRepository;
            _mapper = mapper;
        }

        public async Task<List<UserActivityDTO>> GetAllAsync()
        {
            var userActivity = await _userActivityRepository.GetAllAsync();
            return _mapper.Map<List<UserActivityDTO>>(userActivity);
        }

        public async Task<UserActivityDTO> GetByIdAsync(int id)
        {
            var userActivity = await _userActivityRepository.GetByIdAsync(id);
            return _mapper.Map<UserActivityDTO>(userActivity);
        }

        public async Task<UserActivityDTO> CreateAsync(UserActivityDTO userActivityDto)
        {
            var userActivity = _mapper.Map<UserActivity>(userActivityDto);
            var userActivityCreado = await _userActivityRepository.CreateAsync(userActivity);
            return _mapper.Map<UserActivityDTO>(userActivityCreado);
        }

        public async Task<UserActivityDTO> UpdateAsync(int id, UserActivityDTO userActivityDto)
        {
            var userActivity = await _userActivityRepository.GetByIdAsync(id);
            if (userActivity == null) return null!; // Devuelve null forzando la nulabilidad, pero cumple la firma

            userActivity.Name = userActivityDto.Name;

            var actualizado = await _userActivityRepository.UpdateAsync(userActivity);
            return _mapper.Map<UserActivityDTO>(actualizado);
        }

        public async Task<UserActivityDTO> UpdatePartialAsync(int id, JsonPatchDocument<UserActivityDTO> patchDoc)
        {
            var userActivity = await _userActivityRepository.GetByIdAsync(id);
            if (userActivity == null) return null!;

            var userActivityDto = _mapper.Map<UserActivityDTO>(userActivity);
            patchDoc.ApplyTo(userActivityDto);

            // Mapea de nuevo a la entidad y actualiza
            _mapper.Map(userActivityDto, userActivity);
            var updated = await _userActivityRepository.UpdateAsync(userActivity);
            return _mapper.Map<UserActivityDTO>(updated);
        }

        public async Task<bool> SoftDeleteAsync(int id)
        {
            var userActivity = await _userActivityRepository.GetByIdAsync(id);
            if (userActivity == null) return false;

            if (userActivity.Active)
            {
                userActivity.Active = false;
                userActivity.DeleteAt = DateTime.Now;
            }
            else
            {
                userActivity.Active = true;
                userActivity.DeleteAt = null;
            }

            await _userActivityRepository.UpdateAsync(userActivity);
            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await _userActivityRepository.DeleteAsync(id);
        }
    }
}