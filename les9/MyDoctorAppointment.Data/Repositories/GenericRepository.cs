using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Domain.Entities;
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace MyDoctorAppointment.Data.Repositories
{
    public abstract class GenericRepository<TSource> : IGenericRepository<TSource> where TSource : Auditable
    {
        public abstract string Path { get; set; }
        public abstract int LastId { get; set; }
        public abstract int MyFileType { get; set; }
        public TSource Create(TSource source)
        {
            source.Id = ++LastId;
            source.CreatedAt = DateTime.Now;
            if (MyFileType == Constants.JsonFile)
                File.WriteAllText(Path, JsonConvert.SerializeObject(GetAll().Append(source), Formatting.Indented));
            else 
                SaveToFile(GetAllXml().Append(source).ToList());
            SaveLastId();
            return source;
        }

        public bool Delete(int id)
        {
            if (GetById(id) is null)
                return false;
            if (MyFileType == Constants.JsonFile)
                File.WriteAllText(Path, JsonConvert.SerializeObject(GetAll().Where(x => x.Id != id), Formatting.Indented));
            else
                SaveToFile(GetAllXml().Where(x => x.Id != id).ToList());
            return true;
        }

        public IEnumerable<TSource> GetAll()
        {
            if (!File.Exists(Path))
            {
                File.WriteAllText(Path, "[]");
            }
            var json = File.ReadAllText(Path);
            if (string.IsNullOrWhiteSpace(json))
            {
                File.WriteAllText(Path, "[]");
                json = "[]";
            }
            return JsonConvert.DeserializeObject<List<TSource>>(json)!;
        }

        public List<TSource> GetAllXml()
        {
            CreateXmlFile();
            return LoadFromFile();
        }

        public TSource? GetById(int id)
        {
            if (MyFileType == Constants.JsonFile)
                return GetAll().FirstOrDefault(x => x.Id == id);
            else
                return GetAllXml().FirstOrDefault(x => x.Id == id);
        }

        public TSource? GetBySurname(string surname)
        {
            if (MyFileType == Constants.JsonFile)
                return GetAll().FirstOrDefault(x => x.Surname.ToUpper() == surname.ToUpper());
            else
                return GetAllXml().FirstOrDefault(x => x.Surname.ToUpper() == surname.ToUpper());
        }

        public TSource Update(int id, TSource source)
        {
            source.UpdatedAt = DateTime.Now;
            source.Id = id;
            if (MyFileType == Constants.JsonFile)
                File.WriteAllText(Path, JsonConvert.SerializeObject(GetAll().Select(x => x.Id == id ? source : x), Formatting.Indented));
            else                
                SaveToFile(GetAllXml().Select(x => x.Id == id ? source : x).ToList());
            return source;
        }

        public void CreateXmlFile()
        {
            if (!File.Exists(Path))
            {
                var source = new List<TSource>();
                SaveToFile(source);
                return;
            }
            var xml = File.ReadAllText(Path);
            if (string.IsNullOrWhiteSpace(xml))
            {
                var source = new List<TSource>();
                SaveToFile(source);
                return;
            }
        }

        public void SaveToFile(List<TSource> source)
        {
            using (var stream = new FileStream(Path, FileMode.Create))
            {
                var serializer = new XmlSerializer(typeof(List<TSource>));
                serializer.Serialize(stream, source);
            }
        }

        public List<TSource> LoadFromFile()
        {
            using (var stream = new FileStream(Path, FileMode.OpenOrCreate))
            {
                var serializer = new XmlSerializer(typeof(List<TSource>));
                if (serializer.Deserialize(stream) is List<TSource> source)
                {
                    return source;
                }
            }
            return new List<TSource>();
        }

        public void SetFileType(int myFileType)
        {
            MyFileType = myFileType;
        }

        public int GetFileType()
        {
            return MyFileType;
        }

        public abstract void ShowInfo(TSource source);
        public abstract void SetPath();
        protected abstract void SaveLastId();
        protected dynamic ReadFromAppSettings() => JsonConvert.DeserializeObject<dynamic>(File.ReadAllText(Constants.AppSettingsPath));        
    }
}
