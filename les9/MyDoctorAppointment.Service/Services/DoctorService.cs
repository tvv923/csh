using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Data.Repositories;
using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Service.Extentions;
using MyDoctorAppointment.Service.Interfaces;
using MyDoctorAppointment.Service.ViewModels;

namespace MyDoctorAppointment.Service.Services 
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService()
        {
            _doctorRepository = new DoctorRepository();
        }
        public Doctor Create(Doctor doctor)
        {
            return _doctorRepository.Create(doctor);
        }

        public bool Delete(int id)
        {
            return _doctorRepository.Delete(id);
        }

        public Doctor? Get(int id)
        {
            return _doctorRepository.GetById(id);
        }

        public bool Get(string surname)
        {
            return _doctorRepository.GetBySurname(surname) != null ? true : false;
        }

        public IEnumerable<DoctorViewModel> GetAll()
        {
            var doctors = _doctorRepository.GetAll();
            var doctorViewModels = doctors.Select(x => x.ConvertTo());
            return doctorViewModels;
        }

        public List<DoctorViewModel> GetAllXml()
        {
            var doctors = _doctorRepository.GetAllXml();
            var doctorViewModels = doctors.Select(x => x.ConvertTo()).ToList();
            return doctorViewModels;
        }

        public Doctor Update(int id, Doctor doctor)
        {
            return _doctorRepository.Update(id, doctor);
        }

        public bool CanAdd(string surname)
        {
            return _doctorRepository.GetBySurname(surname) == null ? true : false;
            
        }

        public void SetJsonFile()
        {
            _doctorRepository.SetFileType(Constants.JsonFile);
        }

        public void SetXmlFile()
        {
            _doctorRepository.SetFileType(Constants.XmlFile);
            _doctorRepository.SetPath();
        }

        public int GetFileType()
        {
            return _doctorRepository.GetFileType();
        }

    }
}
