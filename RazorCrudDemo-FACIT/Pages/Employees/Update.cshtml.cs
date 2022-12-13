using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorCrudDemo_FACIT.Data;
using RazorCrudDemo_FACIT.Data.Viewmodels;

namespace RazorCrudDemo_FACIT.Pages.Employees
{
    public class UpdateModel : PageModel
    {
        [BindProperty]
        public UpdateEmployeeViewModel UpdateEmployee { get; set; }

        private readonly ApplicationDbContext _dbContext;

        public UpdateModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void OnGet(Guid id)
        {
            var employee = _dbContext.Employees.Find(id);

            if (employee != null)
            {
                UpdateEmployee = new UpdateEmployeeViewModel()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Email = employee.Email,
                    DateOfBirth = employee.DateOfBirth,
                    Salary = employee.Salary,
                    Department = employee.Department
                };
            }
        }
        public void OnPost()
        {
            var employeeToUpdate = _dbContext.Employees.Find(UpdateEmployee.Id);

            if (ModelState.IsValid)
            {
                // Mappar från ViewModel till DB Model
                employeeToUpdate.Name = UpdateEmployee.Name;
                employeeToUpdate.Email = UpdateEmployee.Email;
                employeeToUpdate.Salary = UpdateEmployee.Salary;
                employeeToUpdate.DateOfBirth = UpdateEmployee.DateOfBirth;
                employeeToUpdate.Department = UpdateEmployee.Department;

                _dbContext.SaveChanges();
            }
        }
    }
}
