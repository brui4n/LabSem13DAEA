using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabSem13DAEA.Models
{
    public class PagoModel
    {
        [Key]
        public int IdPago { get; set; }

        // Llave foránea hacia Matricula
        public int IdMatricula { get; set; }
        [ForeignKey("IdMatricula")]
        public MatriculaModel? Matricula { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Monto { get; set; }
        public DateTime FechaPago { get; set; }
        public string MetodoPago { get; set; }
        public string EstadoPago { get; set; }
    }
}
