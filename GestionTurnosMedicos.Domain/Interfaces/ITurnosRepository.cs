using GestionTurnosMedicos.Domain.Models;
using System.Threading.Tasks;

namespace GestionTurnosMedicos.Domain.Interfaces
{
    public interface ITurnosRepository
    {
        Task<Turno> GetByIdAsync(int id);
        Task<int> CreateAsync(Turno turno);
        Task UpdateAsync(Turno turno);
    }
}