namespace MusicSchool.Domain.Entities
{
    public class School
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Teacher> Teachers { get; private set; } = new();
    }
}
