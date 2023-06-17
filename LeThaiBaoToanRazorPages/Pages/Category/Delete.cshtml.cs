using DataAccess.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LeThaiBaoToanRazorPages.Pages.Category
{
    public class DeleteModel : PageModel
    {
        private readonly ServiceBaseImpl<BusinessObject.Models.Category> _serviceBase;

        public DeleteModel()
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
            else
            {
                Category = category;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var category = _serviceBase.GetAll().FirstOrDefault(m => m.CategoryId == id);
            if (category != null)
            {
                _serviceBase.Delete(id);
            }
            return RedirectToPage("./Index");
        }
    }
}
