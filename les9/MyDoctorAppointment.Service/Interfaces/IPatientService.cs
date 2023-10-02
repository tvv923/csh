using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Service.ViewModels;

namespace MyDoctorAppointment.Service.Interfaces
{
    public interface IPatientService
    {
        Patient Create(Patient patient);
        IEnumerable<PatientViewModel> GetAll();
        List<PatientViewModel> GetAllXml();
        Patient? Get(int id);
        bool Get(string surname);
        bool Delete(int id);
        Patient Update(int id, Patient patient);
        public void SetJsonFile();
        public void SetXmlFile();
        public int GetFileType();
    }
}
