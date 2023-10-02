namespace MyDoctorAppointment.Domain.Entities
{
    public class Auditable
    {
        public int Id { get; set; }
        public string Surname { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
