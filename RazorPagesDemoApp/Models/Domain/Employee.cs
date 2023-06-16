﻿namespace RazorPagesDemoApp.Models.Domain
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Full_Name { get; set; }
        public string Email_Address { get; set; }
        public long Salary { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Department { get; set; }
    }
}
