using Comandante.Infrastructure;
using Comandante.Model;
using Comandante.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Comandante.Repositories
{
    public class CategoriasRepository : ICategoriasRepository
    {
        private readonly ComandanteDbContext dbContext;
        public CategoriasRepository(ComandanteDbContext dbContext) => this.dbContext = dbContext;
        public bool Active(Categorias DatosCategoria, out string Msj)
        {
            try
            {
                Categorias Categoria = getCategoria(DatosCategoria.IdCategoria);
                Categoria.Activo = DatosCategoria.Activo;
                Categoria.FechaModifico = DateTime.Now;
                Categoria.IdUsuarioModifico = DatosCategoria.IdUsuarioModifico;
                dbContext.Entry(Categoria).State = EntityState.Modified;
                dbContext.SaveChanges();
                Msj = DatosCategoria.Activo ? "La categoría se ha activado con éxito" : "La categpría se ha desactivado con éxito";
                return true;
            }
            catch (Exception ex)
            {
                Msj = ex.Message;
                return false;
            }
        }

        public bool CreateCategoria(Categorias DatosCategoria, out long Id, out string Msj)
        {
            try
            {
                DatosCategoria.FechaCreo = DateTime.Now;
                dbContext.Categorias.Add(DatosCategoria);
                dbContext.SaveChanges();
                Id = DatosCategoria.IdCategoria;
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

        public Categorias getCategoria(long IdCategoria) => dbContext.Categorias.Where(x => x.IdCategoria == IdCategoria).FirstOrDefault();

        public ICollection<Categorias> getCategoriasActivas(long? IdCategoria, long IdUsuario) => dbContext.Categorias.Where(x => x.Activo && x.IdCategoriaPadre == IdCategoria && x.IdUsuarioCreo == IdUsuario).ToList();

        public ICollection<Categorias> getCategoriasGral(long? IdCategoria, long IdUsuario) => dbContext.Categorias.Where(x => x.IdCategoriaPadre == IdCategoria && x.IdUsuarioCreo == IdUsuario).ToList();

        public bool UpdateCategoria(Categorias DatosCategoria, out string Msj)
        {
            try
            {
                DatosCategoria.FechaModifico = DateTime.Now;
                Categorias categoria = getCategoria(DatosCategoria.IdCategoria);
                categoria = DatosCategoria;
                dbContext.Entry(categoria).State = EntityState.Modified;
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
    }
}
