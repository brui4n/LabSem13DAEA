using Microsoft.EntityFrameworkCore;

namespace LabSem13DAEA.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<InstructorModel> Instructores { get; set; }
        public DbSet<EstudianteModel> Estudiantes { get; set; }
        public DbSet<CursoModel> Cursos { get; set; }
        public DbSet<MatriculaModel> Matriculas { get; set; }
        public DbSet<PagoModel> Pagos { get; set; }
    }
}
