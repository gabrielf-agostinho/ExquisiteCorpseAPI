namespace ExquisiteCorpseAPI.Models
{
  public class Subject : WordBase
  {
    public int GenderId { get; set; }

    public Gender Gender { get; set; } = null!;
  }
}