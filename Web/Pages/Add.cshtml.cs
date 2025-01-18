using Application.Dtos;
using Application.Interfaces;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Web.Pages
{
    public class AddPersonModel : PageModel
    {
        private readonly IPersonService _personService;

        [BindProperty]
        public CreatePersonDto Person { get; set; }

        public AddPersonModel( IPersonService personService)
        {
            _personService = personService;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _personService.Create(Person);
            return RedirectToPage("./Index");
        }
    }
}




