using Domain;
using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.UseCases.Persons
{
    public class GetPersonByCode
    {
        public readonly ICodeRepository<PersonEntity> _codeRepository;

        public GetPersonByCode(ICodeRepository<PersonEntity> codeRepository)
        {
            _codeRepository = codeRepository;
        }

        public async Task<PersonEntity> ExecuteAsync(string code)
        {
            var person = await _codeRepository.GetByCodeAsync(code);

            if (person == null)
            {
                throw new InvalidOperationException($"No se encontró a ninguna persona con código: {code}")
            }

            return person;
        }
}
