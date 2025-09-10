using AutoMapper;
using GestionPedidosAPI.Data;
using GestionPedidosAPI.DTO.LineasPedido;
using GestionPedidosAPI.DTO.Pedidos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Linq;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestionPedidosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PedidosController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // GET: api/Pedidos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PedidoRequestResponse>>> GetPedidos()
        {
            return await _context.Pedidos.Include(p => p.LineasPedido).Select(p => _mapper.Map<PedidoRequestResponse>(p)).ToListAsync();
        }

        // GET: api/Pedidos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PedidoRequestResponse>> GetPedido(int id)
        {
            var pedido = await _context.Pedidos.Include(p => p.LineasPedido).FirstOrDefaultAsync(p => p.ID == id);

            if (pedido == null)
            {
                return NotFound();
            }

            return _mapper.Map<PedidoRequestResponse>(pedido);
        }

        // PUT: api/Pedidos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Pedido>> PutPedido(int id, PedidoRequestResponse pedidoRequest,
            UserManager<Usuario> userManager)
        {

            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var pedido = _context.Pedidos.Include(p => p.LineasPedido).FirstOrDefault(p => p.ID == id);

                if (pedido == null)
                {
                    return NotFound();
                }

                string idUsuario = User.Claims.First(x => x.Type == "UserID").Value;

                //TODO : salir del método si el usuario no se encuentra
                var usuario = await userManager.FindByIdAsync(idUsuario);

                pedido.Cliente = pedidoRequest.Cliente;
                pedido.EntregaMax = pedidoRequest.EntregaMax;
                pedido.Estado = Estado.Creado;
                pedido.Modificado = DateTime.Now;
                pedido.ModificadoPorID = idUsuario;
                crearEditarLineasPedido(idUsuario, id, pedidoRequest.LineasPedido, pedido.LineasPedido);

                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                return Ok(pedidoRequest);
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }

        }

        // POST: api/Pedidos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Taller, Admin")]
        public async Task<ActionResult> PostPedido([FromBody] PedidoRequestResponse pedidoRequest,
            UserManager<Usuario> userManager)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                if (_context.Pedidos == null)
                {
                    return Problem("La tabla Pedidos es null.");
                }

                string idUsuario = User.Claims.First(x => x.Type == "UserID").Value;

                //TODO : salir del método si el usuario no se encuentra
                var usuario = await userManager.FindByIdAsync(idUsuario);

                Pedido nuevoPedido = new Pedido
                {
                    Cliente = pedidoRequest.Cliente,
                    EntregaMax = pedidoRequest.EntregaMax,
                    Estado = Estado.Creado,
                    Creado = DateTime.Now,
                    CreadoPorID = idUsuario
                };

                _context.Pedidos.Add(nuevoPedido);
                await _context.SaveChangesAsync();

                _context.LineasPedido.AddRange(crearEditarLineasPedido(idUsuario, nuevoPedido.ID, pedidoRequest.LineasPedido, null));
                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                return Ok();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
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

        private ICollection<LineaPedido> crearEditarLineasPedido(string idUsuario, int idPedido, ICollection<LineaPedidoRequestResponse> lineasPedidoRequest, ICollection<LineaPedido>? lineasPedido)
        {
            ICollection<LineaPedido> nuevaLineasPedido = new List<LineaPedido>();
            Boolean nuevoPedido = lineasPedido == null;

            foreach (LineaPedidoRequestResponse lineaPedidoRequest in lineasPedidoRequest)
            {
                // Nuevo pedido
                if (nuevoPedido)
                {
                    LineaPedido nuevaLinea = new LineaPedido
                    {
                        IDPedido = idPedido,
                        Articulo = lineaPedidoRequest.Articulo,
                        Cantidad = lineaPedidoRequest.Cantidad,
                        Tinta = lineaPedidoRequest.Tinta,
                        SituacionGrabacion = lineaPedidoRequest.SituacionGrabacion,
                        Creado = DateTime.Now,
                        CreadoPorID = idUsuario
                    };

                    nuevaLineasPedido.Add(nuevaLinea);
                }
                else // editar pedido
                {
                    var lineaPedido = lineasPedido.FirstOrDefault(lp => lp.ID == lineaPedidoRequest.Id);

                    if (lineaPedido != null) // editar linea existente
                    {
                        lineaPedido.Articulo = lineaPedidoRequest.Articulo;
                        lineaPedido.Cantidad = lineaPedidoRequest.Cantidad;
                        lineaPedido.Tinta = lineaPedidoRequest.Tinta;
                        lineaPedido.SituacionGrabacion = lineaPedidoRequest.SituacionGrabacion;
                        lineaPedido.Modificado = DateTime.Now;
                        lineaPedido.ModificadoPorID = idUsuario;
                    }
                    else // nueva linea
                    {
                        LineaPedido nuevaLinea = new LineaPedido
                        {
                            IDPedido = idPedido,
                            Articulo = lineaPedidoRequest.Articulo,
                            Cantidad = lineaPedidoRequest.Cantidad,
                            Tinta = lineaPedidoRequest.Tinta,
                            SituacionGrabacion = lineaPedidoRequest.SituacionGrabacion,
                            Creado = DateTime.Now,
                            CreadoPorID = idUsuario
                        };
                        lineasPedido.Add(nuevaLinea);
                    }
                }

            }

            // Si se edita un pedido, eliminar las lineas que no están en el request
            if (!nuevoPedido)
            {
                var idsLineasPedidoRequest = lineasPedidoRequest.Select(lpr => lpr.Id).ToList();

                var lineasPedidoEliminar = lineasPedido.Where(lp => !idsLineasPedidoRequest.Contains(lp.ID)).ToList();

                if (lineasPedidoEliminar.Any())
                {
                    _context.LineasPedido.RemoveRange(lineasPedidoEliminar);
                    _context.SaveChanges();
                }

                return null;
            }
            else
            {
                return nuevaLineasPedido;
            }

        }
    }
}
