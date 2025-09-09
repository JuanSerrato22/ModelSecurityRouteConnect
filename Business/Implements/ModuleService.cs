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
    public class ModuleService : IModuleService
    {
        private readonly IModuleRepository _moduleRepository;
        private readonly IMapper _mapper;

        public ModuleService(IModuleRepository moduleRepository, IMapper mapper)
        {
            _moduleRepository = moduleRepository;
            _mapper = mapper;
        }

        public async Task<List<ModuleDTO>> GetAllAsync()
        {
            var module = await _moduleRepository.GetAllAsync();
            return _mapper.Map<List<ModuleDTO>>(module);
        }

        public async Task<ModuleDTO> GetByIdAsync(int id)
        {
            var module = await _moduleRepository.GetByIdAsync(id);
            return _mapper.Map<ModuleDTO>(module);
        }

        public async Task<ModuleDTO> CreateAsync(ModuleDTO moduleDto)
        {
            var module = _mapper.Map<Module>(moduleDto);
            var moduleCreado = await _moduleRepository.CreateAsync(module);
            return _mapper.Map<ModuleDTO>(moduleCreado);
        }

        public async Task<ModuleDTO> UpdateAsync(int id, ModuleDTO moduleDto)
        {
            var module = await _moduleRepository.GetByIdAsync(id);
            if (module == null) return null!; // Devuelve null forzando la nulabilidad, pero cumple la firma

            module.Name = moduleDto.Name;

            var actualizado = await _moduleRepository.UpdateAsync(module);
            return _mapper.Map<ModuleDTO>(actualizado);
        }

        public async Task<ModuleDTO> UpdatePartialAsync(int id, JsonPatchDocument<ModuleDTO> patchDoc)
        {
            var module = await _moduleRepository.GetByIdAsync(id);
            if (module == null) return null!;

            var moduleDto = _mapper.Map<ModuleDTO>(module);
            patchDoc.ApplyTo(moduleDto);

            // Mapea de nuevo a la entidad y actualiza
            _mapper.Map(moduleDto, module);
            var updated = await _moduleRepository.UpdateAsync(module);
            return _mapper.Map<ModuleDTO>(updated);
        }

        public async Task<bool> SoftDeleteAsync(int id)
        {
            var module = await _moduleRepository.GetByIdAsync(id);
            if (module == null) return false;

            if (module.Active)
            {
                module.Active = false;
                module.DeleteAt = DateTime.Now;
            }
            else
            {
                module.Active = true;
                module.DeleteAt = null;
            }

            await _moduleRepository.UpdateAsync(module);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _moduleRepository.DeleteAsync(id);
        }
    }
}