using Aplication.DTOs.Persons;
using Domain;
using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Aplication.UseCases.Persons
{
    public class UpdatePersonUseCase
    {
        private readonly IRepository<PersonEntity, Guid> _repository;

        public UpdatePersonUseCase(IRepository<PersonEntity, Guid> repository)
        {
            _repository = repository;
        }

        public async Task<PersonEntity> EntityAsync (UpdatePersonDto dto)
        {
            var person = await _repository.GetByIdAsync(dto.Id);

            if (person == null)
            {
                throw new InvalidOperationException($"No se encontró una persona con el ID: {dto.Id}");
            }

            person.UpdatePersonalIfo(dto.FirstName, dto.LastName, dto.Email, dto.PhoneNumber);
            
            await _repository.UpdateAsync(person);

            await _repository.SaveChangesAsync();

            return person;
        }

    }
}
