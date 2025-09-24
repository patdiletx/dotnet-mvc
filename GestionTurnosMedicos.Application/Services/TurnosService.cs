using GestionTurnosMedicos.Domain.Interfaces;
using GestionTurnosMedicos.Domain.DTOs;
using GestionTurnosMedicos.Domain.Models;
using System;
using System.Threading.Tasks;
using GestionTurnosMedicos.Application.Interfaces;

namespace GestionTurnosMedicos.Application.Services
{
    public class TurnosService : ITurnosService
    {
        private readonly ITurnosRepository _turnosRepository;

        public TurnosService(ITurnosRepository turnosRepository)
        {
            _turnosRepository = turnosRepository;
        }

        public async Task<TurnoDto> GetByIdAsync(int id)
        {
            var turno = await _turnosRepository.GetByIdAsync(id);
            return new TurnoDto
            {
                Id = turno.Id,
                PacienteId = turno.PacienteId,
                FechaHora = turno.FechaHora,
                Medico = turno.Medico,
                Especialidad = turno.Especialidad,
                Estado = turno.Estado
            };
        }

        public async Task<int> CreateAsync(TurnoDto turnoDto)
        {
            // Validación de negocio: no se pueden agendar turnos fuera de horario (ej. 8 AM - 6 PM)
            if (turnoDto.FechaHora.Hour < 8 || turnoDto.FechaHora.Hour > 18)
                throw new ArgumentException("Los turnos solo se pueden agendar entre 8 AM y 6 PM.");

            var turno = new Turno
            {
                PacienteId = turnoDto.PacienteId,
                FechaHora = turnoDto.FechaHora,
                Medico = turnoDto.Medico,
                Especialidad = turnoDto.Especialidad,
                Estado = "Programado"
            };

            return await _turnosRepository.CreateAsync(turno);
        }

        public async Task UpdateAsync(TurnoDto turnoDto)
        {
            // Validación similar
            if (turnoDto.FechaHora.Hour < 8 || turnoDto.FechaHora.Hour > 18)
                throw new ArgumentException("Los turnos solo se pueden agendar entre 8 AM y 6 PM.");

            var turno = new Turno
            {
                Id = turnoDto.Id,
                PacienteId = turnoDto.PacienteId,
                FechaHora = turnoDto.FechaHora,
                Medico = turnoDto.Medico,
                Especialidad = turnoDto.Especialidad,
                Estado = turnoDto.Estado
            };

            await _turnosRepository.UpdateAsync(turno);
        }
    }
}