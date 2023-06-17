using DataAccess.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LeThaiBaoToanRazorPages.Pages.FlowerBouquet
{
    public class DetailsModel : PageModel
    {
        private readonly FlowerBouquetService _service;

        public DetailsModel()
        {
            _service = new FlowerBouquetService();
        }

        public BusinessObject.Models.FlowerBouquet FlowerBouquet { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var flowerbouquet = _service.GetAll().FirstOrDefault(m => m.FlowerBouquetId == id);
            if (flowerbouquet == null)
            {
                return NotFound();
            }
            else
            {
                FlowerBouquet = flowerbouquet;
            }
            return Page();
        }
    }
}
