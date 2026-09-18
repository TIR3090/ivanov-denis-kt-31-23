using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ivanov_Denis_Evgenievich_KT_31_23.Models;

namespace Ivanov_Denis_Evgenievich_KT_31_23.Data.Configurations;

public class GradeConfiguration : IEntityTypeConfiguration<Grade>
{
    public void Configure(EntityTypeBuilder<Grade> builder)
    {
        builder.HasKey(g => g.GradeId);
        
        builder.HasOne(g => g.Student)
               .WithMany(s => s.Grades)
               .HasForeignKey(g => g.StudentId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(g => g.Discipline)
               .WithMany(d => d.Grades)
               .HasForeignKey(g => g.DisciplineId)
               .OnDelete(DeleteBehavior.Cascade);

        // Seed data
        builder.HasData(
            new Grade { GradeId = 1, Value = 5, StudentId = 1, DisciplineId = 1 },
            new Grade { GradeId = 2, Value = 4, StudentId = 1, DisciplineId = 2 },
            new Grade { GradeId = 3, Value = 3, StudentId = 2, DisciplineId = 1 },
            new Grade { GradeId = 4, Value = 5, StudentId = 3, DisciplineId = 2 }
        );
    }
}
