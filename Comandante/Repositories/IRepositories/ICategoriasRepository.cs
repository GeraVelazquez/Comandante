using Comandante.Model;
using System.Collections.Generic;

namespace Comandante.Repositories.IRepositories
{
    public interface ICategoriasRepository
    {
        bool CreateCategoria(Categorias DatosCategoria, out long Id, out string Msj);
        bool UpdateCategoria(Categorias DatosCategoria, out string Msj);
        bool Active(Categorias DatosCategoria, out string Msj);

        ICollection<Categorias> getCategoriasGral(long? IdCategoria, long IdUsuario);
        ICollection<Categorias> getCategoriasActivas(long? IdCategoria, long IdUsuario);
        Categorias getCategoria(long IdCategoria);
    }
}
