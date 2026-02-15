using ExquisiteCorpseAPI.Enums;
using ExquisiteCorpseAPI.Extensions;
using ExquisiteCorpseAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ExquisiteCorpseAPI.Data
{
  public class Context(DbContextOptions<Context> options) : DbContext(options)
  {
    public DbSet<Language> Languages { get; set; }
    public DbSet<Adjective> Adjectives { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Verb> Verbs { get; set; }
    public DbSet<ObjectWord> ObjectWords { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);
    }
  }

  public static class ContextInitializer
  {
    public static void Initialize(IServiceProvider services)
    {
      using var scope = services.CreateScope();
      var context = scope.ServiceProvider.GetRequiredService<Context>();
      context.Database.EnsureDeleted();
      context.Database.Migrate();
      Seed(context);
    }

    private static void Seed(Context context)
    {
      SeedBrazilianPortuguese(context);
      context.SaveChanges();
    }

    private static void SeedBrazilianPortuguese(Context context)
    {
      var language = new Language
      {
        Id = (int)Languages.BRAZILIAN_PORTUGUESE,
        Name = "Português Brasileiro",
        Acronym = "pt-BR",
      }
      .AddSubjects("o gato", "a mulher", "o homem", "o artista", "o programador", "a criança", "o poeta", "a sombra", "o viajante", "o desconhecido")
      .AddAdjectives("feliz", "triste", "rápido", "lento", "estranho", "silencioso", "barulhento", "brilhante", "sombrio", "antigo", "moderno", "quente", "frio")
      .AddVerbs("observa", "destrói", "cria", "encontra", "persegue", "abraça", "evita", "imagina", "constrói", "questiona")
      .AddObjects("o mundo", "um sonho", "a realidade", "o silêncio", "a escuridão", "a luz", "o passado", "o futuro", "o vazio", "a memória");

      context.Add(language);
    }
  }
}