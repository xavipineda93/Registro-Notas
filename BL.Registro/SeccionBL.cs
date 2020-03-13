using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Registro
{
   public  class SeccionBL
    {
        Contexto _contexto;
        public BindingList<Seccion> ListaSecciones { get; set; }

        public SeccionBL()
        {
            _contexto = new Contexto();
            ListaSecciones = new BindingList<Seccion>();

        }

        public BindingList<Seccion > ObtenerSecciones()
        {
            _contexto.Secciones.Load();
            ListaSecciones = _contexto.Secciones.Local.ToBindingList();


            return ListaSecciones;
        }

      
    }
    public class Seccion
    {
        public int id { get; set; }
        public string Descripcion { get; set; }
    }
}
