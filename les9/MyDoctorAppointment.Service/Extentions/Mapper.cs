using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Domain.Enums;
using MyDoctorAppointment.Service.ViewModels;

namespace MyDoctorAppointment.Service.Extentions
{
    public static class Mapper
    {
        public static DoctorViewModel ConvertTo(this Doctor doctor)
        {
            if (doctor == null)
                return null;

            string doctorType = string.Empty;

            doctorType = doctor.DoctorType switch
            {
                DoctorTypes.Dentist => "Dentist",
                DoctorTypes.Dermatologist => "Dermatologist",
                DoctorTypes.FamilyDoctor => "FamilyDoctor",
                DoctorTypes.Paramedic => "Paramedic",
                _ => "Unknown",
            };
            return new DoctorViewModel()
            {
                Id = doctor.Id,
                Name = doctor.Name,
                Surname = doctor.Surname,
                Email = doctor.Email,
                Phone = doctor.Phone,
                DoctorType = doctorType,
                Experiance = doctor.Experiance,
                Salary = doctor.Salary
            };
        }

        public static PatientViewModel ConvertTo(this Patient patient)
        {
            if (patient == null)
                return null;

            string illnessType = string.Empty;

            illnessType = patient.IllnessType switch
            {
                IllnessTypes.Ambulance => "Ambulance",
                IllnessTypes.Infection => "Infection",
                IllnessTypes.DentalDiseas => "DentalDiseas",
                IllnessTypes.EyeDisease => "EyeDisease",
                IllnessTypes.SkinDiseas => "SkinDiseas",
                _ => "Unknown",
            };
            return new PatientViewModel()
            {
                Id = patient.Id,
                Name = patient.Name,
                Surname = patient.Surname,
                Email = patient.Email,
                Phone = patient.Phone,
                IllnessType = illnessType,
                AdditionalInfo = patient.AdditionalInfo,
                Address = patient.Address
            };
        }

        public static AppointmentViewModel ConvertTo(this Appointment appointment)
        {
            if (appointment == null)
                return null;

            string doctorType = string.Empty;

            doctorType = appointment.Doctor.DoctorType switch
            {
                DoctorTypes.Dentist => "Dentist",
                DoctorTypes.Dermatologist => "Dermatologist",
                DoctorTypes.FamilyDoctor => "FamilyDoctor",
                DoctorTypes.Paramedic => "Paramedic",
                _ => "Unknown",
            };
            return new AppointmentViewModel()
            {
                Id = appointment.Id,
                PatientName = appointment.Patient.Name,
                PatientSurname = appointment.Patient.Surname,
                DoctorName = appointment.Doctor.Name,
                DoctorSurname = appointment.Doctor.Surname,
                DoctorType = doctorType
            };
        }
    }
}
