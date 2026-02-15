using ExquisiteCorpseAPI.Enums;

namespace ExquisiteCorpseAPI.Repositories.Interfaces
{
  public interface IGenerateRepository
  {
    Task<string> Generate(Languages language);
  }
}