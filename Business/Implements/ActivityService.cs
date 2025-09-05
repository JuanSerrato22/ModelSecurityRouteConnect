using AutoMapper;
using Business.Interfaces;
using Data.Interfaces;
using Entity.Model;
using Entity.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Implements
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository _activityRepository;
        private readonly IMapper _mapper;

        public ActivityService(IActivityRepository activityRepository, IMapper mapper)
        {
            _activityRepository = activityRepository;
            _mapper = mapper;
        }

        public async Task<List<ActivityDTO>> GetAllAsync()
        {
            var activity = await _activityRepository.GetAllAsync();
            return _mapper.Map<List<ActivityDTO>>(activity);
        }

        public async Task<ActivityDTO> GetByIdAsync(int id)
        {
            var activity = await _activityRepository.GetByIdAsync(id);
            return _mapper.Map<ActivityDTO>(activity);
        }

        public async Task<ActivityDTO> CreateAsync(ActivityDTO activityDto)
        {
            var activity = _mapper.Map<Activity>(activityDto);
            var activityCreado = await _activityRepository.CreateAsync(activity);
            return _mapper.Map<ActivityDTO>(activityCreado);
        }

        public async Task<ActivityDTO> UpdateAsync(int id, ActivityDTO activityDto)
        {
            var activity = await _activityRepository.GetByIdAsync(id);
            if (activity == null) return null!; // Devuelve null forzando la nulabilidad, pero cumple la firma

            activity.Name = activityDto.Name;
            activity.Description = activityDto.Description;
            activity.Category = activityDto.Category;
            activity.Price = activityDto.Price;

            var actualizado = await _activityRepository.UpdateAsync(activity);
            return _mapper.Map<ActivityDTO>(actualizado);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _activityRepository.DeleteAsync(id);
        }
    }
}