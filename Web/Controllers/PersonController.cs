using Application.Dtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<List<PersonDto>> GetList(string nationalCode) => await _personService.GetList(nationalCode);

        [HttpGet]
        public async Task<PersonDto> GetById(int id) => await _personService.GetById(id);

        [HttpPost]
        public async Task<bool> Create(CreatePersonDto input) => await _personService.Create(input);

        [HttpPut]
        public async Task<bool> Update(UpdatePersonDto input) => await _personService.Update(input);

        [HttpDelete]
        public async Task<bool> Delete(int id) => await _personService.Delete(id);


    }
}