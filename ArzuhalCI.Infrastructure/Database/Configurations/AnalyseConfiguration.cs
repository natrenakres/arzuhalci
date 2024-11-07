using ArzuhalCI.Domain.Entries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArzuhalCI.Infrastructure.Database.Configurations;

public class AnalyseConfiguration : IEntityTypeConfiguration<Analyse>
{
    public void Configure(EntityTypeBuilder<Analyse> builder)
    {
        builder.HasKey(a => a.Id);

        builder.ComplexProperty(a => a.AnalyseProps,
            propertyBuilder =>
            {
                propertyBuilder.Property(x => x.Mood).HasColumnName("mood");
                propertyBuilder.Property(x => x.Negative).HasColumnName("negative");
                propertyBuilder.Property(x => x.Subject).HasColumnName("subject");
                propertyBuilder.Property(x => x.Summary).HasColumnName("summary");
                propertyBuilder.Property(x => x.SentimentScore).HasColumnName("sentiment_score");
            });
    }
}