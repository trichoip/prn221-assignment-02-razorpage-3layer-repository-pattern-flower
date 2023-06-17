using DataAccess.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LeThaiBaoToanRazorPages.Pages.Order
{
    public class DeleteModel : PageModel
    {
        private readonly OrderService _service;

        public DeleteModel()
        {
            _service = new OrderService();
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
            else
            {
                Order = order;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {

            var order = _service.GetAll().FirstOrDefault(m => m.OrderId == id);

            if (order != null)
            {
                _service.Delete(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
