using Domain;
using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.UseCases.Persons
{
    public class GetAllPersonsUseCase
    {
        public readonly IRepository<PersonEntity, Guid> _repository;

        public GetAllPersonsUseCase(IRepository<PersonEntity, Guid> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PersonEntity>> ExecuteAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}
