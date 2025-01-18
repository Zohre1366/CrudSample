using Application.Dtos;
using Application.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IPersonService _personService;

        public List<PersonDto> Persons { get; set; }

        public IndexModel(IPersonService personService)
        {
            _personService = personService;
        }

        public async void OnGet()
        {
            Persons = await _personService.GetList("");
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            await _personService.Delete(id);
            return RedirectToPage();

        }
    }
}
