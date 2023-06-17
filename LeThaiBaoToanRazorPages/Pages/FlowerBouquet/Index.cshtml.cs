using DataAccess.Service;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LeThaiBaoToanRazorPages.Pages.FlowerBouquet
{
    public class IndexModel : PageModel
    {
        private readonly FlowerBouquetService _service;

        public IndexModel()
        {
            _service = new FlowerBouquetService();
        }

        public IList<BusinessObject.Models.FlowerBouquet> FlowerBouquet { get; set; } = default!;

        public async Task OnGetAsync()
        {
            FlowerBouquet = _service.GetAll();

        }
    }
}
