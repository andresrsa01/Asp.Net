﻿using System.Collections.Generic;
using System.Web.Mvc;
using ent = Asp.Net_MVC.Models;
using data = Aplicacion.Entidad;
using app = Aplicacion.Aplicacion;
using AutoMapper;
using map = Asp.Net_MVC.Mapa;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace Asp.Net_MVC.Controllers
{
    public class CategoriaController : Controller
    {
        public CategoriaController()
        {
            map.Mapear.CrearMapaCategoria();
        }
        // GET: Categoria
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Categorias()
        {
            ViewBag.Message = "Registrar categoria.";

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Categorias(ent.Categoria entidad)
        {
            var _entidad = Mapper.Map<ent.Categoria, data.Categoria>(entidad);
            await new app.Categoria().Registrar(_entidad);
            return RedirectToAction("ListarCategorias");
        }

        public async Task<ActionResult> ModificarCategorias(int id)
        {
            ViewBag.Message = "Modificar categoria.";
            data.Categoria listar = await new app.Categoria().TraerUnoPorId(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<data.Categoria, ent.Categoria>());
            var mapper = config.CreateMapper();
            ent.Categoria cate = mapper.Map<data.Categoria, ent.Categoria>(listar);
            return View(cate);
        }

        [HttpPost]
        public async Task<ActionResult> ModificarCategorias(ent.Categoria entidad)
        {
            var _entidad = Mapper.Map<ent.Categoria, data.Categoria>(entidad);
            await new app.Categoria().Modificar(_entidad);
            return RedirectToAction("ListarCategorias");
        }

        public async Task<ActionResult> EliminarCategorias(int id)
        {
            ViewBag.Message = "Eliminar categoria.";
            data.Categoria listar = await new app.Categoria().TraerUnoPorId(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<data.Categoria, ent.Categoria>());
            var mapper = config.CreateMapper();
            ent.Categoria cate = mapper.Map<data.Categoria, ent.Categoria>(listar);
            return View(cate);
        }

        [HttpPost]
        public async Task<ActionResult> EliminarCategorias(ent.Categoria entidad)
        {
            data.Categoria listar = await new app.Categoria().TraerUnoPorId(entidad.ID_Categoria);
            await new app.Categoria().Eliminar(listar);
            return RedirectToAction("ListarCategorias");
        }

        public async Task<ActionResult> DetalleCategorias(int id)
        {
            ViewBag.Message = "Eliminar categoria.";
            data.Categoria listar = await new app.Categoria().TraerUnoPorId(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<data.Categoria, ent.Categoria>());
            var mapper = config.CreateMapper();
            ent.Categoria cate = mapper.Map<data.Categoria, ent.Categoria>(listar);
            return View(cate);
        }

        public async Task<ActionResult> ListarCategorias()
        {
            IEnumerable<data.Categoria> listar = await new app.Categoria().TraerTodo();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<data.Categoria, ent.Categoria>());
            var mapper = config.CreateMapper();
            IEnumerable<ent.Categoria> cate = mapper.Map<IEnumerable<data.Categoria>, IEnumerable<ent.Categoria>>(listar);
            return View(cate);
        }

        public async Task<ActionResult> BuscarCategorias()
        {
            IEnumerable<data.Categoria> listar = await new app.Categoria().TraerTodo();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<data.Categoria, ent.Categoria>());
            var mapper = config.CreateMapper();
            IEnumerable<ent.Categoria> cate = mapper.Map<IEnumerable<data.Categoria>, IEnumerable<ent.Categoria>>(listar);
            return View(cate);
        }

        [HttpPost]
        public async Task<ActionResult> BuscarCategorias(string Nombre)
        {
            IEnumerable<data.Categoria> listar;
            if (Nombre != string.Empty)
            {
                listar = await new app.Categoria().Buscar(Nombre);
            }
            else
            {
                listar = await new app.Categoria().TraerTodo();
            }

            var config = new MapperConfiguration(cfg => cfg.CreateMap<data.Categoria, ent.Categoria>());
            var mapper = config.CreateMapper();
            IEnumerable<ent.Categoria> cate = mapper.Map<IEnumerable<data.Categoria>, IEnumerable<ent.Categoria>>(listar);
            return View(cate);
        }

        public async Task<ActionResult> CategoriasServicio()
        {

            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("http://localhost:8082/api/Categoria");
            IEnumerable<data.Categoria> cate = JsonConvert.DeserializeObject<IEnumerable<data.Categoria>>(json);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<data.Categoria, ent.Categoria>());
            var mapper = config.CreateMapper();
            IEnumerable<ent.Categoria> catelist = mapper.Map<IEnumerable<data.Categoria>, IEnumerable<ent.Categoria>>(cate);
            return View(catelist);
        }

        public ActionResult CategoriasServicioDos()
        {
            return View();
        }

        public ActionResult RegistrarCategoriaServicio()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> RegistrarCategoriaServicio(ent.Categoria entidad)
        {
            var httpClient = new HttpClient();
            HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("http://localhost:8082/api/Categoria", entidad);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("CategoriasServicio");
            }
            return RedirectToAction("Error");
        }

        public async Task<ActionResult> ModificarCategoriaServicio(int id)
        {
            ViewBag.Message = "Modificar categoria.";
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("http://localhost:8082/api/Categoria/" + id);
            data.Categoria cate = JsonConvert.DeserializeObject<data.Categoria>(json);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<data.Categoria, ent.Categoria>());
            var mapper = config.CreateMapper();
            ent.Categoria catelist = mapper.Map<data.Categoria, ent.Categoria>(cate);
            return View(catelist);
        }

        [HttpPost]
        public async Task<ActionResult> ModificarCategoriaServicio(ent.Categoria entidad)
        {

            var httpClient = new HttpClient();
            HttpResponseMessage responseMessage = await httpClient.PutAsJsonAsync("http://localhost:8082/api/Categoria", entidad);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("CategoriasServicio");
            }
            return RedirectToAction("Error");
        }

        public async Task<ActionResult> EliminarCategoriaServicio(int id)
        {
            ViewBag.Message = "Modificar categoria.";
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("http://localhost:8082/api/Categoria/" + id);
            data.Categoria cate = JsonConvert.DeserializeObject<data.Categoria>(json);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<data.Categoria, ent.Categoria>());
            var mapper = config.CreateMapper();
            ent.Categoria catelist = mapper.Map<data.Categoria, ent.Categoria>(cate);
            return View(catelist);
        }

        [HttpPost]
        public async Task<ActionResult> EliminarCategoriaServicio(ent.Categoria entidad)
        {

            var httpClient = new HttpClient();
            HttpResponseMessage responseMessage = await httpClient.DeleteAsync("http://localhost:8082/api/Categoria/"+ entidad.ID_Categoria.ToString());
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("CategoriasServicio");
            }
            return RedirectToAction("Error");
        }

        public async Task<ActionResult> TraerTodoInnerJoinCateProd()
        {
            IEnumerable<data.CategoriaProducto> listar = await new app.Categoria().TraerInnerJoinCateProd();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<data.CategoriaProducto, ent.CategoriaProducto>());
            var mapper = config.CreateMapper();
            IEnumerable<ent.CategoriaProducto> cate = mapper.Map<IEnumerable<data.CategoriaProducto>, IEnumerable<ent.CategoriaProducto>>(listar);
            return View(cate);
        }
    }
}