using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Domain.Entities;

namespace MyDoctorAppointment.Data.Repositories
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        public override string Path { get; set; }
        public override int LastId { get; set; }
        public override int MyFileType { get; set; }
        public PatientRepository()
        {
            dynamic result = ReadFromAppSettings();
            Path = result.Database.Patients.Path;
            LastId = result.Database.Patients.LastId;
        }
        public override void ShowInfo(Patient patient)
        {
            Console.WriteLine(); 
        }
        protected override void SaveLastId()
        {
            dynamic result = ReadFromAppSettings();
            result.Database.Patients.LastId = LastId;
            File.WriteAllText(Constants.AppSettingsPath, result.ToString());
        }

        public override void SetPath()
        {
            dynamic result = ReadFromAppSettings();
            Path = MyFileType == Constants.JsonFile ? result.Database.Patients.Path : result.Database.Patients.PathXml;
        }
    }
}
