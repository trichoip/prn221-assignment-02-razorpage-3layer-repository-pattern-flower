using DataAccess.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LeThaiBaoToanRazorPages.Pages.Customer
{
    public class DetailsModel : PageModel
    {
        private readonly ServiceBaseImpl<BusinessObject.Models.Customer> _serviceBase;

        public DetailsModel()
        {
            _serviceBase = new ServiceBaseImpl<BusinessObject.Models.Customer>();
        }

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
    }
}
