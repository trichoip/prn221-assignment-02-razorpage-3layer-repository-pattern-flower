using DataAccess.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LeThaiBaoToanRazorPages.Pages.OrderDetail
{
    public class CreateModel : PageModel
    {
        private readonly OrderDetailsService _service;
        private readonly ServiceBaseImpl<BusinessObject.Models.FlowerBouquet> _serviceFlowerBouquet;
        private readonly ServiceBaseImpl<BusinessObject.Models.Order> _serviceOrder;

        public CreateModel()
        {
            _service = new OrderDetailsService();
            _serviceFlowerBouquet = new ServiceBaseImpl<BusinessObject.Models.FlowerBouquet>();
            _serviceOrder = new ServiceBaseImpl<BusinessObject.Models.Order>();
        }

        public IActionResult OnGet()
        {
            ViewData["FlowerBouquetId"] = new SelectList(_serviceFlowerBouquet.GetAll(), "FlowerBouquetId", "Description");
            ViewData["OrderId"] = new SelectList(_serviceOrder.GetAll(), "OrderId", "OrderId");
            return Page();
        }

        [BindProperty]
        public BusinessObject.Models.OrderDetail OrderDetail { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _service.Add(OrderDetail);

            return RedirectToPage("./Index");
        }
    }
}
