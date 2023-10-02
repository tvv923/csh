using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Data.Repositories;
using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Service.Extentions;
using MyDoctorAppointment.Service.Interfaces;
using MyDoctorAppointment.Service.ViewModels;

namespace MyDoctorAppointment.Service.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService()
        {
            _patientRepository = new PatientRepository();
        }
        public Patient Create(Patient patient)
        {
            return _patientRepository.Create(patient);
        }

        public bool Delete(int id)
        {
            return _patientRepository.Delete(id);
        }

        public Patient? Get(int id)
        {
            return _patientRepository.GetById(id);
        }

        public bool Get(string surname)
        {
            return _patientRepository.GetBySurname(surname) != null ? true : false;
        }

        public IEnumerable<PatientViewModel> GetAll()
        {
            var patients = _patientRepository.GetAll();
            var patientViewModels = patients.Select(x => x.ConvertTo());
            return patientViewModels;
        }

        public List<PatientViewModel> GetAllXml()
        {
            var patients = _patientRepository.GetAllXml();
            var patientsViewModels = patients.Select(x => x.ConvertTo()).ToList();
            return patientsViewModels;
        }

        public Patient Update(int id, Patient patient)
        {
            return _patientRepository.Update(id, patient);
        }

        public bool CanAdd(string surname)
        {
            return _patientRepository.GetBySurname(surname) == null ? true : false;
        }

        public void SetJsonFile()
        {
            _patientRepository.SetFileType(Constants.JsonFile);
        }

        public void SetXmlFile()
        {
            _patientRepository.SetFileType(Constants.XmlFile);
            _patientRepository.SetPath();
        }

        public int GetFileType()
        {
            return _patientRepository.GetFileType();
        }

    }
}
