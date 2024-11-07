using Microsoft.EntityFrameworkCore;
using TiendaPruebaAPI.Interfaces;
using TiendaPruebaAPI.Models;


namespace TiendaPruebaAPI.Repositorio
{
    public class ProductosRepositoio : IProductosRepositoio
    {
        private readonly AppDbContext context;

        public ProductosRepositoio(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<bool> EditarProducto(Productos producto)
        {
            context.Update(producto);
            return await Save();
        }

        public async Task<bool> EliminarProducto(int prodId)
        {
            var prod = await context.Productos.FirstOrDefaultAsync(p => p.Id == prodId);

            context.Remove(prod);

            return await Save();
        }

        public async Task<bool> GuardarProducto(Productos producto)
        {
            context.Add(producto);
            return await Save();
        }

        public async Task<bool> ProductoExiste(int prodId)
        {
            var prodExiste = await context.Productos.AnyAsync(p => p.Id == prodId);

            return prodExiste;
        }

        public async Task<Productos> ObtenerProducto(int prodId)
        {
            var prod = await context.Productos.FirstOrDefaultAsync(p => p.Id == prodId);
            return prod;
        }

        public async Task<Productos> GetProducto(int prodId)
        {
            var prod = await context.Productos.FirstOrDefaultAsync(p => p.Id == prodId);
            return prod;
        }

        public async Task<List<Productos>> ListadoProductos()
        {
            var listado = await context.Productos.ToListAsync();
            return listado;
        }

        public async Task<bool> Save()
        {
            var saved = await context.SaveChangesAsync();

            return saved > 0 ? true : false;
        }
    }
}
