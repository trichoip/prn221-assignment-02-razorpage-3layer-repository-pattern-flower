using DataAccess.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LeThaiBaoToanRazorPages.Pages.Customer
{
    public class EditModel : PageModel
    {
        private readonly ServiceBaseImpl<BusinessObject.Models.Customer> _serviceBase;

        public EditModel()
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
            Customer = customer;
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
                _serviceBase.Update(Customer);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(Customer.CustomerId))
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

        private bool CustomerExists(int id)
        {
            return (_serviceBase.GetAll()?.Any(e => e.CustomerId == id)).GetValueOrDefault();
        }
    }
}
