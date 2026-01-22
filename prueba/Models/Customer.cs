using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prueba.Models
{
    
    public class Customer
    {
        [Key]
        [Column("customer_id")]
        public long CustomerId { get; set; } 

        [Required]
        [Column("first_name")]
        [MaxLength(150)]
        public string FirstName { get; set; }

        [Required]
        [Column("last_name")]
        [MaxLength(150)]
        public string LastName { get; set; }

        [Required]
        [Column("document_number")]
        [MaxLength(50)]
        public string DocumentNumber { get; set; }

        [Column("is_active")]
        public bool IsActive { get; set; } = true;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        [Column("customer_codigo")]
        [MaxLength(150)]
        public string CustomerCodigo { get; set; }

        public ICollection<Payment> Payments { get; set; }
    }
}
