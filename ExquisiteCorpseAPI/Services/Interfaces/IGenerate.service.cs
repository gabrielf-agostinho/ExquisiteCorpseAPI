namespace ExquisiteCorpseAPI.Services.Interfaces
{
  public interface IGenerateService
  {
    Task<string> Generate(string acronym);
  }
}