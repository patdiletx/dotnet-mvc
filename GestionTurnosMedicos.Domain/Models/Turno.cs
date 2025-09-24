namespace GestionTurnosMedicos.Domain.Models
{
    public class Turno
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public DateTime FechaHora { get; set; }
        public string Medico { get; set; }
        public string Especialidad { get; set; }
        public string Estado { get; set; } // Ej: "Programado", "Cancelado", "Completado"
    }
}