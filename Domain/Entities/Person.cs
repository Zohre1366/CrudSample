using Domain.Enums;

namespace Domain.Entities
{
    public class Person 
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public string FatherName { get; set; }
        public GenderEnum Gender { get; set; }
    }
}