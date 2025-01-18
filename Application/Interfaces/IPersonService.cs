using Application.Dtos;

namespace Application.Interfaces
{
    public interface IPersonService
    {
        Task<List<PersonDto>> GetList(string nationalCode);
        Task<PersonDto> GetById(int id);
        Task<bool> Create(CreatePersonDto input);
        Task<bool> Update(UpdatePersonDto input);
        Task<bool> Delete(int id);
    }
}
