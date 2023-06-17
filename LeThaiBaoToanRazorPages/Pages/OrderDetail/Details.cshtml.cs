using DataAccess.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LeThaiBaoToanRazorPages.Pages.OrderDetail
{
    public class DetailsModel : PageModel
    {
        private readonly OrderDetailsService _service;

        public DetailsModel()
        {
            _service = new OrderDetailsService();
        }

        public BusinessObject.Models.OrderDetail OrderDetail { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {

            var orderdetail = _service.GetAll().FirstOrDefault(m => m.OrderId == id);
            if (orderdetail == null)
            {
                return NotFound();
            }
            else
            {
                OrderDetail = orderdetail;
            }
            return Page();
        }
    }
}
