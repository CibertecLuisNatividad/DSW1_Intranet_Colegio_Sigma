﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Proyecto_SistemaIntranet.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class SistemaIntranetEntities : DbContext
    {
        public SistemaIntranetEntities()
            : base("name=SistemaIntranetEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Acceso> Acceso { get; set; }
        public virtual DbSet<Apoderado> Apoderado { get; set; }
        public virtual DbSet<Calificacion> Calificacion { get; set; }
        public virtual DbSet<Carga_Academica> Carga_Academica { get; set; }
        public virtual DbSet<Curso> Curso { get; set; }
        public virtual DbSet<Evaluacion> Evaluacion { get; set; }
        public virtual DbSet<Grado> Grado { get; set; }
        public virtual DbSet<Grado_Has_Seccion> Grado_Has_Seccion { get; set; }
        public virtual DbSet<Horario> Horario { get; set; }
        public virtual DbSet<Matricula> Matricula { get; set; }
        public virtual DbSet<Relacion> Relacion { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Rol_has_Acceso> Rol_has_Acceso { get; set; }
        public virtual DbSet<Seccion> Seccion { get; set; }
        public virtual DbSet<TipoEvaluacion> TipoEvaluacion { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
    
        public virtual ObjectResult<usp_user_acceso_Result> usp_user_acceso(Nullable<int> idrol, Nullable<int> idusuario)
        {
            var idrolParameter = idrol.HasValue ?
                new ObjectParameter("idrol", idrol) :
                new ObjectParameter("idrol", typeof(int));
    
            var idusuarioParameter = idusuario.HasValue ?
                new ObjectParameter("idusuario", idusuario) :
                new ObjectParameter("idusuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<usp_user_acceso_Result>("usp_user_acceso", idrolParameter, idusuarioParameter);
        }
    
        public virtual ObjectResult<usp_Usuario_Acceso_Result> usp_Usuario_Acceso(Nullable<int> idrol)
        {
            var idrolParameter = idrol.HasValue ?
                new ObjectParameter("idrol", idrol) :
                new ObjectParameter("idrol", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<usp_Usuario_Acceso_Result>("usp_Usuario_Acceso", idrolParameter);
        }
    }
}
