using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabSem13DAEA.Models
{
    public class MatriculaModel
    {
        [Key]
        public int IdMatricula { get; set; }

        // Llave foránea hacia Estudiante
        public int IdEstudiante { get; set; }
        [ForeignKey("IdEstudiante")]
        public EstudianteModel? Estudiante { get; set; }

        // Llave foránea hacia Curso
        public int IdCurso { get; set; }
        [ForeignKey("IdCurso")]
        public CursoModel? Curso { get; set; }

        public DateTime FechaMatricula { get; set; }
        public string Estado { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal MontoTotal { get; set; }

        // Relación: Una matrícula puede tener muchos pagos
        public ICollection<PagoModel>? Pagos { get; set; }
    }
}
