using HIV_CARE.Repositories.ThienTTT;
using HIV_CARE.Repositories.ThienTTT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIV_CARE.Services.ThienTTT
{
    public class DoctorPhatNhService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DoctorPhatNhService() => _unitOfWork ??= new UnitOfWork();


        public async Task<List<DoctorPhatNh>> GetAllAsync()
        {
            return await _unitOfWork.DoctorPhatNhRepository.GetAllAsync();
        }
        public async Task<DoctorPhatNh> GetByIdAsync(int id)
        {
            return await _unitOfWork.DoctorPhatNhRepository.GetByIdAsync(id);
        }
        public async Task<int> CreateAsync(DoctorPhatNh doctorPhatNh)
        {
            return await _unitOfWork.DoctorPhatNhRepository.CreateAsync(doctorPhatNh);
        }
    }
}
