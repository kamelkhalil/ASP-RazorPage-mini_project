using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesDemoApp.Data;
using RazorPagesDemoApp.Models.Domain;
using RazorPagesDemoApp.Models.ViewModels;

namespace RazorPagesDemoApp.Pages.Employees
{
    public class AddModel : PageModel
    {
        private RazorPagesDemoDbContext dbContext;

        public AddModel(RazorPagesDemoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [BindProperty]
        public AddEmployeeViewModel AddEmployeeRequest { get; set; }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            //Convert ViewModel to DomainModel
            var employeeDomainModel = new Employee
            {
                Full_Name = AddEmployeeRequest.Full_Name,
                Email_Address = AddEmployeeRequest.Email_Address,
                Salary = AddEmployeeRequest.Salary,
                DateOfBirth = AddEmployeeRequest.DateOfBirth,
                Department = AddEmployeeRequest.Department,
            };
            dbContext.Employees.Add(employeeDomainModel);
            dbContext.SaveChanges();
            ViewData["Message"] = "Employee Created Successfully!";
        }
    }
}
