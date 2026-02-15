namespace ExquisiteCorpseAPI.Models
{
  public abstract class WordBase
  {
    public int Id { get; set; }
    public int LanguageId { get; set; }
    public string Text { get; set; } = null!;
    public int Weight { get; set; } = 1;
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public Language Language { get; set; } = null!;
  }
}