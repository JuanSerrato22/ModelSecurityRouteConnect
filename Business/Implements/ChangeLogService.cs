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
    public class ChangeLogService : IChangeLogService
    {
        private readonly IChangeLogRepository _changelogRepository;
        private readonly IMapper _mapper;

        public ChangeLogService(IChangeLogRepository changelogRepository, IMapper mapper)
        {
            _changelogRepository = changelogRepository;
            _mapper = mapper;
        }

        public async Task<List<ChangeLogDTO>> GetAllAsync()
        {
            var changelog = await _changelogRepository.GetAllAsync();
            return _mapper.Map<List<ChangeLogDTO>>(changelog);
        }

        public async Task<ChangeLogDTO> GetByIdAsync(int id)
        {
            var changelog = await _changelogRepository.GetByIdAsync(id);
            return _mapper.Map<ChangeLogDTO>(changelog);
        }

        public async Task<ChangeLogDTO> CreateAsync(ChangeLogDTO changelogDto)
        {
            var changelog = _mapper.Map<ChangeLog>(changelogDto);
            var changelogCreado = await _changelogRepository.CreateAsync(changelog);
            return _mapper.Map<ChangeLogDTO>(changelogCreado);
        }

        public async Task<ChangeLogDTO> UpdateAsync(int id, ChangeLogDTO changelogDto)
        {
            var changelog = await _changelogRepository.GetByIdAsync(id);
            if (changelog == null) return null!; // Devuelve null forzando la nulabilidad, pero cumple la firma

            changelog.Description = changelogDto.Description;

            var actualizado = await _changelogRepository.UpdateAsync(changelog);
            return _mapper.Map<ChangeLogDTO>(actualizado);
        }

        public async Task<ChangeLogDTO> UpdatePartialAsync(int id, JsonPatchDocument<ChangeLogDTO> patchDoc)
        {
            var changeLog = await _changelogRepository.GetByIdAsync(id);
            if (changeLog == null) return null!;

            var changeLogDto = _mapper.Map<ChangeLogDTO>(changeLog);
            patchDoc.ApplyTo(changeLogDto);

            // Mapea de nuevo a la entidad y actualiza
            _mapper.Map(changeLogDto, changeLog);
            var updated = await _changelogRepository.UpdateAsync(changeLog);
            return _mapper.Map<ChangeLogDTO>(updated);
        }

        public async Task<bool> SoftDeleteAsync(int id)
        {
            var changeLog = await _changelogRepository.GetByIdAsync(id);
            if (changeLog == null) return false;

            if (changeLog.Active)
            {
                changeLog.Active = false;
                changeLog.DeleteAt = DateTime.Now;
            }
            else
            {
                changeLog.Active = true;
                changeLog.DeleteAt = null;
            }

            await _changelogRepository.UpdateAsync(changeLog);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _changelogRepository.DeleteAsync(id);
        }
    }
}