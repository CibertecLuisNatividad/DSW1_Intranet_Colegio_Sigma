//------------------------------------------------------------------------------
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
    
    public partial class usp_listaCalificacionxAlumno_Curso_Result
    {
        public int idcalificacion { get; set; }
        public string tituloEvaluacion { get; set; }
        public string rutaCalificacion { get; set; }
        public Nullable<decimal> notaCalificacion { get; set; }
        public string comentarioDocente { get; set; }
        public string comentarioAlumno { get; set; }
        public string periodoCalificacion { get; set; }
        public string estadoCalificacion { get; set; }
        public string Alumno { get; set; }
    }
}