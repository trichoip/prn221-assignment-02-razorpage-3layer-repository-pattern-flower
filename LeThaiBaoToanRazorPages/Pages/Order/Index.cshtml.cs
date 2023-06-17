using DataAccess.Service;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LeThaiBaoToanRazorPages.Pages.Order
{
    public class IndexModel : PageModel
    {
        private readonly OrderService _service;

        public IndexModel()
        {
            _service = new OrderService();
        }

        public IList<BusinessObject.Models.Order> Order { get; set; } = default!;

        public async Task OnGetAsync()
        {

            Order = _service.GetAll();
        }
    }
}
