using DataAccess.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LeThaiBaoToanRazorPages.Pages.Category
{
    public class EditModel : PageModel
    {
        private readonly ServiceBaseImpl<BusinessObject.Models.Category> _serviceBase;

        public EditModel()
        {
            _serviceBase = new ServiceBaseImpl<BusinessObject.Models.Category>();
        }

        [BindProperty]
        public BusinessObject.Models.Category Category { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {

            var category = _serviceBase.GetAll().FirstOrDefault(m => m.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }
            Category = category;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _serviceBase.Update(Category);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(Category.CategoryId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CategoryExists(int id)
        {
            return (_serviceBase.GetAll()?.Any(e => e.CategoryId == id)).GetValueOrDefault();
        }
    }
}
