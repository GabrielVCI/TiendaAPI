using AutoMapper;
using TiendaPruebaAPI.Data;
using TiendaPruebaAPI.Models;

namespace TiendaPruebaAPI.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Configuración de mapeo entre ProductoDTO y Productos
            CreateMap<ProductoDTO, Productos>();
            CreateMap<Productos, ProductoDTO>();
        }
    }
}
