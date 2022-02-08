using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingSitter.Domain.Model;

public class BaseEntity
{
    public int Id { get; set; }
    public bool IsActive { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; set; }
    
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdatedAt { get; set; }
}

