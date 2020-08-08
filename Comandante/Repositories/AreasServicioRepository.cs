using Comandante.Infrastructure;
using Comandante.Model;
using Comandante.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comandante.Repositories
{
    public class AreasServicioRepository : IAreasServicioRepository
    {
        private readonly ComandanteDbContext dbContext;
        public AreasServicioRepository(ComandanteDbContext dbContext) => this.dbContext = dbContext;

        public bool Active(AreasServicio Datos, out string Msj)
        {
            try
            {
                AreasServicio Area = getAreasServicio(Datos.IdArea);
                Area.Activo = Datos.Activo;
                Area.FechaModifico = DateTime.Now;
                Area.IdUsuarioModifico = Datos.IdUsuarioModifico;
                dbContext.Entry(Area).State = EntityState.Modified;
                dbContext.SaveChanges();
                Msj = Datos.Activo ? "El área se ha activado con éxito" : "El área se ha desactivado con éxito";
                return true;
            }
            catch (Exception ex)
            {
                Msj = ex.Message;
                return false;
            }
        }

        public bool Create(AreasServicio Datos, out long Id, out string Msj)
        {
            try
            {
                Datos.FechaCreo = DateTime.Now;
                dbContext.AreasServicio.Add(Datos);
                dbContext.SaveChanges();
                Id = Datos.IdArea;
                Msj = "";
                return true;
            }
            catch (Exception ex)
            {
                Id = -1;
                Msj = ex.Message;
                return false;
            }
        }
        public bool Update(AreasServicio Datos, out string Msj)
        {
            try
            {
                Datos.FechaModifico = DateTime.Now;
                AreasServicio Area = getAreasServicio(Datos.IdArea);
                Area = Datos;
                dbContext.Entry(Area).State = EntityState.Modified;
                dbContext.SaveChanges();
                Msj = "Registro editado correctamente";
                return true;
            }
            catch (Exception ex)
            {
                Msj = ex.Message;
                return false;
            }
        }


        public AreasServicio getAreasServicio(long IdAreaServicio) => dbContext.AreasServicio.Where(x => x.IdArea == IdAreaServicio).FirstOrDefault();

        public ICollection<AreasServicio> getAreasServicioGral(long IdUsuario) => dbContext.AreasServicio.Where(x => x.IdUsuarioCreo == IdUsuario).ToList();

        public ICollection<AreasServicio> getAreasServicioActivos(long IdUsuario) => dbContext.AreasServicio.Where(x => x.IdUsuarioCreo == IdUsuario && x.Activo).ToList();
    }
}
