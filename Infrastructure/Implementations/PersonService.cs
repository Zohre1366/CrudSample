using Application.Dtos;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implementations
{
    public class PersonService : IPersonService
    {
        private readonly IRepository<Person> _personRepository;
        private readonly IMapper _mapper;
        public PersonService(IRepository<Person> personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }
        public async Task<List<PersonDto>> GetList(string nationalCode)
        {
            var temp = (await _personRepository.GetQueryable()).AsNoTracking()
                 .Where(o => string.IsNullOrEmpty(nationalCode) || o.NationalCode.Contains(nationalCode));
            return _mapper.Map<List<Person>, List<PersonDto>>(temp.ToList());
        }
        public async Task<PersonDto> GetById(int id)
        {
            Person temp = (await _personRepository.GetQueryable()).AsNoTracking().FirstOrDefault(o => o.Id == id);
            return _mapper.Map<Person, PersonDto>(temp);
        }
        public async Task<bool> Create(CreatePersonDto input)
        {
            if (await _personRepository.Any(o => o.NationalCode == input.NationalCode))
            { throw new ArgumentException("NationalCode is repeated"); }

            await _personRepository.Add(_mapper.Map<CreatePersonDto, Person>(input));
            return true;
        }
        public async Task<bool> Update(UpdatePersonDto input)
        {
            if (await _personRepository.Any(o => o.Id != input.Id && o.NationalCode == input.NationalCode))
            { throw new ArgumentException("NationalCode is repeated"); }

            var entity = (await _personRepository.GetQueryable()).AsNoTracking().FirstOrDefault(o => o.Id == input.Id);

            if (entity is null)
            { throw new ArgumentException("Person not found"); }

            await _personRepository.Update(_mapper.Map(input, entity));
            return true;
        }
        public async Task<bool> Delete(int id)
        {
            var entity = (await _personRepository.GetQueryable()).AsNoTracking().FirstOrDefault(o => o.Id == id);

            if (entity is null)
            { throw new ArgumentException("Person not found"); }

            await _personRepository.Delete(entity);
            return true;
        }
    }
}