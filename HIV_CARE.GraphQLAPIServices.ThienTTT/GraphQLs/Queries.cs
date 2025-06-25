using HIV_CARE.Repositories.ThienTTT.Models;
using HIV_CARE.Services.ThienTTT;

namespace HIV_CARE.GraphQLAPIServices.ThienTTT.GraphQLs
{
    public class Queries
    {
        private readonly IServiceProviders _serviceProvider;

        public Queries(IServiceProviders serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public async Task<List<AppointmentThienTtt>> GetAppointmentThienTtts()
        {
            try
            {
                var result = await _serviceProvider.AppointmentThienTttService.GetAllAsync();
                return result ?? new List<AppointmentThienTtt>();
            }
            catch (Exception ex)
            {
                return new List<AppointmentThienTtt>();
            }
        }
        public async Task<AppointmentThienTtt> GetAppointmentThienTttById(int id)
        {
            try
            {
                var result = await _serviceProvider.AppointmentThienTttService.GetByIdAsync(id);
                return result ?? new AppointmentThienTtt();
            }
            catch (Exception ex)
            {
                return new AppointmentThienTtt();

            }

        }
        public async Task<List<DoctorPhatNh>> GetDocterPhatNhs()
        {
            try
            {
                var result = await _serviceProvider.DoctorPhatNhService.GetAllAsync();
                return result ?? new List<DoctorPhatNh>();
            }
            catch (Exception ex)
            {
                return new List<DoctorPhatNh>();
            }
        }
    }
}
