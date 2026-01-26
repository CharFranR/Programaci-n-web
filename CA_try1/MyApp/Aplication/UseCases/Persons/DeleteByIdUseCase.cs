using Domain;
using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.UseCases.Persons
{
    public class DeleteByIdUseCase
    {
        public readonly IRepository<PersonEntity, Guid> _repository;
        public DeleteByIdUseCase(IRepository<PersonEntity, Guid> repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(Guid id) 
        {
            var person = await _repository.GetByIdAsync(id);

            if (person == null)
            {
                throw new InvalidOperationException($"No se encontró a ningún usuario con Id: {id}");
            }

            await _repository.DeleteAsync(person);
            await _repository.SaveChanges();

        }
    }
}