using AutoMapper;
using Business.Interfaces;
using Data.Interfaces;
using Entity.Model;
using Entity.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Implements
{
    public class FormService : IFormService
    {
        private readonly IFormRepository _formRepository;
        private readonly IMapper _mapper;

        public FormService(IFormRepository formRepository, IMapper mapper)
        {
            _formRepository = formRepository;
            _mapper = mapper;
        }

        public async Task<List<FormDTO>> GetAllAsync()
        {
            var form = await _formRepository.GetAllAsync();
            return _mapper.Map<List<FormDTO>>(form);
        }

        public async Task<FormDTO> GetByIdAsync(int id)
        {
            var form = await _formRepository.GetByIdAsync(id);
            return _mapper.Map<FormDTO>(form);
        }

        public async Task<FormDTO> CreateAsync(FormDTO formDto)
        {
            var form = _mapper.Map<Form>(formDto);
            var formCreado = await _formRepository.CreateAsync(form);
            return _mapper.Map<FormDTO>(formCreado);
        }

        public async Task<FormDTO> UpdateAsync(int id, FormDTO formDto)
        {
            var form = await _formRepository.GetByIdAsync(id);
            if (form == null) return null!; // Devuelve null forzando la nulabilidad, pero cumple la firma

            form.Name = formDto.Name;

            var actualizado = await _formRepository.UpdateAsync(form);
            return _mapper.Map<FormDTO>(actualizado);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _formRepository.DeleteAsync(id);
        }
    }
}