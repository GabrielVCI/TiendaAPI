using TiendaPruebaAPI.Models;

namespace TiendaPruebaAPI.Interfaces
{
    public interface IProductosRepositoio
    {
        Task<List<Productos>> ListadoProductos();
        Task<Productos> GetProducto(int productoId);
        Task<bool> EditarProducto(Productos producto);
        Task<bool> EliminarProducto(int productoId);
        Task<bool> Save();
        Task<bool> ProductoExiste(int productoId);
        Task<bool> GuardarProducto(Productos producto); 
    }
}
