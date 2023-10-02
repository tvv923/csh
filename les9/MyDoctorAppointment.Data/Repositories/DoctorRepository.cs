using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Domain.Entities;

namespace MyDoctorAppointment.Data.Repositories
{
    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
    {
        public override string Path { get; set; }
        public override int LastId { get; set; }
        public override int MyFileType { get; set; }        
        public DoctorRepository()
        {
            dynamic result = ReadFromAppSettings();
            Path = result.Database.Doctors.Path;
            LastId = result.Database.Doctors.LastId;
        }        
        public override void ShowInfo(Doctor doctor)
        {
            Console.WriteLine(); 
        }
        protected override void SaveLastId()
        {
            dynamic result = ReadFromAppSettings();
            result.Database.Doctors.LastId = LastId;
            File.WriteAllText(Constants.AppSettingsPath, result.ToString());
        }

        public override void SetPath()
        {
            dynamic result = ReadFromAppSettings();
            Path = MyFileType == Constants.JsonFile ? result.Database.Doctors.Path : result.Database.Doctors.PathXml;
        }
    }
}
