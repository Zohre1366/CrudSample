using Application.Dtos;
using Application.Interfaces;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Web.Pages
{
    public class EditPersonModel : PageModel
    {
        private readonly IPersonService _personService;

        [BindProperty]
        public PersonDto Person { get; set; }

        public EditPersonModel(IPersonService personService)
        {
            _personService = personService;
        }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Person = await _personService.GetById(id ?? 0);

            if (Person == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            await _personService.Update(new UpdatePersonDto
            {
                Id = Person.Id,
                FirstName = Person.FirstName,
                LastName = Person.LastName,
                NationalCode = Person.NationalCode,
                FatherName = Person.FatherName,
                Gender = Person.Gender
            });
            return RedirectToPage("./Index");
        }
    }
}




