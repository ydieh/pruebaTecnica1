using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prueba.Models
{
    public class ServiceCategory
    {
        
            [Key]
            [Column("service_category_id")]
            public long ServiceCategoryId { get; set; } 

            [Required]
            [Column("name")]
            [MaxLength(100)]
            public string Name { get; set; }

            [Column("description")]
            public string? Description { get; set; }

            [Column("is_active")]
            public bool IsActive { get; set; } = true;

            
            public ICollection<Payment> Payments { get; set; }
        
    }
}
