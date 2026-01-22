using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace prueba.Models
{

    public class Payment
    {
        [Key]
        [Column("payment_id")]
        public long PaymentId { get; set; }

        [Required]
        [Column("customer_codigo")]
        [MaxLength(150)]
        public string CustomerCodigo { get; set; }

        [ForeignKey("CustomerCodigo")]
        public Customer Customer { get; set; }

        [Required]
        [Column("service_provider")]
        [MaxLength(100)]
        public string ServiceProvider { get; set; }

        [Required]
        [Column("amount")]
        [Range(0.01, 1500)]
        public decimal Amount { get; set; }

        [Required]
        [Column("status")]
        [MaxLength(30)]
        public string Status { get; set; } = "pendiente";

        [Required]
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey("ServiceProvider")]
        public ServiceCategory ServiceCategory { get; set; }
    }
}
