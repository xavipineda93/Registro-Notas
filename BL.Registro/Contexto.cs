using BL.Registro;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BL.Registro.AlumnosBL;
using static BL.Registro.CursosBL;
using static BL.Registro.SeccionBL;

namespace BL.Registro
{
   public class Contexto : DbContext 
    {
        public Contexto(): base("Notas")
        {    
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention> ();
            Database.SetInitializer(new DatosdeInicio());
        }

        public DbSet <Alumno> Alumnos { get; set; }
        public DbSet <Cursos> Curso { get; set; }
        public DbSet<Usuario > Usuarios { get; set; }
        public DbSet<Seccion> Secciones { get; set; }

    }

}

