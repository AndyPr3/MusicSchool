namespace MusicSchool.Domain.Entities
{
    public class Inscription
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int TeacherId { get; set; }
        public DateTime AssignedAt { get; set; }
        public Student Student { get; set; } = new();
        public Teacher Teacher { get; set; } = new();
    }
}
