using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entidad
{
    public class CategoriaProducto
    {
        public int ID_Categoria { get; set; }

        public string Nombre_Categoria { get; set; }

        public int ID_Producto { get; set; }

        public string Nombre_Producto { get; set; }
    }
}
