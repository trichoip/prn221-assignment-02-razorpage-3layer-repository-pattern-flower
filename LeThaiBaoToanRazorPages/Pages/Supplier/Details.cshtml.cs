using DataAccess.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LeThaiBaoToanRazorPages.Pages.Supplier
{
    public class DetailsModel : PageModel
    {
        private readonly ServiceBaseImpl<BusinessObject.Models.Supplier> _serviceBase;

        public DetailsModel()
        {
            _serviceBase = new ServiceBaseImpl<BusinessObject.Models.Supplier>();
        }

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
    }
}
