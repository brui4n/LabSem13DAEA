using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabSem13DAEA.Models
{
    public class CursoModel
    {
        [Key]
        public int IdCurso { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Precio { get; set; }
        public int DuracionHoras { get; set; }

        // Llave foránea hacia Instructor
        public int IdInstructor { get; set; }
        [ForeignKey("IdInstructor")]
        public InstructorModel? Instructor { get; set; }

        public bool Activo { get; set; }

        // Relación: Un curso puede tener muchas matrículas
        public ICollection<MatriculaModel>? Matriculas { get; set; }
    }
}
