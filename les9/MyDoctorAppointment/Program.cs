using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Domain.Enums;
using MyDoctorAppointment.Service.Interfaces;
using MyDoctorAppointment.Service.Services;

namespace MyDoctorAppointment
{
    public class DoctorAppointment
    {
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _patientService;
        private readonly IAppointmentService _appointmentService;
        record DRec(string Name, string Surname, byte Experiance, DoctorTypes doctorType);
        record PRec(string Name, string Surname, IllnessTypes illnessType);
        public DoctorAppointment()
        {
            _doctorService = new DoctorService();
            _patientService = new PatientService();
            _appointmentService = new AppointmentService();
        }
        public void Menu()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            bool done = false;
            while (!done)
            {
                Console.Clear();
                Console.WriteLine("З яким джерелом інформації будем працювати:");
                Console.WriteLine("1. Json-файл.");
                Console.WriteLine("2. Xml-файл.");
                Console.WriteLine("3. Вихід.");
                Console.WriteLine("Ваш вибір.");
                ConsoleKeyInfo cki = Console.ReadKey(true);
                switch (cki.Key.ToString())
                {
                    case "D1":
                        _doctorService.SetJsonFile();
                        _patientService.SetJsonFile();
                        _appointmentService.SetJsonFile();                        
                        done = true;
                        break;
                    case "D2":
                        _doctorService.SetXmlFile();
                        _patientService.SetXmlFile();
                        _appointmentService.SetXmlFile();
                        done = true;
                        break;
                    case "D3":
                        return;
                }
            }

            List<DRec> doctors = new()
            {
                new DRec("Джозеф","Гудман", 15,DoctorTypes.Dentist),
                new DRec("Гарольд","Лансер", 20,DoctorTypes.Dermatologist),
                new DRec("Дан","Грисаро", 21,DoctorTypes.FamilyDoctor),
                new DRec("Том","Джонс", 25,DoctorTypes.Paramedic)
            };
            List<PRec> patients = new()
            {
                new PRec("Іван","Іванов", IllnessTypes.Ambulance),
                new PRec("Петро","Петров",IllnessTypes.DentalDiseas),
                new PRec("Василь","Василенко", IllnessTypes.EyeDisease),
                new PRec("Степан","Степаненко", IllnessTypes.Infection),
                new PRec("Тарас","Тарасенко", IllnessTypes.SkinDiseas)
            };                        

            var docs = _doctorService.GetFileType() == Constants.JsonFile ? _doctorService.GetAll() : _doctorService.GetAllXml();
            foreach (var doc in doctors)
            {
                if (!_doctorService.Get(doc.Surname))
                {
                    var newDoctor = new Doctor()
                    {
                        Name = doc.Name,
                        Surname = doc.Surname,
                        Experiance = doc.Experiance,
                        DoctorType = doc.doctorType
                    };
                    _doctorService.Create(newDoctor);
                }
            }            
            var pats = _patientService.GetFileType() == Constants.JsonFile ? _patientService.GetAll() : _patientService.GetAllXml();
            foreach (var pat in patients)
            {
                if (!_patientService.Get(pat.Surname))
                {
                    var newPatient = new Patient()
                    {
                        Name = pat.Name,
                        Surname = pat.Surname,
                        IllnessType = pat.illnessType
                    };
                    _patientService.Create(newPatient);
                }
            }           

            while (true)
            {
                Console.Clear();
                _appointmentService.ClearInput();
                Console.WriteLine("Перелік докторів: ");
                docs = _doctorService.GetFileType() == Constants.JsonFile ? _doctorService.GetAll() : _doctorService.GetAllXml();
                foreach (var doc in docs)
                    Console.Write("[" + doc.Id + "-" + doc.Surname + "] ");
                Console.WriteLine();

                Console.WriteLine("Перелік пацієнтів: ");
                pats = _patientService.GetFileType() == Constants.JsonFile ? _patientService.GetAll() : _patientService.GetAllXml();
                foreach (var pat in pats)
                    Console.Write("[" + pat.Id + "-" + pat.Surname + "] ");
                Console.WriteLine();

                Console.WriteLine("Перелік реєстрацій: ");
                var apps = _appointmentService.GetFileType() == Constants.JsonFile ? _appointmentService.GetAll() : _appointmentService.GetAllXml();
                foreach (var app in apps)
                    Console.Write("[" + app.Id + " док." + app.DoctorSurname + "-п." + app.PatientSurname + "] ");
                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine("Що будемо робити:");
                Console.WriteLine("1. Зареєструвати кліента до доктора.");
                Console.WriteLine("2. Відмінити реєстрацію.");
                Console.WriteLine("3. Вихід.");
                Console.WriteLine("Ваш вибір.");
                ConsoleKeyInfo cki = Console.ReadKey(true);
                switch (cki.Key.ToString())
                {
                    case "D1":                        
                        _appointmentService.EnterDoctor();
                        _appointmentService.EnterPatient();                        
                        _appointmentService.RegisterAppointment(_doctorService, _patientService);                        
                        break;
                    case "D2":
                        _appointmentService.EnterAppointment();
                        _appointmentService.UnRegisterAppointment(_appointmentService);                        
                        break;
                    case "D3":
                        return;
                }
            }
        }
    }
    public static class Program
    {
        public static void Main()
        {
            var doctorAppointment = new DoctorAppointment();
            doctorAppointment.Menu();
        }
    }
}