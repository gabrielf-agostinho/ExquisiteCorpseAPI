using ExquisiteCorpseAPI.Models;

namespace ExquisiteCorpseAPI.Repositories.Interfaces
{
  public interface ILanguageRepository
  {
    Task<Language?> GetByAcronym(string acronym);
  }
}