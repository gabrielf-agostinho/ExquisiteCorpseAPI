using ExquisiteCorpseAPI.Enums;
using ExquisiteCorpseAPI.Extensions;
using ExquisiteCorpseAPI.Models;
using ExquisiteCorpseAPI.Utils;
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
      var basePath = Path.Combine(AppContext.BaseDirectory, "Seeds", "pt-BR");
      var language = new Language
      {
        Id = (int)Languages.BRAZILIAN_PORTUGUESE,
        Name = "Português Brasileiro",
        Acronym = "pt-BR",
      }
      .AddSubjects(SeedReader.ReadLines(Path.Combine(basePath, "subjects.txt")))
      .AddAdjectives(SeedReader.ReadLines(Path.Combine(basePath, "adjectives.txt")))
      .AddVerbs(SeedReader.ReadLines(Path.Combine(basePath, "verbs.txt")))
      .AddObjects(SeedReader.ReadLines(Path.Combine(basePath, "objects.txt")));

      context.Add(language);
    }
  }
}