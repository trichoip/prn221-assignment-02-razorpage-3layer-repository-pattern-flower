using DataAccess.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LeThaiBaoToanRazorPages.Pages.Order
{
    public class DetailsModel : PageModel
    {
        private readonly OrderService _service;

        public DetailsModel()
        {
            _service = new OrderService();
        }

        public BusinessObject.Models.Order Order { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var order = _service.GetAll().FirstOrDefault(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }
            else
            {
                Order = order;
            }
            return Page();
        }
    }
}
