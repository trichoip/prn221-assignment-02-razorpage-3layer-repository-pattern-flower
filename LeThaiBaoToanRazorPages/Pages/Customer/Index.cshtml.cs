using DataAccess.Service;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LeThaiBaoToanRazorPages.Pages.Customer
{
    public class IndexModel : PageModel
    {
        private readonly ServiceBaseImpl<BusinessObject.Models.Customer> _serviceBase;

        public IndexModel()
        {
            _serviceBase = new ServiceBaseImpl<BusinessObject.Models.Customer>();
        }

        public IList<BusinessObject.Models.Customer> Customer { get; set; } = default!;

        public async Task OnGetAsync()
        {

            Customer = _serviceBase.GetAll();

        }
    }
}
