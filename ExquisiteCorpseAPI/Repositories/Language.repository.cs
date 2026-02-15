using ExquisiteCorpseAPI.Data;
using ExquisiteCorpseAPI.Models;
using ExquisiteCorpseAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExquisiteCorpseAPI.Repositories
{
  public class LanguageRepository(Context context) : ILanguageRepository
  {
    private readonly Context _context = context;

    public async Task<Language?> GetByAcronym(string acronym)
    {
      return await _context
        .Languages
        .Where(x => x.Acronym!.ToLower() == acronym.ToLower() && x.IsActive)
        .FirstOrDefaultAsync();
    }
  }
}