namespace ExquisiteCorpseAPI.Models
{
  public class Adjective : WordBase
  {
    public int GenderId { get; set; }

    public Gender Gender { get; set; } = null!;
  }
}