﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WAConexionBaseDatosCsharp.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class bdnotasEntities : DbContext
    {
        public bdnotasEntities()
            : base("name=bdnotasEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Alumno> Alumno { get; set; }
        public virtual DbSet<Curso> Curso { get; set; }
        public virtual DbSet<especialidad> especialidad { get; set; }
        public virtual DbSet<NOTAS> NOTAS { get; set; }
        public virtual DbSet<PAGOS> PAGOS { get; set; }
    
        public virtual int sp_MantRegistrarAlumno(string nomAlumno, string apeAlumno, string idEsp, string proce)
        {
            var nomAlumnoParameter = nomAlumno != null ?
                new ObjectParameter("NomAlumno", nomAlumno) :
                new ObjectParameter("NomAlumno", typeof(string));
    
            var apeAlumnoParameter = apeAlumno != null ?
                new ObjectParameter("ApeAlumno", apeAlumno) :
                new ObjectParameter("ApeAlumno", typeof(string));
    
            var idEspParameter = idEsp != null ?
                new ObjectParameter("IdEsp", idEsp) :
                new ObjectParameter("IdEsp", typeof(string));
    
            var proceParameter = proce != null ?
                new ObjectParameter("Proce", proce) :
                new ObjectParameter("Proce", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_MantRegistrarAlumno", nomAlumnoParameter, apeAlumnoParameter, idEspParameter, proceParameter);
        }
    
        public virtual int sp_MantEliminarAlumno(string idAlumno)
        {
            var idAlumnoParameter = idAlumno != null ?
                new ObjectParameter("IdAlumno", idAlumno) :
                new ObjectParameter("IdAlumno", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_MantEliminarAlumno", idAlumnoParameter);
        }
    }
}