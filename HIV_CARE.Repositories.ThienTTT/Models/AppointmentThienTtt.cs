﻿// Models/AppointmentThienTtt.cs
using System;
using System.Collections.Generic;

namespace HIV_CARE.Repositories.ThienTTT.Models;

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
}