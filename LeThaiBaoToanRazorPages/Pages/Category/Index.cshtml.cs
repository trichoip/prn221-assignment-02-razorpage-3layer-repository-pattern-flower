using DataAccess.Service;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LeThaiBaoToanRazorPages.Pages.Category
{
    public class IndexModel : PageModel
    {
        private readonly ServiceBaseImpl<BusinessObject.Models.Category> _serviceBase;

        public IndexModel()
        {
            _serviceBase = new ServiceBaseImpl<BusinessObject.Models.Category>();
        }

        public IList<BusinessObject.Models.Category> Category { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Category = _serviceBase.GetAll();
        }
    }
}
