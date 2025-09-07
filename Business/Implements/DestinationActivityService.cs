using AutoMapper;
using Business.Interfaces;
using Data.Interfaces;
using Entity.Model;
using Entity.DTO;
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

        public async Task<bool> DeleteAsync(int id)
        {
            return await _destinationActivityRepository.DeleteAsync(id);
        }
    }
}