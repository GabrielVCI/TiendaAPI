using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TiendaPruebaAPI.Data;
using TiendaPruebaAPI.Interfaces;
using TiendaPruebaAPI.Models;

namespace TiendaPruebaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : Controller
    {
        private readonly IProductosRepositoio productoRepositorio;
        private readonly IMapper mapper;
     

        public ProductosController(IProductosRepositoio productoRepositorio, IMapper mapper)
        {
            this.productoRepositorio = productoRepositorio;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ProductoDTO>))]
        public async Task<IActionResult> ObtenerProductos()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productos = mapper.Map<List<ProductoDTO>>(await productoRepositorio.ListadoProductos());

            return Ok(productos);
        }

        [HttpGet("{ProductoId}")]
        [ProducesResponseType(200, Type = typeof(Productos))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> ObtenerProducto(int ProductoId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!await productoRepositorio.ProductoExiste(ProductoId))
            {
                return StatusCode(404);
            }

            var prod = mapper.Map<ProductoDTO>(await productoRepositorio.GetProducto(ProductoId));

            return Ok(prod);
        }

        [HttpGet("obtenerProductoPorId")]
        public async Task<IActionResult> ObtenerProductoFiltro([FromQuery] int ProductoId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
             
            var producto = await productoRepositorio.GetProducto(ProductoId);

            if (producto is null)
            {
                return StatusCode(404);
            }

            return Ok(producto);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GuardarProducto([FromBody] ProductoDTO productoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (productoDTO is null)
            {
                return BadRequest();
            } 
  

            var productoModel = mapper.Map<Productos>(productoDTO); 

            if (!await productoRepositorio.GuardarProducto(productoModel))
            {
                return StatusCode(500);
            }

            return Ok();
        }

        [HttpPut("{ProductoId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> EditarProducto([FromBody] ProductoDTO producto, int ProductoId)
        {
            if (producto is null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!await productoRepositorio.ProductoExiste(ProductoId))
            {
                return NotFound();
            } 
            var prodAEditar = mapper.Map<Productos>(producto);

            if (!await productoRepositorio.EditarProducto(prodAEditar))
            {
                return BadRequest(ModelState);
            }
            return Ok();
        }

        [HttpDelete("{ProductoId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> EliminarProducto(int ProductoId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!await productoRepositorio.ProductoExiste(ProductoId))
            {
                return NotFound();
            }

            if (!await productoRepositorio.EliminarProducto(ProductoId))
            {
                return BadRequest();
            }

            return Ok();

        }
    }
}
