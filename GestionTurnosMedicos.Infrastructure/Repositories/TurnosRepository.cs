using GestionTurnosMedicos.Domain.Interfaces;
using GestionTurnosMedicos.Domain.Models;
using System.Threading.Tasks;

namespace GestionTurnosMedicos.Infrastructure.Repositories
{
    public class TurnosRepository : ITurnosRepository
    {
        // Simularemos la conexión a base de datos por ahora
        public async Task<Turno> GetByIdAsync(int id)
        {
            // Simulación: en un caso real, esto llamaría a un procedimiento almacenado en Oracle
            await Task.Delay(100); // Simula latencia
            return new Turno { Id = id, PacienteId = 1, FechaHora = DateTime.Now, Medico = "Dr. Smith", Especialidad = "Cardiología", Estado = "Programado" };
        }

        public async Task<int> CreateAsync(Turno turno)
        {
            // Simulación: en un caso real, esto llamaría a un procedimiento almacenado CREATE_TURNO_SP
            await Task.Delay(100);
            return 1; // Simula el ID del turno creado
        }

        public async Task UpdateAsync(Turno turno)
        {
            // Simulación: en un caso real, esto llamaría a un procedimiento almacenado UPDATE_TURNO_SP
            await Task.Delay(100);
        }
    }
}