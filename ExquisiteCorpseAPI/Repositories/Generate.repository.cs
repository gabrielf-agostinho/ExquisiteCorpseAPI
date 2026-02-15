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
      var subjects = await _context.Subjects
        .Where(x => x.LanguageId == (int)languages && x.IsActive)
        .ToListAsync();

      var adjectives = await _context.Adjectives
        .Where(x => x.LanguageId == (int)languages && x.IsActive)
        .ToListAsync();

      var verbs = await _context.Verbs
        .Where(x => x.LanguageId == (int)languages && x.IsActive)
        .ToListAsync();

      var objectWords = await _context.ObjectWords
        .Where(x => x.LanguageId == (int)languages && x.IsActive)
        .ToListAsync();

      var subject = WeightedRandom(subjects, x => x.Weight);

      var adjective = WeightedRandom(adjectives.Where(x => x.GenderId == subject?.GenderId || x.GenderId == (int)Genders.NEUTRAL).ToList(), x => x.Weight)?.Text;

      var verb = WeightedRandom(verbs, x => x.Weight)?.Text;
      var objectWord = WeightedRandom(objectWords, x => x.Weight)?.Text;

      return $"{subject?.Text} {adjective} {verb} {objectWord}";
    }

    private static T? WeightedRandom<T>(List<T> items, Func<T, int> weightSelector)
    {
      if (items.Count == 0)
        return default;

      var totalWeight = items.Sum(weightSelector);
      var random = Random.Shared.Next(1, totalWeight + 1);
      var cumulative = 0;

      foreach (var item in items)
      {
        cumulative += weightSelector(item);

        if (random <= cumulative)
          return item;
      }

      return default;
    }
  }
}