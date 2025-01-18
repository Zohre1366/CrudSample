using Domain.Enums;

namespace Application.Dtos
{
    public class CreatePersonDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public string FatherName { get; set; }
        public GenderEnum Gender { get; set; }
    }
}