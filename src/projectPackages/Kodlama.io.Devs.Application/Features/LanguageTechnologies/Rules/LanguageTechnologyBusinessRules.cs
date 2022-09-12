using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.LanguageTechnologies.Rules
{
    public class LanguageTechnologyBusinessRules
    {
        private readonly ILanguageTechnologyRepository _languageTechnologyRepository;
        private readonly ILanguageRepository _programmingLanguageRepository;

        public LanguageTechnologyBusinessRules(ILanguageTechnologyRepository languageTechnologyRepository, ILanguageRepository programmingLanguageRepository)
        {
            _languageTechnologyRepository = languageTechnologyRepository;
            _programmingLanguageRepository = programmingLanguageRepository;
        }

        public async Task NameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<Domain.Entities.LanguageTechnology> result = await _languageTechnologyRepository.GetListAsync(f => f.Name == name);

            if (result.Items.Any())
                throw new BusinessException("LanguageTechnology's name exists!");
        }

        public async Task ShouldHaveValidForeignKey(int programmingLanguageId)
        {
            Domain.Entities.Language? result = await _programmingLanguageRepository.GetAsync(p => p.Id == programmingLanguageId);

            if (result == null)
                throw new BusinessException("ProgrammingLanguage Id is not found!");
        }

        public async Task ShouldHaveValidId(int languageTechnologyId)
        {
            Domain.Entities.LanguageTechnology? result = await _languageTechnologyRepository.GetAsync(p => p.Id == languageTechnologyId);

            if (result == null)
                throw new BusinessException("LanguageTechnology's Id is not found!");
        }

        public void LanguageTechnologyShouldExistWhenRequested(Domain.Entities.LanguageTechnology? languageTechnology)
        {
            if (languageTechnology == null) throw new BusinessException("Requested languageTechnology does not exists");
        }

    }
}
