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
    public class DestinationService : IDestinationService
    {
        private readonly IDestinationRepository _destinationRepository;
        private readonly IMapper _mapper;

        public DestinationService(IDestinationRepository destinationRepository, IMapper mapper)
        {
            _destinationRepository = destinationRepository;
            _mapper = mapper;
        }

        public async Task<List<DestinationDTO>> GetAllAsync()
        {
            var destination = await _destinationRepository.GetAllAsync();
            return _mapper.Map<List<DestinationDTO>>(destination);
        }

        public async Task<DestinationDTO> GetByIdAsync(int id)
        {
            var destination = await _destinationRepository.GetByIdAsync(id);
            return _mapper.Map<DestinationDTO>(destination);
        }

        public async Task<DestinationDTO> CreateAsync(DestinationDTO destinationDto)
        {
            var destination = _mapper.Map<Destination>(destinationDto);
            var destinationCreado = await _destinationRepository.CreateAsync(destination);
            return _mapper.Map<DestinationDTO>(destinationCreado);
        }

        public async Task<DestinationDTO> UpdateAsync(int id, DestinationDTO destinationDto)
        {
            var destination = await _destinationRepository.GetByIdAsync(id);
            if (destination == null) return null!; // Devuelve null forzando la nulabilidad, pero cumple la firma

            destination.Name = destinationDto.Name;
            destination.Description = destinationDto.Description;
            destination.Country = destinationDto.Country;
            destination.Region = destinationDto.Region;
            destination.Latitude = destinationDto.Latitude;
            destination.Longitude = destinationDto.Longitude;

            var actualizado = await _destinationRepository.UpdateAsync(destination);
            return _mapper.Map<DestinationDTO>(actualizado);
        }

        public async Task<DestinationDTO> UpdatePartialAsync(int id, JsonPatchDocument<DestinationDTO> patchDoc)
        {
            var destination = await _destinationRepository.GetByIdAsync(id);
            if (destination == null) return null!;

            var destinationDto = _mapper.Map<DestinationDTO>(destination);
            patchDoc.ApplyTo(destinationDto);

            // Mapea de nuevo a la entidad y actualiza
            _mapper.Map(destinationDto, destination);
            var updated = await _destinationRepository.UpdateAsync(destination);
            return _mapper.Map<DestinationDTO>(updated);
        }

        public async Task<bool> SoftDeleteAsync(int id)
        {
            var destination = await _destinationRepository.GetByIdAsync(id);
            if (destination == null) return false;

            if (destination.Active)
            {
                destination.Active = false;
                destination.DeleteAt = DateTime.Now;
            }
            else
            {
                destination.Active = true;
                destination.DeleteAt = null;
            }

            await _destinationRepository.UpdateAsync(destination);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _destinationRepository.DeleteAsync(id);
        }
    }
}