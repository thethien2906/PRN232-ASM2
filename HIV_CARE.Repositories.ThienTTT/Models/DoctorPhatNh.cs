﻿// Models/DoctorPhatNh.cs
using System;
using System.Collections.Generic;

namespace HIV_CARE.Repositories.ThienTTT.Models;

public partial class DoctorPhatNh
{
    public int DoctorsPhatNhid { get; set; }

    public string LicenseNumber { get; set; }

    public string Specialization { get; set; }

    public int ExperienceYears { get; set; }

    public decimal ConsultationFee { get; set; }

    public bool IsAvailable { get; set; }

    public int MaxPatientsPerDay { get; set; }

    public TimeOnly WorkingStartTime { get; set; }

    public TimeOnly WorkingEndTime { get; set; }

    public DateTime AvailableStartDate { get; set; }

    public DateTime AvailableEndDate { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string ModifiedBy { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<AppointmentThienTtt> AppointmentThienTtts { get; set; } = new List<AppointmentThienTtt>();
}