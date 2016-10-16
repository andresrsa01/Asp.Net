﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ent = Aplicacion.Entidad;

namespace Servicio.WebApi.Models
{
    public class CategoriaProducto
    {
        public ent.Categoria categoria { get; set; }
        public ent.Producto producto { get; set; }
    }

    public class ListaCategoriaProducto
    {
        public ent.Categoria categoria { get; set; }
        public List<ent.Producto> producto { get; set; }
    }
}