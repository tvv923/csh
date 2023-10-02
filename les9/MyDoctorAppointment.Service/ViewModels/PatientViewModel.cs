using MyDoctorAppointment.Domain.Enums;

namespace MyDoctorAppointment.Service.ViewModels
{
    public class PatientViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? IllnessType { get; set; }
        public string? AdditionalInfo { get; set; }
        public string? Address { get; set; }
    }
}
