using DataAccess.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LeThaiBaoToanRazorPages.Pages.Order
{
    public class EditModel : PageModel
    {
        private readonly OrderService _service;
        private readonly ServiceBaseImpl<BusinessObject.Models.Customer> _serviceCustomer;

        public EditModel()
        {
            _service = new OrderService();
            _serviceCustomer = new ServiceBaseImpl<BusinessObject.Models.Customer>();
        }

        [BindProperty]
        public BusinessObject.Models.Order Order { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var order = _service.GetAll().FirstOrDefault(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }
            Order = order;
            ViewData["CustomerId"] = new SelectList(_serviceCustomer.GetAll(), "CustomerId", "CustomerName");
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
                _service.Update(Order);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(Order.OrderId))
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

        private bool OrderExists(int id)
        {
            return (_service.GetAll()?.Any(e => e.OrderId == id)).GetValueOrDefault();
        }
    }
}
