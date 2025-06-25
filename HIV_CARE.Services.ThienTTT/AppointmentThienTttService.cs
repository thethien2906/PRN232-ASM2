// AppiontmentThienTttService.cs
using HIV_CARE.Repositories.ThienTTT.Models;
using HIV_CARE.Repositories.ThienTTT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIV_CARE.Services.ThienTTT
{
    public class AppointmentThienTttService : IAppointmentThienTttService
    {
        //private readonly AppointmentThienTttRepository _appointmentThienTttRepository;

        //public AppointmentThienTttService() => _appointmentThienTttRepository ??=
        //new AppointmentThienTttRepository();
        private readonly IUnitOfWork _unitOfWork;
        public AppointmentThienTttService() => _unitOfWork ??= new UnitOfWork();

        public async Task<int> CreateAsync(AppointmentThienTtt appointmentThienTtt)
        {
            return await _unitOfWork.AppointmentThienTttRepository.CreateAsync(appointmentThienTtt);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var termAppointment = await _unitOfWork.AppointmentThienTttRepository.GetByIdAsync(id);
            if (termAppointment != null)
            {
                return await _unitOfWork.AppointmentThienTttRepository.RemoveAsync(termAppointment);
            }
            return false;
        }

        public async Task<List<AppointmentThienTtt>> GetAllAsync()
        {
            return await _unitOfWork.AppointmentThienTttRepository.GetAllAsync();
        }

        public async Task<AppointmentThienTtt> GetByIdAsync(int id)
        {
            return await _unitOfWork.AppointmentThienTttRepository.GetByIdAsync(id);
        }

        public async Task<List<AppointmentThienTtt>> SearchAsync(int id, DateTime date, int doctorId)
        {
            return await _unitOfWork.AppointmentThienTttRepository.SearchAsync(
                id == 0 ? null : id,
                date == DateTime.MinValue ? null : date,
                doctorId == 0 ? null : doctorId);
        }

        public async Task<List<AppointmentThienTtt>> SearchAsync(int currentPage, int pageSize)
        {
            var paginationResult = await _unitOfWork.AppointmentThienTttRepository.GetAllAsync(currentPage, pageSize);
            return paginationResult.Items;
        }

        public async Task<List<AppointmentThienTtt>> SearchAsync(int id, DateTime date, int doctorId, int currentPage, int pageSize)
        {
            return await _unitOfWork.AppointmentThienTttRepository.SearchAsync(id, date, doctorId, currentPage, pageSize);
        }

        public async Task<int> UpdateAsync(AppointmentThienTtt appointmentThienTtt)
        {
            return await _unitOfWork.AppointmentThienTttRepository.UpdateAsync(appointmentThienTtt);
        }
    }
}