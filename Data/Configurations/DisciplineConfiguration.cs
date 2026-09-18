using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ivanov_Denis_Evgenievich_KT_31_23.Models;

namespace Ivanov_Denis_Evgenievich_KT_31_23.Data.Configurations;

public class DisciplineConfiguration : IEntityTypeConfiguration<Discipline>
{
    public void Configure(EntityTypeBuilder<Discipline> builder)
    {
        builder.HasKey(d => d.DisciplineId);
        
        // Seed data
        builder.HasData(
            new Discipline { DisciplineId = 1, Name = "Базы данных", IsDeleted = false },
            new Discipline { DisciplineId = 2, Name = "Программирование", IsDeleted = false }
        );
    }
}
