namespace MusicSchool.Application.DTOs
{
    public class InscriptionDto
    {
        public int Id { get; set; }
        public StudentDto Student { get; set; }
        public TeacherDto Teacher { get; set; }
        public DateTime AssignedAt { get; set; }
    }
}
