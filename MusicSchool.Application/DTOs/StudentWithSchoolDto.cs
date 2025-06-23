namespace MusicSchool.Application.DTOs
{
    public class StudentWithSchoolDto
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public int SchoolId { get; set; }
        public string SchoolName { get; set; } = "";
    }
}
