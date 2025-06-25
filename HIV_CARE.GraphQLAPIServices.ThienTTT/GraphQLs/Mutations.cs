using HIV_CARE.Repositories.ThienTTT.Models;
using HIV_CARE.Services.ThienTTT;

namespace HIV_CARE.GraphQLAPIServices.ThienTTT.GraphQLs
{
    public class Mutations
    {
        private readonly IServiceProviders _serviceProvider;

        public Mutations(IServiceProviders serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<int> CreateAppointmentThienTtt(AppointmentThienTtt appointmentThienTtt)
        {
            try
            {
                var result = await _serviceProvider.AppointmentThienTttService.CreateAsync(appointmentThienTtt);

                return (int)result;
            }
            catch (Exception ex)
            {
            }

            return 0;
        }

        public async Task<int> UpdateAppointmentThienTtt(AppointmentThienTtt appointmentThienTtt)
        {
            try
            {
                var result = await _serviceProvider.AppointmentThienTttService.UpdateAsync(appointmentThienTtt);

                return (int)result;
            }
            catch (Exception ex)
            {

            }

            return 0;
        }

        public async Task<bool> DeleteAppointmentThienTtt(int id)
        {
            try
            {
                var result = await _serviceProvider.AppointmentThienTttService.DeleteAsync(id);

                return (bool)result;
            }
            catch (Exception ex)
            {
            }

            return false;
        }
    }
}
