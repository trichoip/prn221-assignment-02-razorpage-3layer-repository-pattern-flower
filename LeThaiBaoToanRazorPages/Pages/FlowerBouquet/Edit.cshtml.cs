using DataAccess.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LeThaiBaoToanRazorPages.Pages.FlowerBouquet
{
    public class EditModel : PageModel
    {
        private readonly ServiceBaseImpl<BusinessObject.Models.FlowerBouquet> _serviceBase;
        private readonly ServiceBaseImpl<BusinessObject.Models.Category> _serviceCategory;
        private readonly ServiceBaseImpl<BusinessObject.Models.Supplier> _serviceSupplier;

        public EditModel()
        {
            _serviceBase = new ServiceBaseImpl<BusinessObject.Models.FlowerBouquet>();
            _serviceCategory = new ServiceBaseImpl<BusinessObject.Models.Category>();
            _serviceSupplier = new ServiceBaseImpl<BusinessObject.Models.Supplier>();
        }

        [BindProperty]
        public BusinessObject.Models.FlowerBouquet FlowerBouquet { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var flowerbouquet = _serviceBase.GetAll().FirstOrDefault(m => m.FlowerBouquetId == id);
            if (flowerbouquet == null)
            {
                return NotFound();
            }
            FlowerBouquet = flowerbouquet;
            ViewData["CategoryId"] = new SelectList(_serviceCategory.GetAll(), "CategoryId", "CategoryName");
            ViewData["SupplierId"] = new SelectList(_serviceSupplier.GetAll(), "SupplierId", "SupplierName");
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
                _serviceBase.Update(FlowerBouquet);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlowerBouquetExists(FlowerBouquet.FlowerBouquetId))
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

        private bool FlowerBouquetExists(int id)
        {
            return (_serviceBase.GetAll()?.Any(e => e.FlowerBouquetId == id)).GetValueOrDefault();
        }
    }
}
