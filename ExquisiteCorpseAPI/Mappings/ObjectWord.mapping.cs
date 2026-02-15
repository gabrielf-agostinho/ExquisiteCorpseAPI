using ExquisiteCorpseAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExquisiteCorpseAPI.Mappings
{
  public class ObjectWordMapping : WordBaseMapping<ObjectWord>
  {
    public override void Configure(EntityTypeBuilder<ObjectWord> builder)
    {
      base.Configure(builder);
      builder.ToTable("objectWords");

      builder
        .HasOne(x => x.Language)
        .WithMany(x => x.ObjectWords)
        .HasForeignKey(x => x.LanguageId)
        .IsRequired()
        .OnDelete(DeleteBehavior.Cascade);
    }
  }
}