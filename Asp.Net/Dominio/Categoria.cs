﻿using System.Collections.Generic;
using System.Threading.Tasks;
using ent = Data.Entidad;
using Data.Modelo;
using Data.Repositorio;
using System;
using System.Linq;

namespace Dominio
{
    /// <summary>
    /// Entity framework con CODE FIRST
    /// </summary>
    public class Categoria
    {
        Repositorio<ent.Categoria> _repositorio = new Repositorio<ent.Categoria>(new Modelo());

        public async Task Registrar(ent.Categoria entidad)
        {
            try
            {
                _repositorio.Adicionar(entidad);
                await _repositorio.Grabar();
            }
            catch (Exception ex)
            {
                throw new Exception("Error Registrar", ex.InnerException);
            }
        }

        public async Task<int> RegistrarID(ent.Categoria entidad)
        {
            try
            {
                _repositorio.Adicionar(entidad);
                await _repositorio.Grabar();
                return entidad.ID_Categoria;
            }
            catch (Exception ex)
            {
                throw new Exception("Error Registrar", ex.InnerException);
            }
        }

        public async Task Modificar(ent.Categoria entidad)
        {
            try
            {

                _repositorio.Modificar(entidad);
                await _repositorio.Grabar();
            }
            catch (Exception ex)
            {
                throw new Exception("Error Modificar", ex.InnerException);
            }
        }

        public async Task Eliminar(ent.Categoria entidad)
        {
            try
            {
                _repositorio.Eliminar(entidad);
                await _repositorio.Grabar();
            }
            catch (Exception ex)
            {
                throw new Exception("Error Eliminar", ex.InnerException);
            }
        }

        public async Task<IEnumerable<ent.Categoria>> Buscar(string Nombre)
        {
            try
            {
                return await _repositorio.Buscar(x => x.Nombre_Categoria == Nombre);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Buscar", ex.InnerException);
            }
        }

        public async Task<ent.Categoria> TraerUno(string Nombre)
        {
            try
            {
                return await _repositorio.TraerUno(x => x.Nombre_Categoria == Nombre);
            }
            catch (Exception ex)
            {
                throw new Exception("Error TraerUno", ex.InnerException);
            }
        }

        public async Task<ent.Categoria> TraerUnoPorId(int Id)
        {
            try
            {
                return await _repositorio.TraerUnoPorId(Id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error TraerUnoPorId", ex.InnerException);
            }
        }

        public async Task<IEnumerable<ent.Categoria>> TraerTodo()
        {
            try
            {
                return await _repositorio.TraerTodo();
            }
            catch (Exception ex)
            {
                throw new Exception("Error TraerTodo", ex.InnerException);
            }
        }

        public IEnumerable<ent.Categoria> TraerTodoDev()
        {
            try
            {
                return _repositorio.TraerTodoDev();
            }
            catch (Exception ex)
            {
                throw new Exception("Error TraerTodoDev", ex.InnerException);
            }
        }

        public async Task<IEnumerable<ent.CategoriaProducto>> TraerInnerJoinCateProd()
        {
            try
            {
                using (Modelo modelo = new Modelo())
                {
                    return await Task.Run(() =>
                    {
                        var query = from c in modelo.Categoria
                                    join p in modelo.Producto
                                    on c.ID_Categoria equals p.ID_Categoria
                                    select (new ent.CategoriaProducto()
                                    {
                                        ID_Categoria = c.ID_Categoria,
                                        Nombre_Categoria = c.Nombre_Categoria,
                                        ID_Producto = p.ID_Producto,
                                        Nombre_Producto = p.Nombre_Producto
                                    });
                        return query.ToList();
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en traer inner join", ex.InnerException);
            }
        }
    }
}
