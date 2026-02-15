using ExquisiteCorpseAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExquisiteCorpseAPI.Mappings
{
  public class SubjectMapping : WordBaseMapping<Subject>
  {
    public override void Configure(EntityTypeBuilder<Subject> builder)
    {
      base.Configure(builder);
      builder.ToTable("subjects");

      builder
        .HasOne(x => x.Language)
        .WithMany(x => x.Subjects)
        .HasForeignKey(x => x.LanguageId)
        .IsRequired()
        .OnDelete(DeleteBehavior.Cascade);

      builder
        .HasOne(x => x.Gender)
        .WithMany(x => x.Subjects)
        .IsRequired()
        .HasForeignKey(x => x.GenderId);
    }
  }
}