using DataAccess.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LeThaiBaoToanRazorPages.Pages.Category
{
    public class DetailsModel : PageModel
    {
        private readonly ServiceBaseImpl<BusinessObject.Models.Category> _serviceBase;

        public DetailsModel()
        {
            _serviceBase = new ServiceBaseImpl<BusinessObject.Models.Category>();
        }

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
    }
}
