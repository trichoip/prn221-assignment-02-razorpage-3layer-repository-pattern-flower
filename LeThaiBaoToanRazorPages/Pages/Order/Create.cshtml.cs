using DataAccess.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LeThaiBaoToanRazorPages.Pages.Order
{
    public class CreateModel : PageModel
    {
        private readonly OrderService _service;
        private readonly ServiceBaseImpl<BusinessObject.Models.Customer> _serviceCustomer;

        public CreateModel()
        {
            _service = new OrderService();
            _serviceCustomer = new ServiceBaseImpl<BusinessObject.Models.Customer>();
        }

        public IActionResult OnGet()
        {
            ViewData["CustomerId"] = new SelectList(_serviceCustomer.GetAll(), "CustomerId", "CustomerName");
            return Page();
        }

        [BindProperty]
        public BusinessObject.Models.Order Order { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _service.Add(Order);

            return RedirectToPage("./Index");
        }
    }
}
