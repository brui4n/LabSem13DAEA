using System.ComponentModel.DataAnnotations;

namespace LabSem13DAEA.Models
{
    public class InstructorModel
    {
        [Key]
        public int IdInstructor { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Especialidad { get; set; }
        public string Email { get; set; }
        public bool Activo { get; set; }

        // Relación: Un instructor puede dictar muchos cursos
        public ICollection<CursoModel>? Cursos { get; set; }
    }
}
