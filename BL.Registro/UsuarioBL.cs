using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Registro
{
    class UsuarioBL
    {
        Contexto _contexto;
        public BindingList<Usuario > ListaUsuarios { get; set; }

        public UsuarioBL()
        {
            _contexto = new Contexto();
            ListaUsuarios = new BindingList<Usuario >();


        }

        public BindingList<Usuario > ObtenerUsuarios()
        {
            _contexto.Usuarios.Load();
            ListaUsuarios = _contexto.Usuarios.Local.ToBindingList();


            return ListaUsuarios;
        }
    }

    public class Usuario
    {
        public int id { get; set; }
        public string Nombre { get; set; }
        public string  Contrasena { get; set; }
    }
}
   