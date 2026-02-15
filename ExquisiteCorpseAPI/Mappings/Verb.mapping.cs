using ExquisiteCorpseAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExquisiteCorpseAPI.Mappings
{
  public class VerbMapping : WordBaseMapping<Verb>
  {
    public override void Configure(EntityTypeBuilder<Verb> builder)
    {
      base.Configure(builder);
      builder.ToTable("verbs");

      builder
        .HasOne(x => x.Language)
        .WithMany(x => x.Verbs)
        .HasForeignKey(x => x.LanguageId)
        .IsRequired()
        .OnDelete(DeleteBehavior.Cascade);
    }
  }
}