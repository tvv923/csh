using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Service.ViewModels;

namespace MyDoctorAppointment.Service.Interfaces
{
    public interface IDoctorService
    {
        Doctor Create(Doctor doctor);
        IEnumerable<DoctorViewModel> GetAll();
        List<DoctorViewModel> GetAllXml();
        Doctor? Get(int id);
        bool Get(string surname);
        bool Delete(int id);
        Doctor Update(int id, Doctor doctor);
        public void SetJsonFile();
        public void SetXmlFile();
        public int GetFileType();
    }
}
