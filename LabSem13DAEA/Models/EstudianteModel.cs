using System.ComponentModel.DataAnnotations;

namespace LabSem13DAEA.Models
{
    public class EstudianteModel
    {
        [Key]
        public int IdEstudiante { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool Activo { get; set; }

        // Relación: Un estudiante puede tener muchas matrículas
        public ICollection<MatriculaModel>? Matriculas { get; set; }
    }
}
