using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Service.Services;
using MyDoctorAppointment.Service.ViewModels;

namespace MyDoctorAppointment.Service.Interfaces
{
    public interface IAppointmentService
    {        
        Appointment Create(Appointment appointment);
        IEnumerable<AppointmentViewModel> GetAll();
        List<AppointmentViewModel> GetAllXml();
        Appointment? Get(int id);
        bool Delete(int id);
        Appointment Update(int id, Appointment appointment);
        public void ClearInput();
        public void EnterPatient();
        public void EnterDoctor();
        public void EnterAppointment();
        public void RegisterAppointment(IDoctorService doctorService, IPatientService patientService);
        public void UnRegisterAppointment(IAppointmentService appointmentService);
        public void SetJsonFile();
        public void SetXmlFile();
        public int GetFileType();
    }
}
