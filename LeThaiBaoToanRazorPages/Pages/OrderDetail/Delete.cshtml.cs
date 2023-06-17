using DataAccess.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LeThaiBaoToanRazorPages.Pages.OrderDetail
{
    public class DeleteModel : PageModel
    {
        private readonly OrderDetailsService _service;

        public DeleteModel()
        {
            _service = new OrderDetailsService();
        }

        [BindProperty]
        public BusinessObject.Models.OrderDetail OrderDetail { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
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

        public async Task<IActionResult> OnPostAsync(int id)
        {

            var orderdetail = _service.GetAll().FirstOrDefault(m => m.OrderId == id);

            if (orderdetail != null)
            {
                // xoa nguyen object moi duoc vi no khong co id pk
                //_service.Delete(id);

            }

            return RedirectToPage("./Index");
        }
    }
}
