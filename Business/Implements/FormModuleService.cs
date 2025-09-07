using AutoMapper;
using Business.Interfaces;
using Data.Interfaces;
using Entity.Model;
using Entity.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Implements
{
    public class FormModuleService : IFormModuleService
    {
        private readonly IFormModuleRepository _formModuleRepository;
        private readonly IMapper _mapper;

        public FormModuleService(IFormModuleRepository formModuleRepository, IMapper mapper)
        {
            _formModuleRepository = formModuleRepository;
            _mapper = mapper;
        }

        public async Task<List<FormModuleDTO>> GetAllAsync()
        {
            var formModule = await _formModuleRepository.GetAllAsync();
            return _mapper.Map<List<FormModuleDTO>>(formModule);
        }

        public async Task<FormModuleDTO> GetByIdAsync(int id)
        {
            var formModule = await _formModuleRepository.GetByIdAsync(id);
            return _mapper.Map<FormModuleDTO>(formModule);
        }

        public async Task<FormModuleDTO> CreateAsync(FormModuleDTO formModuleDto)
        {
            var formModule = _mapper.Map<FormModule>(formModuleDto);
            var formModuleCreado = await _formModuleRepository.CreateAsync(formModule);
            return _mapper.Map<FormModuleDTO>(formModuleCreado);
        }

        public async Task<FormModuleDTO> UpdateAsync(int id, FormModuleDTO formModuleDto)
        {
            var formModule = await _formModuleRepository.GetByIdAsync(id);
            if (formModule == null) return null!; // Devuelve null forzando la nulabilidad, pero cumple la firma

            formModule.Name = formModuleDto.Name;

            var actualizado = await _formModuleRepository.UpdateAsync(formModule);
            return _mapper.Map<FormModuleDTO>(actualizado);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _formModuleRepository.DeleteAsync(id);
        }
    }
}