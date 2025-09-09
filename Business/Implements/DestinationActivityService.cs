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
    public class DestinationActivityService : IDestinationActivityService
    {
        private readonly IDestinationActivityRepository _destinationActivityRepository;
        private readonly IMapper _mapper;

        public DestinationActivityService(IDestinationActivityRepository destinationActivityRepository, IMapper mapper)
        {
            _destinationActivityRepository = destinationActivityRepository;
            _mapper = mapper;
        }

        public async Task<List<DestinationActivityDTO>> GetAllAsync()
        {
            var destinationActivity = await _destinationActivityRepository.GetAllAsync();
            return _mapper.Map<List<DestinationActivityDTO>>(destinationActivity);
        }

        public async Task<DestinationActivityDTO> GetByIdAsync(int id)
        {
            var destinationActivity = await _destinationActivityRepository.GetByIdAsync(id);
            return _mapper.Map<DestinationActivityDTO>(destinationActivity);
        }

        public async Task<DestinationActivityDTO> CreateAsync(DestinationActivityDTO destinationActivityDto)
        {
            var destinationActivity = _mapper.Map<DestinationActivity>(destinationActivityDto);
            var destinationActivityCreado = await _destinationActivityRepository.CreateAsync(destinationActivity);
            return _mapper.Map<DestinationActivityDTO>(destinationActivityCreado);
        }

        public async Task<DestinationActivityDTO> UpdateAsync(int id, DestinationActivityDTO destinationActivityDto)
        {
            var destinationActivity = await _destinationActivityRepository.GetByIdAsync(id);
            if (destinationActivity == null) return null!; // Devuelve null forzando la nulabilidad, pero cumple la firma

            destinationActivity.Id = destinationActivityDto.Id;
            destinationActivity.DestinationId = destinationActivityDto.DestinationId;
            destinationActivity.ActivityId = destinationActivityDto.ActivityId;

            var actualizado = await _destinationActivityRepository.UpdateAsync(destinationActivity);
            return _mapper.Map<DestinationActivityDTO>(actualizado);
        }

        public async Task<DestinationActivityDTO> UpdatePartialAsync(int id, JsonPatchDocument<DestinationActivityDTO> patchDoc)
        {
            var destinationActivity = await _destinationActivityRepository.GetByIdAsync(id);
            if (destinationActivity == null) return null!;

            var destinationActivityDto = _mapper.Map<DestinationActivityDTO>(destinationActivity);
            patchDoc.ApplyTo(destinationActivityDto);

            // Mapea de nuevo a la entidad y actualiza
            _mapper.Map(destinationActivityDto, destinationActivity);
            var updated = await _destinationActivityRepository.UpdateAsync(destinationActivity);
            return _mapper.Map<DestinationActivityDTO>(updated);
        }

        public async Task<bool> SoftDeleteAsync(int id)
        {
            var destinationActivity = await _destinationActivityRepository.GetByIdAsync(id);
            if (destinationActivity == null) return false;

            if (destinationActivity.Active)
            {
                destinationActivity.Active = false;
                destinationActivity.DeleteAt = DateTime.Now;
            }
            else
            {
                destinationActivity.Active = true;
                destinationActivity.DeleteAt = null;
            }

            await _destinationActivityRepository.UpdateAsync(destinationActivity);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _destinationActivityRepository.DeleteAsync(id);
        }
    }
}