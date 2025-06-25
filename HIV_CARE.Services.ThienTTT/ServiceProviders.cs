using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIV_CARE.Services.ThienTTT
{
    public interface IServiceProviders
    {
        SystemUserAccountService UserAccountService { get; }
        IAppointmentThienTttService AppointmentThienTttService { get; }
        DoctorPhatNhService DoctorPhatNhService { get; }
    }

    public class ServiceProviders : IServiceProviders
    {
        private SystemUserAccountService _systemUserAccountService;
        private IAppointmentThienTttService _appointmentThienTttService;
        private DoctorPhatNhService _doctorPhatNhService;

        public ServiceProviders() { }

        public SystemUserAccountService UserAccountService
        {
            get { return _systemUserAccountService ??= new SystemUserAccountService(); }
        }

        public IAppointmentThienTttService AppointmentThienTttService
        {
            get { return _appointmentThienTttService ??= new AppointmentThienTttService(); }
        }

        public DoctorPhatNhService DoctorPhatNhService
        {
            get { return _doctorPhatNhService ??= new DoctorPhatNhService(); }
        }
    }
}