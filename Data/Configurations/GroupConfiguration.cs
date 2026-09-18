using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ivanov_Denis_Evgenievich_KT_31_23.Models;

namespace Ivanov_Denis_Evgenievich_KT_31_23.Data.Configurations;

public class GroupConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.HasKey(g => g.GroupId);
        
        builder.HasOne(g => g.Specialty)
               .WithMany(s => s.Groups)
               .HasForeignKey(g => g.SpecialtyId)
               .OnDelete(DeleteBehavior.Cascade);

        // Seed data
        builder.HasData(
            new Group { GroupId = 1, Name = "КТ-31-23", Course = 3, SpecialtyId = 1, IsDeleted = false },
            new Group { GroupId = 2, Name = "КТ-32-23", Course = 3, SpecialtyId = 1, IsDeleted = false },
            new Group { GroupId = 3, Name = "ПИ-31-23", Course = 3, SpecialtyId = 2, IsDeleted = false }
        );
    }
}
