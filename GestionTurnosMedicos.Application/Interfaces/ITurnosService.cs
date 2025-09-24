using GestionTurnosMedicos.Domain.DTOs;
using System.Threading.Tasks;

namespace GestionTurnosMedicos.Application.Interfaces
{
    public interface ITurnosService
    {
        Task<TurnoDto> GetByIdAsync(int id);
        Task<int> CreateAsync(TurnoDto turno);
        Task UpdateAsync(TurnoDto turno);
    }
}