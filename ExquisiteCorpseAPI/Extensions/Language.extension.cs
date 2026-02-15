using ExquisiteCorpseAPI.Models;

namespace ExquisiteCorpseAPI.Extensions
{
  public static class LanguageExtensions
  {
    public static Language AddSubjects(this Language language, params string[] words)
    {
      language.Subjects = Generate<Subject>(language.Id, words);
      return language;
    }

    public static Language AddAdjectives(this Language language, params string[] words)
    {
      language.Adjectives = Generate<Adjective>(language.Id, words);
      return language;
    }

    public static Language AddVerbs(this Language language, params string[] words)
    {
      language.Verbs = Generate<Verb>(language.Id, words);
      return language;
    }

    public static Language AddObjects(this Language language, params string[] words)
    {
      language.ObjectWords = Generate<ObjectWord>(language.Id, words);
      return language;
    }

    private static ICollection<T> Generate<T>(int languageId, string[] words) where T : WordBase, new()
    {
      return [.. words.Select(w => new T
      {
        LanguageId = languageId,
        Text = w,
        Weight = Random.Shared.Next(1, 11)
      })];
    }
  }
}