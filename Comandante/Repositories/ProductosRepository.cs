using Comandante.Infrastructure;
using Comandante.Model;
using Comandante.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Comandante.Repositories
{
    public class ProductosRepository : IProductosRepository
    {
        private readonly ComandanteDbContext dbContext;
        public ProductosRepository(ComandanteDbContext dbContext) => this.dbContext = dbContext;
        public bool Activo(Productos DatosProducto, out string Msj)
        {
            try
            {
                Productos Producto = getProductos(DatosProducto.IdProducto);
                Producto.Activo = DatosProducto.Activo;
                Producto.FechaModifico = DateTime.Now;
                Producto.IdUsuarioModifico = DatosProducto.IdUsuarioModifico;
                dbContext.Entry(Producto).State = EntityState.Modified;
                dbContext.SaveChanges();
                Msj = DatosProducto.Activo ? "El producto se ha activado con éxito" : "El producto se ha desactivado con éxito";
                return true;
            }
            catch (Exception ex)
            {
                Msj = ex.Message;
                return false;
            }
        }

        public bool Create(Productos DatosProducto, out long Id, out string Msj)
        {
            try
            {
                DatosProducto.FechaCreo = DateTime.Now;
                dbContext.Productos.Add(DatosProducto);
                dbContext.SaveChanges();
                Id = DatosProducto.IdCategoria;
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

        public bool Update(Productos DatosProducto, out string Msj)
        {
            try
            {
                DatosProducto.FechaModifico = DateTime.Now;
                Productos productos = getProductos(DatosProducto.IdProducto);
                productos = DatosProducto;
                dbContext.Entry(productos).State = EntityState.Modified;
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

        public Productos getProductos(long IdProducto) => dbContext.Productos.Where(x => x.IdProducto == IdProducto).FirstOrDefault();

        public ICollection<Productos> getProductosActivos(long IdUsuario, long? IdCategoria) => IdCategoria is null ? dbContext.Productos.Where(x => x.Activo && x.IdUsuarioCreo == IdUsuario).ToList() : dbContext.Productos.Where(x => x.Activo && x.IdUsuarioCreo == IdUsuario && x.IdCategoria == IdCategoria).ToList();

        public ICollection<Productos> getProductosGral(long IdUsuario, long? IdCategoria) => IdCategoria is null ? dbContext.Productos.Where(x => x.IdUsuarioCreo == IdUsuario).ToList() : dbContext.Productos.Where(x => x.IdUsuarioCreo == IdUsuario && x.IdCategoria == IdCategoria).ToList();
    }
}
