using ExquisiteCorpseAPI.Enums;
using ExquisiteCorpseAPI.Repositories.Interfaces;
using ExquisiteCorpseAPI.Services.Interfaces;

namespace ExquisiteCorpseAPI.Services
{
  public class GenerateService(
    IGenerateRepository generateRepository,
    ILanguageService languageService
  ) : IGenerateService
  {
    private readonly IGenerateRepository _generateRepository = generateRepository;
    private readonly ILanguageService _languageService = languageService;

    public async Task<string> Generate(string acronym)
    {
      if (string.IsNullOrEmpty(acronym) || string.IsNullOrWhiteSpace(acronym))
        throw new ArgumentNullException(nameof(acronym));
        
      var language = await _languageService.GetByAcronym(acronym);
      return await _generateRepository.Generate((Languages)language!.Id);
    }
  }
}