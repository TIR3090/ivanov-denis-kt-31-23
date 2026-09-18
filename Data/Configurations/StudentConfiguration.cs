using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ivanov_Denis_Evgenievich_KT_31_23.Models;

namespace Ivanov_Denis_Evgenievich_KT_31_23.Data.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(s => s.Id);
        
        builder.HasOne(s => s.Group)
               .WithMany(g => g.Students)
               .HasForeignKey(s => s.GroupId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
