using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ParkingSitter.Domain.Model;

public class Users : BaseEntity
{
    public string? Name { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Cellphone { get; set; }

    public List<Parkings>? Parkings { get; set; }
}

public class UsersMap : IEntityTypeConfiguration<Users>
{
    public void Configure(EntityTypeBuilder<Users> builder)
    {
        builder.HasMany(p => p.Parkings);
    }
}

