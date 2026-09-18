using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ivanov_Denis_Evgenievich_KT_31_23.Models;

namespace Ivanov_Denis_Evgenievich_KT_31_23.Data.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(s => s.StudentId);
        
        builder.HasOne(s => s.Group)
               .WithMany(g => g.Students)
               .HasForeignKey(s => s.GroupId)
               .OnDelete(DeleteBehavior.Cascade);

        // Seed data
        builder.HasData(
            new Student { StudentId = 1, FirstName = "Денис", LastName = "Иванов", GroupId = 1, IsDeleted = false },
            new Student { StudentId = 2, FirstName = "Иван", LastName = "Петров", GroupId = 1, IsDeleted = false },
            new Student { StudentId = 3, FirstName = "Анна", LastName = "Смирнова", GroupId = 2, IsDeleted = false }
        );
    }
}
