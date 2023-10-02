using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDoctorAppointment.Service.ViewModels
{
    public class AppointmentViewModel
    {
        public int Id { get; set; }
        public string PatientSurname { get; set; } = string.Empty;
        public string PatientName { get; set; } = string.Empty;
        public string DoctorSurname { get; set; } = string.Empty;
        public string DoctorName { get; set; } = string.Empty;
        public string? DoctorType { get; set; }
    }
}
