using ExquisiteCorpseAPI.Models;

namespace ExquisiteCorpseAPI.Services.Interfaces
{
  public interface ILanguageService
  {
    Task<Language?> GetByAcronym(string acronym);
  }
}