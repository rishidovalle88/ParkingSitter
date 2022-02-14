using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ParkingSitter.Domain.Model;
public class Parkings : BaseEntity
{
    public string? Name { get; set; }
    public string? Bio { get; set; }
    public string? Street { get; set; }
    public int Number { get; set; }
    public string? District { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }

    public int UserForeignKey { get; set; }
    public List<Users>? Users { get; set; }
    public List<Transactions>? Transactions { get; set; }
}


public class ParkingsMap : IEntityTypeConfiguration<Parkings>
{
    public void Configure(EntityTypeBuilder<Parkings> builder)
    {
        builder
            .HasMany(p => p.Users)
            .WithMany(b => b.Parkings);

        builder
            .HasMany(b => b.Transactions)
            .WithOne(b => b.Parkings);
    }
}