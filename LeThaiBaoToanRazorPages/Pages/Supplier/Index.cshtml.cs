using DataAccess.Service;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LeThaiBaoToanRazorPages.Pages.Supplier
{
    public class IndexModel : PageModel
    {
        private readonly ServiceBaseImpl<BusinessObject.Models.Supplier> _serviceBase;

        public IndexModel()
        {
            _serviceBase = new ServiceBaseImpl<BusinessObject.Models.Supplier>();
        }

        public IList<BusinessObject.Models.Supplier> Supplier { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Supplier = _serviceBase.GetAll();
        }
    }
}
