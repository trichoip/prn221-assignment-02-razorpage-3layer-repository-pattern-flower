using DataAccess.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LeThaiBaoToanRazorPages.Pages.FlowerBouquet
{
    public class CreateModel : PageModel
    {
        private readonly ServiceBaseImpl<BusinessObject.Models.FlowerBouquet> _serviceBase;
        private readonly ServiceBaseImpl<BusinessObject.Models.Category> _serviceCategory;
        private readonly ServiceBaseImpl<BusinessObject.Models.Supplier> _serviceSupplier;

        public CreateModel()
        {
            _serviceBase = new ServiceBaseImpl<BusinessObject.Models.FlowerBouquet>();
            _serviceCategory = new ServiceBaseImpl<BusinessObject.Models.Category>();
            _serviceSupplier = new ServiceBaseImpl<BusinessObject.Models.Supplier>();
        }

        public IActionResult OnGet()
        {
            ViewData["CategoryId"] = new SelectList(_serviceCategory.GetAll(), "CategoryId", "CategoryName");
            ViewData["SupplierId"] = new SelectList(_serviceSupplier.GetAll(), "SupplierId", "SupplierName");
            return Page();
        }

        [BindProperty]
        public BusinessObject.Models.FlowerBouquet FlowerBouquet { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || FlowerBouquet == null)
            {
                return Page();
            }

            _serviceBase.Add(FlowerBouquet);

            return RedirectToPage("./Index");
        }
    }
}
