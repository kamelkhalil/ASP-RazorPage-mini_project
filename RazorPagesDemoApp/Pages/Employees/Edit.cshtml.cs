using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesDemoApp.Data;
using RazorPagesDemoApp.Models.ViewModels;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;

namespace RazorPagesDemoApp.Pages.Employees
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesDemoDbContext dbContext;

        [BindProperty]
        public EditEmployeeViewModel EditEmployeeViewModel { get; set; }

        public EditModel(RazorPagesDemoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void OnGet(Guid id)
        {
            var employee = dbContext.Employees.Find(id);
            if(employee != null)
            {
                //conver domain model to view model
                EditEmployeeViewModel = new EditEmployeeViewModel()
                {
                    Id = employee.Id,
                    Full_Name = employee.Full_Name,
                    Email_Address = employee.Email_Address,
                     Salary = employee.Salary,
                     DateOfBirth = employee.DateOfBirth,
                    Department = employee.Department
                };
            }
        }
        public void OnPostUpdate()
        {
            if(EditEmployeeViewModel != null)
            {
                var existingEmployee = dbContext.Employees.Find(EditEmployeeViewModel.Id);
                if(existingEmployee != null)
                {
                    // convert to domain model

                    
                    existingEmployee.Full_Name = EditEmployeeViewModel.Full_Name;
                    existingEmployee.Email_Address = EditEmployeeViewModel.Email_Address;
                    existingEmployee.Salary = EditEmployeeViewModel.Salary;
                    existingEmployee.DateOfBirth = EditEmployeeViewModel.DateOfBirth;
                    existingEmployee.Department = EditEmployeeViewModel.Department;
                    dbContext.SaveChanges();
                    //to returun to pagee after update
                    ViewData["Message"] = "Employee data Updated successfully";
                }
            }
            
        }
        public IActionResult OnPostDelete()
        {
            var existingEmployee = dbContext.Employees.Find(EditEmployeeViewModel.Id);
            {
                if(existingEmployee != null)
                {
                    dbContext.Employees.Remove(existingEmployee);
                    dbContext.SaveChanges();
                    return RedirectToPage("/Employees/List");
                }
                return Page();
            }
        }
    }
}
