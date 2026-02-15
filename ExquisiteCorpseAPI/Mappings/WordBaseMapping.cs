using ExquisiteCorpseAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExquisiteCorpseAPI.Mappings
{
  public abstract class WordBaseMapping<T> : IEntityTypeConfiguration<T> where T : WordBase
  {
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
      builder.HasKey(x => x.Id);
      builder.Property(x => x.Id).ValueGeneratedOnAdd();
      builder.Property(x => x.Text).IsRequired();
      builder.Property(x => x.Weight).IsRequired();
      builder.Property(x => x.IsActive).IsRequired();
      builder.Property(x => x.CreatedAt).IsRequired();
      builder.HasIndex(x => new { x.LanguageId, x.Text }).IsUnique();

      builder
        .HasOne(x => x.Language)
        .WithMany()
        .HasForeignKey(x => x.LanguageId)
        .IsRequired()
        .OnDelete(DeleteBehavior.Cascade);
    }
  }
}