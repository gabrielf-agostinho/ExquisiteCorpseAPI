using ExquisiteCorpseAPI.Enums;
using ExquisiteCorpseAPI.Models;

namespace ExquisiteCorpseAPI.Extensions
{
  public static class LanguageExtensions
  {
    public static Language AddSubjects(this Language language, params string[] words)
    {
      language.Subjects = [.. Generate<Subject>(language.Id, words)
        .Select(subject =>
        {
          if (language.Id == (int)Languages.BRAZILIAN_PORTUGUESE)
          {
            var firstChar = char.ToLowerInvariant(subject.Text?[0] ?? '\0');

            subject.GenderId = firstChar switch
            {
              'o' => (int)Genders.MALE,
              'a' => (int)Genders.FEMALE,
              _ => (int)Genders.NEUTRAL
            };
          }

          return subject;
        })];

      return language;
    }

    public static Language AddAdjectives(this Language language, params string[] words)
    {
      language.Adjectives = [.. Generate<Adjective>(language.Id, words)
        .Select(adjective =>
        {
          if (language.Id == (int)Languages.BRAZILIAN_PORTUGUESE)
          {
            adjective.GenderId = adjective.Text[^1] switch
            {
              'o' => (int)Genders.MALE,
              'a' => (int)Genders.FEMALE,
              _ => (int)Genders.NEUTRAL
            };
          }

          return adjective;
        })];

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