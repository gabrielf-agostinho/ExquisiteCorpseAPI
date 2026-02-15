using ExquisiteCorpseAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExquisiteCorpseAPI.Mappings
{
  public class AdjectiveMapping : WordBaseMapping<Adjective>
  {
    public override void Configure(EntityTypeBuilder<Adjective> builder)
    {
      base.Configure(builder);
      builder.ToTable("adjectives");

      builder
        .HasOne(x => x.Language)
        .WithMany(x => x.Adjectives)
        .HasForeignKey(x => x.LanguageId)
        .OnDelete(DeleteBehavior.Cascade);
    }
  }
}