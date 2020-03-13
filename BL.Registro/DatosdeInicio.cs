using BL.Registro;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Registro
{

public class DatosdeInicio : CreateDatabaseIfNotExists<Contexto > // Crea la base de datos si no existe 
{
    protected override void Seed(Contexto contexto) // Este metodo inicia los datos en la base de datos.
    {
        var usuarioAdmin1 = new Usuario();
        usuarioAdmin1.Nombre= "admin";
        usuarioAdmin1.Contrasena = "1234";
        contexto.Usuarios.Add(usuarioAdmin1);

        var usuarioAdmin2 = new Usuario();
        usuarioAdmin2.Nombre= "user";
        usuarioAdmin2.Contrasena  = "5678";
        contexto.Usuarios.Add(usuarioAdmin2);


            var curso1 = new Cursos();
            curso1.Descripcion = "Electricidad";
            contexto.Curso.Add(curso1);

            var curso2 = new Cursos();
            curso2.Descripcion = "Computacion";
            contexto.Curso.Add(curso2);

            var curso3 = new Cursos();
            curso3.Descripcion = "Reposteria";
            contexto.Curso.Add(curso3);

            var curso4 = new Cursos();
            curso4.Descripcion = "Mecanica";
            contexto.Curso.Add(curso4);





            var seccion1 = new Seccion();
            seccion1.Descripcion = "Seccion 1";
            contexto.Secciones.Add(seccion1);

            var seccion2 = new Seccion();
            seccion2.Descripcion = "Seccion 2";
            contexto.Secciones.Add(seccion2);






            base.Seed(contexto);    // Se envia a la base de datos
        





    }
}

}