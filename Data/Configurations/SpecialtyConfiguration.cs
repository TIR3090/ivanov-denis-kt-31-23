using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ivanov_Denis_Evgenievich_KT_31_23.Models;

namespace Ivanov_Denis_Evgenievich_KT_31_23.Data.Configurations;

public class SpecialtyConfiguration : IEntityTypeConfiguration<Specialty>
{
    public void Configure(EntityTypeBuilder<Specialty> builder)
    {
        builder.HasKey(s => s.SpecialtyId);
        
        // Seed data
        builder.HasData(
            new Specialty { SpecialtyId = 1, Title = "Информационные системы и технологии", Code = "09.03.02" },
            new Specialty { SpecialtyId = 2, Title = "Прикладная информатика", Code = "09.03.03" }
        );
    }
}
