﻿namespace MusicSchool.Domain.Entities
{
    public class Teacher
    {
        public int Id { get; set; }
        public string IdentificationNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int SchoolId { get; set; }
    }
}
