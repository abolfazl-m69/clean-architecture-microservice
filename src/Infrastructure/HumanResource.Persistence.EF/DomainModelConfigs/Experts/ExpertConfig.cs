using HumanResource.Domain.Experts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HumanResource.Persistence.EF.DomainModelConfigs.Experts;

public class ExpertConfig:IEntityTypeConfiguration<Expert>
{
    public void Configure(EntityTypeBuilder<Expert> builder)
    {
        builder.ToTable("Experts");
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Id).HasColumnName("Id").ValueGeneratedNever();
        builder.Property(r => r.FirstName).HasColumnName("FirstName").IsRequired();
        builder.Property(r => r.LastName).HasColumnName("LastName").IsRequired();
        builder.Property(r => r.CellPhone).HasColumnName("CellPhone").IsRequired();
    }
}