using ExquisiteCorpseAPI.Models;
using ExquisiteCorpseAPI.Repositories.Interfaces;
using ExquisiteCorpseAPI.Services.Interfaces;

namespace ExquisiteCorpseAPI.Services
{
  public class LanguageService(ILanguageRepository languageRepository) : ILanguageService
  {
    private readonly ILanguageRepository _languageRepository = languageRepository;
    
    public Task<Language?> GetByAcronym(string acronym)
    {
      var language = _languageRepository.GetByAcronym(acronym);
      ArgumentNullException.ThrowIfNull(language);
      return language;
    }
  }
}