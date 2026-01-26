using Domain;
using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.UseCases.Persons
{
    public class GetExistsWithCode
    {
        public readonly ICodeRepository <PersonEntity> _codeRepository;
        public GetExistsWithCode(ICodeRepository<PersonEntity> codeRepository)
        {
            _codeRepository = codeRepository;
        }
        public async Task<bool> ExecuteAsync(string code)
        {
            var person = await _codeRepository.ExistsWithCodeAsync(code);

            if (person == false)
            {
                throw new InvalidOperationException($"No se encontró a ninguna persona con código: {code}");
            }

            return person;

        }
    }
}
