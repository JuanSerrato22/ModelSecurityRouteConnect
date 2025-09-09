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

        public async Task<FormDTO> UpdatePartialAsync(int id, JsonPatchDocument<FormDTO> patchDoc)
        {
            var form = await _formRepository.GetByIdAsync(id);
            if (form == null) return null!;

            var formDto = _mapper.Map<FormDTO>(form);
            patchDoc.ApplyTo(formDto);

            // Mapea de nuevo a la entidad y actualiza
            _mapper.Map(formDto, form);
            var updated = await _formRepository.UpdateAsync(form);
            return _mapper.Map<FormDTO>(updated);
        }

        public async Task<bool> SoftDeleteAsync(int id)
        {
            var form = await _formRepository.GetByIdAsync(id);
            if (form == null) return false;

            if (form.Active)
            {
                form.Active = false;
                form.DeleteAt = DateTime.Now;
            }
            else
            {
                form.Active = true;
                form.DeleteAt = null;
            }

            await _formRepository.UpdateAsync(form);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _formRepository.DeleteAsync(id);
        }
    }
}