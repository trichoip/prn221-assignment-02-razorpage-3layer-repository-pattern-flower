using DataAccess.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LeThaiBaoToanRazorPages.Pages.Customer
{
    public class DeleteModel : PageModel
    {
        private readonly ServiceBaseImpl<BusinessObject.Models.Customer> _serviceBase;

        public DeleteModel()
        {
            _serviceBase = new ServiceBaseImpl<BusinessObject.Models.Customer>();
        }

        [BindProperty]
        public BusinessObject.Models.Customer Customer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var customer = _serviceBase.GetAll().FirstOrDefault(m => m.CustomerId == id);

            if (customer == null)
            {
                return NotFound();
            }
            else
            {
                Customer = customer;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var customer = _serviceBase.GetAll().FirstOrDefault(m => m.CustomerId == id);

            if (customer != null)
            {
                _serviceBase.Delete(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
