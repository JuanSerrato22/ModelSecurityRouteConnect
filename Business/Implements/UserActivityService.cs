using AutoMapper;
using Business.Interfaces;
using Data.Interfaces;
using Entity.Model;
using Entity.DTO;
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

        public async Task<bool> DeleteAsync(int id)
        {
            return await _userActivityRepository.DeleteAsync(id);
        }
    }
}