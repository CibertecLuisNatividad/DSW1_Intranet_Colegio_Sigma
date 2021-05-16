using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_SistemaIntranet.Models
{
    public class Menu
    {
        public int idacceso { get; set; }
        public string nombreAcceso { get; set; }
        public string rutaAcceso { get; set; }

        public string iconoAcceso { get; set; }
        public int estadoAcceso { get; set; }
        

    }
}