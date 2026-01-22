using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prueba.Context;
using prueba.Models;

namespace prueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PaymentsController(AppDbContext context)
        {
            _context = context;
        }
        // POST /api/payments
        [HttpPost]
        public async Task<IActionResult> CreatePayment([FromBody] Dtos.CreatePaymentDto dto)
        {
            
            if (dto.Amount <= 0 || dto.Amount > 1500)
                return BadRequest("El monto debe ser mayor que 0 y menor o igual a 1500 Bs.");

            
            var customer = await _context.Customers
                .FirstOrDefaultAsync(c => c.CustomerCodigo == dto.CustomerId && c.IsActive);
            if (customer == null)
                return BadRequest("Cliente no válido");

            
            var category = await _context.ServiceCategories
                .FirstOrDefaultAsync(s => s.Name == dto.ServiceProvider && s.IsActive);
            if (category == null)
                return BadRequest("Categoría/Proveedor no válido");

            
            var payment = new Payment
            {
                CustomerCodigo = dto.CustomerId,
                ServiceProvider = dto.ServiceProvider,
                Amount = dto.Amount,
                Status = "pendiente",
                CreatedAt = DateTime.UtcNow
            };

            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();

           
            var response = new Dtos.PaymentResponseDto
            {
                PaymentId = payment.PaymentId,
                ServiceProvider = payment.ServiceProvider,
                Amount = payment.Amount,
                Status = payment.Status,
                CreatedAt = payment.CreatedAt
            };

            return Ok(response);
        }

        // GET /api/payments?customerCodigo=XXX
        [HttpGet]
        public async Task<IActionResult> GetPayments([FromQuery] string customerCodigo)
        {
            if (string.IsNullOrEmpty(customerCodigo))
                return BadRequest("Debe proporcionar customerCodigo");

            var payments = await _context.Payments
                .Where(p => p.CustomerCodigo == customerCodigo)
                .Select(p => new Dtos.PaymentResponseDto
                {
                    PaymentId = p.PaymentId,
                    ServiceProvider = p.ServiceProvider,
                    Amount = p.Amount,
                    Status = p.Status,
                    CreatedAt = p.CreatedAt
                })
                .ToListAsync();

            return Ok(payments);
        }
    }
}
