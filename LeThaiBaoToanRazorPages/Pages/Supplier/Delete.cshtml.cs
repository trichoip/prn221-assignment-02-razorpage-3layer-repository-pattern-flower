using DataAccess.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LeThaiBaoToanRazorPages.Pages.Supplier
{
    public class DeleteModel : PageModel
    {
        private readonly ServiceBaseImpl<BusinessObject.Models.Supplier> _serviceBase;

        public DeleteModel()
        {
            _serviceBase = new ServiceBaseImpl<BusinessObject.Models.Supplier>();
        }

        [BindProperty]
        public BusinessObject.Models.Supplier Supplier { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var supplier = _serviceBase.GetAll().FirstOrDefault(m => m.SupplierId == id);

            if (supplier == null)
            {
                return NotFound();
            }
            else
            {
                Supplier = supplier;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var supplier = _serviceBase.GetAll().FirstOrDefault(m => m.SupplierId == id);

            if (supplier != null)
            {
                _serviceBase.Delete(id);

            }
            return RedirectToPage("./Index");
        }
    }
}
