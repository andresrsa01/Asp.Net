﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using ent = Aplicacion.Entidad;
using app = Aplicacion.Aplicacion;
using mod = Servicio.WebApi.Models;

namespace Servicio.WebApi.Controllers
{
    public class TransaccionController : ApiController
    {

        // POST: api/Transaccion
        public async Task<HttpResponseMessage> PostTransaccionCategoriaProducto(mod.CategoriaProducto cateprod)
        {
            try
            {
                ent.Categoria cate = cateprod.categoria;
                ent.Producto prod = cateprod.producto;
                await new app.TransaccionCategoriaProducto().RegistrarTransaccionCategoriaProducto(cate, prod);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, cate.Nombre_Categoria);
                return response;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [Route("api/PostListTransaccionCategoriaProducto")]
        public async Task<HttpResponseMessage> PostListTransaccionCategoriaProducto(mod.ListaCategoriaProducto cateprod)
        {
            try
            {
                ent.Categoria cate = cateprod.categoria;
                List<ent.Producto> prod = cateprod.producto;
                await new app.TransaccionCategoriaProducto().RegistrarListaTransaccionCategoriaProducto(cate, prod);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, cate.Nombre_Categoria);
                return response;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }

    }
}
