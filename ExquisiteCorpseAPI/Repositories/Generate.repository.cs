using ExquisiteCorpseAPI.Data;
using ExquisiteCorpseAPI.Enums;
using ExquisiteCorpseAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExquisiteCorpseAPI.Repositories
{
  public class GenerateRepository(Context context) : IGenerateRepository
  {
    private readonly Context _context = context;

    public async Task<string> Generate(Languages languages)
    {
      var subject = await _context.Subjects
        .Where(x => x.LanguageId == (int)languages)
        .OrderBy(x => EF.Functions.Random())
        .Select(x => x.Text)
        .FirstOrDefaultAsync();

      var adjective = await _context.Adjectives
        .Where(x => x.LanguageId == (int)languages)
        .OrderBy(x => EF.Functions.Random())
        .Select(x => x.Text)
        .FirstOrDefaultAsync();

      var verb = await _context.Verbs
        .Where(x => x.LanguageId == (int)languages)
        .OrderBy(x => EF.Functions.Random())
        .Select(x => x.Text)
        .FirstOrDefaultAsync();

      var objectWord = await _context.ObjectWords
        .Where(x => x.LanguageId == (int)languages)
        .OrderBy(x => EF.Functions.Random())
        .Select(x => x.Text)
        .FirstOrDefaultAsync();

      return $"{subject} {adjective} {verb} {objectWord}";
    }
  }
}