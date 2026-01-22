using System.ComponentModel.DataAnnotations;

namespace prueba.Dtos
{
    public class CreatePaymentDto
    {
        [Required]
        public String CustomerId { get; set; }

        [Required]
        public string ServiceProvider { get; set; }

        [Required]
        [Range(0.01, 1500, ErrorMessage = "Amount must be <= 1500 Bs.")]
        public decimal Amount { get; set; }
    }
}
