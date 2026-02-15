using ExquisiteCorpseAPI.Enums;
using ExquisiteCorpseAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExquisiteCorpseAPI.Mappings
{
  public class GenderMapping : IEntityTypeConfiguration<Gender>
  {
    public void Configure(EntityTypeBuilder<Gender> builder)
    {
      builder.ToTable("genders");
      builder.HasKey(x => x.Id);
      builder.Property(x => x.Id).ValueGeneratedOnAdd();
      builder.Property(x => x.Label).IsRequired();
      builder.HasIndex(x => x.Label).IsUnique();

      builder.HasData(new Gender { Id = (int)Genders.NEUTRAL, Label = "Neutral" });
      builder.HasData(new Gender { Id = (int)Genders.MALE, Label = "Male" });
      builder.HasData(new Gender { Id = (int)Genders.FEMALE, Label = "Female" });

      builder
        .HasMany(x => x.Subjects)
        .WithOne(x => x.Gender)
        .HasForeignKey(x => x.GenderId)
        .IsRequired();

      builder
        .HasMany(x => x.Adjectives)
        .WithOne(x => x.Gender)
        .HasForeignKey(x => x.GenderId)
        .IsRequired();
    }
  }
}