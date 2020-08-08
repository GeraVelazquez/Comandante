using AutoMapper;
using Comandante.DTO;
using Comandante.Model;

namespace Comandante.Mapper
{
    public class ComandanteMapper : Profile
    {
        public ComandanteMapper()
        {
            CreateMap<Categorias, CategoriasDTO>().ReverseMap();
            CreateMap<AreasServicio, AreasServicioDTO>().ReverseMap();
            CreateMap<Productos, ProductosDTO>().ReverseMap();
        }
    }
}
