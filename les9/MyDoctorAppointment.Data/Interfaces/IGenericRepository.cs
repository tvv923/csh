using MyDoctorAppointment.Domain.Entities;

namespace MyDoctorAppointment.Data.Interfaces
{
    public interface IGenericRepository<TSource> where TSource : Auditable
    {
        TSource Create(TSource source);
        TSource? GetById(int id);
        TSource? GetBySurname(string surname);
        TSource Update(int id, TSource source);
        IEnumerable<TSource> GetAll();
        List<TSource> GetAllXml();

        bool Delete(int id);
        void ShowInfo(TSource source);
        void SetFileType(int myFileType);
        int GetFileType();
        void SetPath();
    }
}
