using DataAccess.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LeThaiBaoToanRazorPages.Pages.Supplier
{
    public class EditModel : PageModel
    {
        private readonly ServiceBaseImpl<BusinessObject.Models.Supplier> _serviceBase;

        public EditModel()
        {
            _serviceBase = new ServiceBaseImpl<BusinessObject.Models.Supplier>();
        }

        [BindProperty]
        public BusinessObject.Models.Supplier Supplier { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var supplier = _serviceBase.GetById(id);
            if (supplier == null)
            {
                return NotFound();
            }
            Supplier = supplier;
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
                _serviceBase.Update(Supplier);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupplierExists(Supplier.SupplierId))
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

        private bool SupplierExists(int id)
        {
            return (_serviceBase.GetAll()?.Any(e => e.SupplierId == id)).GetValueOrDefault();
        }
    }
}
