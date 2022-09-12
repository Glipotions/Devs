using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.Languages.Rules
{
    public class LanguageBusinessRules
    {
        private readonly ILanguageRepository _languageRepository;

        public LanguageBusinessRules(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }

        /// <ÖZET>
        /// Kuraldan geçmediği her durumda hata fırlatır
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="BusinessException"></exception>
        public async Task LanguageNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<Language> result = await _languageRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException("programming language name exists.");
        }

        public async Task LanguageShouldExistWhenRequested(Language language)
        {
            if (language == null) throw new BusinessException("Requested language does not exist");

            await Task.CompletedTask;
        }
    }
}
