﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net_MVC.Models
{
    public class CategoriaProducto
    {
        public int ID_Categoria { get; set; }

        public string Nombre_Categoria { get; set; }

        public int ID_Producto { get; set; }

        public string Nombre_Producto { get; set; }
    }
}
