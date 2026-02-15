namespace ExquisiteCorpseAPI.Utils
{
  public static class SeedReader
  {
    public static string[] ReadLines(string path)
    {
      if (!File.Exists(path))
        return [];

      return [.. File.ReadAllLines(path)
        .Where(x => !string.IsNullOrWhiteSpace(x))
        .Select(x => x.Trim())
        .Distinct()];
    }
  }
}