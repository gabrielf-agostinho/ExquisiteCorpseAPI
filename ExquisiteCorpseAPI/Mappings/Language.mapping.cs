using ExquisiteCorpseAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExquisiteCorpseAPI.Mappings
{
  public class LanguageMapping : IEntityTypeConfiguration<Language>
  {
    public void Configure(EntityTypeBuilder<Language> builder)
    {
      builder.ToTable("languages");
      builder.HasKey(x => x.Id);
      builder.Property(x => x.Id).ValueGeneratedOnAdd();
      builder.Property(x => x.Name).IsRequired();
      builder.Property(x => x.Acronym).IsRequired();
      builder.HasIndex(x => x.Acronym).IsUnique();

      builder
        .HasMany(x => x.Subjects)
        .WithOne(x => x.Language)
        .HasForeignKey(x => x.LanguageId)
        .IsRequired()
        .OnDelete(DeleteBehavior.Cascade);

      builder
        .HasMany(x => x.Verbs)
        .WithOne(x => x.Language)
        .HasForeignKey(x => x.LanguageId)
        .IsRequired()
        .OnDelete(DeleteBehavior.Cascade);

      builder
        .HasMany(x => x.ObjectWords)
        .WithOne(x => x.Language)
        .HasForeignKey(x => x.LanguageId)
        .IsRequired()
        .OnDelete(DeleteBehavior.Cascade);

      builder
        .HasMany(x => x.Adjectives)
        .WithOne(x => x.Language)
        .HasForeignKey(x => x.LanguageId)
        .IsRequired()
        .OnDelete(DeleteBehavior.Cascade);
    }
  }
}