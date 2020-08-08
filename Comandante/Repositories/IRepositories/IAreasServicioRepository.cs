using Comandante.Model;
using System.Collections.Generic;

namespace Comandante.Repositories.IRepositories
{
    interface IAreasServicioRepository
    {
        bool Create(AreasServicio Datos, out long Id, out string Msj);
        bool Update(AreasServicio Datos, out string Msj);
        bool Active(AreasServicio Datos, out string Msj);

        ICollection<AreasServicio> getAreasServicioGral(long IdUsuario);
        ICollection<AreasServicio> getAreasServicioActivos(long IdUsuario);
        AreasServicio getAreasServicio(long IdAreaServicio);
    }
}
