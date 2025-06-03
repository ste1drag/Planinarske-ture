using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reviewing.Domain.Entities;
using Reviewing.Domain.ValueObjects;

namespace Reviewing.Infrastructure.Persistence.EntityConfigurations
{
    class ReviewEntityConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.ToTable("Reviews");
            builder.HasKey(review => review.Id);
            builder.Property(review => review.Id)
                .ValueGeneratedOnAdd()
                .IsRequired()
                .UseHiLo("orderseq");
            builder.Property(review => review.UserId)
                .IsRequired();
            builder.Property(review => review.TourId)
                .IsRequired();
            builder.Property(review => review.Title)
                .IsRequired()
                .HasMaxLength(ReviewValidationConstants.MaxTitleLength);
            builder.Property(review => review.Comment)
                .HasMaxLength(ReviewValidationConstants.MaxCommentLength);
            builder.Property(review => review.Difficulty)
                .HasConversion<int?>();
            builder.Property(review => review.Score)
                .HasConversion(
                    v => v == null ? (int?)null : v.Value,
                    v => v == null ? null : new Score(v));
            builder.Property(review => review.CreatedDate)
            .IsRequired();
            builder.Property(review => review.UpdatedDate)
                .IsRequired();
        }
    }
}
