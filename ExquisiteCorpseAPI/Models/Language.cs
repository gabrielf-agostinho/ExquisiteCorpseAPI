namespace ExquisiteCorpseAPI.Models
{
  public class Language
  {
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Acronym { get; set; }
    public bool IsActive { get; set; } = true;

    public ICollection<Subject> Subjects { get; set; } = [];
    public ICollection<Verb> Verbs { get; set; } = [];
    public ICollection<ObjectWord> ObjectWords { get; set; } = [];
    public ICollection<Adjective> Adjectives { get; set; } = [];
  }
}