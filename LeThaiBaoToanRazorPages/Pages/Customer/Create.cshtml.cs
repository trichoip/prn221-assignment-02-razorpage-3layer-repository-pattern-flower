using DataAccess.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LeThaiBaoToanRazorPages.Pages.Customer
{
    public class CreateModel : PageModel
    {
        private readonly ServiceBaseImpl<BusinessObject.Models.Customer> _serviceBase;

        public CreateModel()
        {
            _serviceBase = new ServiceBaseImpl<BusinessObject.Models.Customer>();
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public BusinessObject.Models.Customer Customer { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _serviceBase.Add(Customer);
            return RedirectToPage("./Index");
        }
    }
}
