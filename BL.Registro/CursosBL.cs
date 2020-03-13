using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Registro
{
   public  class CursosBL
    {
        Contexto _contexto;
        public BindingList<Cursos> ListaCurso { get; set; }

        public CursosBL()
        {
            _contexto = new Contexto();
            ListaCurso = new BindingList<Cursos>();


        }

        public BindingList<Cursos > ObtenerCurso()
        {
            _contexto.Curso.Load();
            ListaCurso = _contexto.Curso.Local.ToBindingList();


            return ListaCurso;
        }
    }

    public class Cursos
    {
        public int id { get; set; }
        public string Descripcion { get; set; }
    }
}
