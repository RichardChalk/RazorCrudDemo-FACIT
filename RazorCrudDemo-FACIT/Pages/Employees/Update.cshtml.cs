using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorCrudDemo_FACIT.Data;

namespace RazorCrudDemo_FACIT.Pages.Employees
{
    public class UpdateModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        public UpdateModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void OnGet(Guid id)
        {
            var employee = _dbContext.Employees.Find(id);
        }
    }

}
