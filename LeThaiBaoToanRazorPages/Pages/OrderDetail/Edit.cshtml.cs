using DataAccess.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LeThaiBaoToanRazorPages.Pages.OrderDetail
{
    public class EditModel : PageModel
    {
        private readonly OrderDetailsService _service;
        private readonly ServiceBaseImpl<BusinessObject.Models.FlowerBouquet> _serviceFlowerBouquet;
        private readonly ServiceBaseImpl<BusinessObject.Models.Order> _serviceOrder;

        public EditModel()
        {
            _service = new OrderDetailsService();
            _serviceFlowerBouquet = new ServiceBaseImpl<BusinessObject.Models.FlowerBouquet>();
            _serviceOrder = new ServiceBaseImpl<BusinessObject.Models.Order>();
        }

        [BindProperty]
        public BusinessObject.Models.OrderDetail OrderDetail { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {

            var orderdetail = _service.GetAll().FirstOrDefault(m => m.OrderId == id);
            if (orderdetail == null)
            {
                return NotFound();
            }
            OrderDetail = orderdetail;
            ViewData["FlowerBouquetId"] = new SelectList(_serviceFlowerBouquet.GetAll(), "FlowerBouquetId", "Description");
            ViewData["OrderId"] = new SelectList(_serviceOrder.GetAll(), "OrderId", "OrderId");
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
                _service.Update(OrderDetail);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderDetailExists(OrderDetail.OrderId))
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

        private bool OrderDetailExists(int id)
        {
            return (_service.GetAll()?.Any(e => e.OrderId == id)).GetValueOrDefault();
        }
    }
}
