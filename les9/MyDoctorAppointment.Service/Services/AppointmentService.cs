using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Data.Repositories;
using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Service.Extentions;
using MyDoctorAppointment.Service.Interfaces;
using MyDoctorAppointment.Service.ViewModels;

namespace MyDoctorAppointment.Service.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public bool errorExists;
        public int patId;
        public int docId;
        public int appId;        

        public AppointmentService()
        {
            _appointmentRepository = new AppointmentRepository();
        }
        public Appointment Create(Appointment appointment)
        {
            return _appointmentRepository.Create(appointment);
        }

        public bool Delete(int id)
        {
            return _appointmentRepository.Delete(id);
        }

        public Appointment? Get(int id)
        {
            return _appointmentRepository.GetById(id);
        }

        public IEnumerable<AppointmentViewModel> GetAll()
        {
            var appointments = _appointmentRepository.GetAll();
            var appointmentViewModels = appointments.Select(x => x.ConvertTo());
            return appointmentViewModels;
        }

        public List<AppointmentViewModel> GetAllXml()
        {
            var appointments = _appointmentRepository.GetAllXml();
            var appointmentViewModels = appointments.Select(x => x.ConvertTo()).ToList();
            return appointmentViewModels;
        }

        public Appointment Update(int id, Appointment appointment)
        {
            return _appointmentRepository.Update(id, appointment);
        }

        public void ClearInput()
        {
            errorExists = false;
        }

        public void EnterPatient()
        {
            if (!errorExists)
                CheckInput(Constants.CheckPatient);
        }

        public void EnterDoctor()
        {
            if (!errorExists)
                CheckInput(Constants.CheckDoctor);
        }

        public void EnterAppointment()
        {
            if (!errorExists)
                CheckInput(Constants.CheckAppointment);
        }

        public void CheckInput(int inputType)
        {
            string? a1;
            if (inputType == Constants.CheckPatient) Console.WriteLine("Введіть номер пацієнта: ");
            else if (inputType == Constants.CheckDoctor) Console.WriteLine("Введіть номер доктора: ");
            else Console.WriteLine("Введіть реєстраційний номер: ");
            a1 = Console.ReadLine();
            errorExists = false;
            try
            {
                if (inputType == Constants.CheckPatient) patId = Convert.ToInt32(a1);
                else if (inputType == Constants.CheckDoctor) docId = Convert.ToInt32(a1);
                else appId = Convert.ToInt32(a1);
            }
            catch (Exception)
            {
                errorExists = true;
                Console.WriteLine("Помилка у числі");
                AfterShow();
            }
        }

        public void RegisterAppointment(IDoctorService doctorService, IPatientService patientService)
        {
            if (!errorExists)
            {                
                errorExists = (doctorService.Get(docId) == null || patientService.Get(patId) == null);
                if (errorExists)
                {
                    Console.WriteLine("Неіснуючий номер пацієнта або доктора. Реєстрація неможлива.");                    
                }
                else
                {
                    var newAppointment = new Appointment()
                    {
                        Doctor =  doctorService.Get(docId),
                        Patient = patientService.Get(patId)
                    };
                    _appointmentRepository.Create(newAppointment);
                    Console.WriteLine("Успішна реєстрація.");
                }
                AfterShow();
            }            
        }

        public void UnRegisterAppointment(IAppointmentService appointmentService)
        {
            if (!errorExists)
            {
                errorExists = appointmentService.Get(appId) == null;
                if (errorExists)
                {
                    Console.WriteLine("Неіснуючий реєстраційний номер. Зняття з реєстрація неможливе.");              
                }
                else
                {
                    _appointmentRepository.Delete(appId);
                    Console.WriteLine("Успішне зняття з реєстрації.");
                }
                AfterShow();
            }            
        }

        public void AfterShow()
        {            
            Console.WriteLine("Для продовження натисніть будь-яку клавішу.");
            Console.ReadKey(true);
        }

        public void SetJsonFile()
        {
            _appointmentRepository.SetFileType(Constants.JsonFile);
        }

        public void SetXmlFile()
        {
            _appointmentRepository.SetFileType(Constants.XmlFile);
            _appointmentRepository.SetPath();
        }

        public int GetFileType()
        {
            return _appointmentRepository.GetFileType();
        }
    }
}
