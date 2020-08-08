using Comandante.Model;
using System.Collections.Generic;

namespace Comandante.Repositories.IRepositories
{
    public interface IProductosRepository
    {
        bool Create(Productos DatosProducto, out long Id, out string Msj);
        bool Update(Productos DatosProducto, out string Msj);
        bool Activo(Productos DatosProducto, out string Msj);

        ICollection<Productos> getProductosGral(long IdUsuario, long? IdCategoria);
        ICollection<Productos> getProductosActivos(long IdUsuario, long? IdCategoria);
        Productos getProductos(long IdProducto);


    }
}
