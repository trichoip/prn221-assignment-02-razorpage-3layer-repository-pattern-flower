using DataAccess.Service;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LeThaiBaoToanRazorPages.Pages.OrderDetail
{
    public class IndexModel : PageModel
    {
        private readonly OrderDetailsService _service;

        public IndexModel()
        {
            _service = new OrderDetailsService();
        }

        public IList<BusinessObject.Models.OrderDetail> OrderDetail { get; set; } = default!;

        public async Task OnGetAsync()
        {
            OrderDetail = _service.GetAll();
        }
    }
}
