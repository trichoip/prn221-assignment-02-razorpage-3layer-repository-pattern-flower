using DataAccess.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LeThaiBaoToanRazorPages.Pages.Category
{
    public class CreateModel : PageModel
    {
        private readonly ServiceBaseImpl<BusinessObject.Models.Category> _serviceBase;

        public CreateModel()
        {
            _serviceBase = new ServiceBaseImpl<BusinessObject.Models.Category>();
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public BusinessObject.Models.Category Category { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _serviceBase.GetAll() == null || Category == null)
            {
                return Page();
            }
            _serviceBase.Add(Category);
            return RedirectToPage("./Index");
        }
    }
}
