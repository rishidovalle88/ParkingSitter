
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ParkingSitter.Domain.Model;
public class Transactions : BaseEntity
{
    public int ParkingId { get; set; }
    public string? LicensePlate { get; set; }
    public DateTime? DateEntry { get; set; }
    public string? ImageEntry { get; set; }
    public DateTime? DateExit { get; set; }
    public string? ImageExit { get; set; }

    public Parkings? Parkings { get; set; }
}

public class TransactionsMap : IEntityTypeConfiguration<Transactions>
{
    public void Configure(EntityTypeBuilder<Transactions> builder)
    {
        builder
            .HasOne(p => p.Parkings);
    }
}
