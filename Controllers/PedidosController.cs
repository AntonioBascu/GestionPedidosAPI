using GestionPedidosAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestionPedidosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PedidosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Pedidos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedido>>> GetPedidos()
        {
            return await _context.Pedidos.ToListAsync();
        }

        // GET: api/Pedidos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> GetPedido(int id)
        {
            var Pedido = await _context.Pedidos.FindAsync(id);

            if (Pedido == null)
            {
                return NotFound();
            }

            return Pedido;
        }

        // PUT: api/Pedidos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedido(int id, Pedido Pedido)
        {
            if (id != Pedido.ID)
            {
                return BadRequest();
            }

            _context.Entry(Pedido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(await _context.Pedidos.ToListAsync());
        }

        // POST: api/Pedidos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pedido>> PostPedido(Pedido Pedido)
        {
            if (_context.Pedidos == null)
            {
                return Problem("La tabla Pedidos es null.");
            }
            _context.Pedidos.Add(Pedido);
            await _context.SaveChangesAsync();

            return Ok(await _context.Pedidos.ToListAsync());
        }

        // DELETE: api/Pedidos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedido(int id)
        {
            var Pedido = await _context.Pedidos.FindAsync(id);
            if (Pedido == null)
            {
                return NotFound();
            }

            _context.Pedidos.Remove(Pedido);
            await _context.SaveChangesAsync();

            return Ok(await _context.Pedidos.ToListAsync());
        }

        private bool PedidoExists(int id)
        {
            return _context.Pedidos.Any(e => e.ID == id);
        }
    }
}
