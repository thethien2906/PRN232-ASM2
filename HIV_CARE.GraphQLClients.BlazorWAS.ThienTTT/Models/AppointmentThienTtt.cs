// HIV_CARE.GraphQLClients.BlazorWAS.ThienTTT/Models/AppointmentThienTtt.cs

#nullable disable
using System;
using System.Collections.Generic;

namespace HIV_CARE.GraphQLClients.BlazorWAS.ThienTTT.Models;

public partial class AppointmentThienTtt
{
    public int AppointmentsThienTttid { get; set; }

    public int DoctorsPhatNhid { get; set; }

    public string PatientName { get; set; }

    public DateTime AppointmentDate { get; set; }

    public TimeOnly AppointmentTime { get; set; }

    public int EstimatedDuration { get; set; }

    public string ConsultationType { get; set; }

    public int Priority { get; set; }

    public bool IsConfirmed { get; set; }

    public bool IsCompleted { get; set; }

    public bool IsAnonymous { get; set; }

    public decimal TotalFee { get; set; }

    public string Notes { get; set; }

    public string Status { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string ModifiedBy { get; set; }

    public virtual DoctorPhatNh DoctorsPhatNh { get; set; }

    public class AppointmentThienTttsGraphQLResponse
    {
        public List<AppointmentThienTtt> appointmentThienTtts { get; set; }
    }

    public class AppointmentThienTttGraphQLResponse
    {
        public AppointmentThienTtt appointmentThienTttById { get; set; }
    }

    public class UpdateAppointmentThienTttGraphQLResponse
    {
        public int updateAppointmentThienTtt { get; set; }
    }

    public class CreateAppointmentThienTttGraphQLResponse
    {
        public int createAppointmentThienTtt { get; set; }
    }

    public class DeleteAppointmentThienTttGraphQLResponse
    {
        public bool deleteAppointmentThienTtt { get; set; }
    }

}