namespace ExquisiteCorpseAPI.Models
{
  public class Gender
  {
    public int Id { get; set; }
    public string? Label { get; set; }

    public ICollection<Subject> Subjects { get; set; } = [];
    public ICollection<Adjective> Adjectives { get; set; } = [];
  }
}