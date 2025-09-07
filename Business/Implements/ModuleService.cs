using AutoMapper;
using Business.Interfaces;
using Data.Interfaces;
using Entity.Model;
using Entity.DTO;
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

        public async Task<bool> DeleteAsync(int id)
        {
            return await _moduleRepository.DeleteAsync(id);
        }
    }
}