namespace prueba.Dtos
{
    public class PaymentResponseDto
    {
        public long PaymentId { get; set; }

        // Nombre del proveedor del servicio (o categoría)
        public string ServiceProvider { get; set; }

        // Monto pagado
        public decimal Amount { get; set; }

        // Estado del pago (pendiente, aprobado, etc.)
        public string Status { get; set; }

        // Fecha de creación del registro
        public DateTime CreatedAt { get; set; }
    }
}
