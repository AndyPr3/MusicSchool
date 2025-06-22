namespace MusicSchool.Domain.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string IdentificationNumber { get; set; }
        public string FirtsName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
