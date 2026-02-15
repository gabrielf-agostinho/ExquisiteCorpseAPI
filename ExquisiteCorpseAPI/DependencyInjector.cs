using ExquisiteCorpseAPI.Repositories;
using ExquisiteCorpseAPI.Repositories.Interfaces;
using ExquisiteCorpseAPI.Services;
using ExquisiteCorpseAPI.Services.Interfaces;

namespace ExquisiteCorpseAPI
{
  public static class DependencyInjector
  {
    public static void Register(IServiceCollection services)
    {
      RegisterRepositories(services);
      RegisterServices(services);
    }

    private static void RegisterRepositories(IServiceCollection services)
    {
      services.AddScoped<ILanguageRepository, LanguageRepository>();
      services.AddScoped<IGenerateRepository, GenerateRepository>();
    }

    private static void RegisterServices(IServiceCollection services)
    {
      services.AddScoped<ILanguageService, LanguageService>();
      services.AddScoped<IGenerateService, GenerateService>();
    }
  }
}