using System.ComponentModel.DataAnnotations.Schema;

namespace Luche.Domain.Entities
{
    [Table("product")]
    public class Product
    {
        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Category { get; set; } = null!;
        public string? Brand { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
