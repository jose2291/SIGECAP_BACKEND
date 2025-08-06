using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIGECAP2.API.Data;
using SIGECAP2.API.Models;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SIGECAP2.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LoginController(AppDbContext context)
        {
            _context = context;
        }

        // 🔹 POST: api/login (Inicio de sesión)
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Correo) || string.IsNullOrWhiteSpace(request.Contrasena))
            {
                return BadRequest(new { mensaje = "⚠️ Correo y contraseña son obligatorios" });
            }

            var empleado = await _context.Empleado.FirstOrDefaultAsync(e => e.Correo == request.Correo);

            if (empleado == null)
                return Unauthorized(new { mensaje = "❌ Usuario no encontrado" });

            if (!empleado.Activo)
                return Unauthorized(new { mensaje = "❌ Este empleado no está activo" });

            var contrasena = await _context.Contrasenas.FirstOrDefaultAsync(c => c.IdEmpleado == empleado.IdEmpleado);

            if (contrasena == null || contrasena.PasswordGenerada != request.Contrasena)
                return Unauthorized(new { mensaje = "❌ Contraseña incorrecta" });

            // ✅ Login correcto
            return Ok(new
            {
                mensaje = "✅ Login exitoso",
                numeroEmpleado = empleado.NumeroEmpleado,
                nombre = empleado.NombreCompleto
            });
        }

        // 🔹 PUT: api/login/cambiar-contrasena
        [HttpPut("cambiar-contrasena")]
        public async Task<IActionResult> CambiarContrasena([FromBody] CambiarContrasenaRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Correo) ||
                string.IsNullOrWhiteSpace(request.ContrasenaActual) ||
                string.IsNullOrWhiteSpace(request.NuevaContrasena))
            {
                return BadRequest(new { mensaje = "⚠️ Todos los campos son obligatorios" });
            }

            var empleado = await _context.Empleado.FirstOrDefaultAsync(e => e.Correo == request.Correo);
            if (empleado == null)
                return NotFound(new { mensaje = "❌ Usuario no encontrado" });

            if (!empleado.Activo)
                return Unauthorized(new { mensaje = "❌ Este empleado no está activo" });

            var contrasena = await _context.Contrasenas.FirstOrDefaultAsync(c => c.IdEmpleado == empleado.IdEmpleado);
            if (contrasena == null || contrasena.PasswordGenerada != request.ContrasenaActual)
                return Unauthorized(new { mensaje = "❌ Contraseña actual incorrecta" });

            // Validar la nueva contraseña (mínimo 8, 1 mayúscula, 1 número)
            var regex = new Regex(@"^(?=.*[A-Z])(?=.*\d).{8,}$");
            if (!regex.IsMatch(request.NuevaContrasena))
                return BadRequest(new { mensaje = "⚠️ La nueva contraseña debe tener 8 caracteres, 1 mayúscula y 1 número." });

            // Actualizar contraseña
            contrasena.PasswordGenerada = request.NuevaContrasena;
            await _context.SaveChangesAsync();

            return Ok(new { mensaje = "✅ Contraseña actualizada correctamente" });
        }
    }

    // DTO para login
    public class LoginRequest
    {
        public string Correo { get; set; }
        public string Contrasena { get; set; }
    }

    // DTO para cambio de contraseña
    public class CambiarContrasenaRequest
    {
        public string Correo { get; set; }
        public string ContrasenaActual { get; set; }
        public string NuevaContrasena { get; set; }
    }
}
