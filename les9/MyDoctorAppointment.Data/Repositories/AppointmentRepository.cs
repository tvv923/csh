
using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Domain.Entities;

namespace MyDoctorAppointment.Data.Repositories
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        public override string Path { get; set; }
        public override int LastId { get; set; }
        public override int MyFileType { get; set; }
        public AppointmentRepository()
        {
            dynamic result = ReadFromAppSettings();
            Path = result.Database.Appointments.Path;
            LastId = result.Database.Appointments.LastId;
        }
        public override void ShowInfo(Appointment appointmentr)
        {
            Console.WriteLine(); 
        }
        protected override void SaveLastId()
        {
            dynamic result = ReadFromAppSettings();
            result.Database.Appointments.LastId = LastId;
            File.WriteAllText(Constants.AppSettingsPath, result.ToString());
        }

        public override void SetPath()
        {
            dynamic result = ReadFromAppSettings();
            Path = MyFileType == Constants.JsonFile ? result.Database.Appointments.Path : result.Database.Appointments.PathXml;
        }
    }
}
