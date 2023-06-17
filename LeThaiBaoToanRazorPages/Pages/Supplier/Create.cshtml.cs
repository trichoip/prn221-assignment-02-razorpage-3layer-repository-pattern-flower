using DataAccess.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LeThaiBaoToanRazorPages.Pages.Supplier
{
    public class CreateModel : PageModel
    {
        private readonly ServiceBaseImpl<BusinessObject.Models.Supplier> _serviceBase;

        public CreateModel()
        {
            _serviceBase = new ServiceBaseImpl<BusinessObject.Models.Supplier>();
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public BusinessObject.Models.Supplier Supplier { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _serviceBase.Add(Supplier);

            return RedirectToPage("./Index");
        }
    }
}
