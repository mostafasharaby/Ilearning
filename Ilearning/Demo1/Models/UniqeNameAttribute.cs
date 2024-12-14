using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;

namespace Demo1.Models
{
    public class UniqueNameAttribute : ValidationAttribute
    {

        MVCDbContext context = new MVCDbContext();
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            if (!int.TryParse(value.ToString(), out int id))
            {
                return new ValidationResult("Invalid Employee ID format.");
            }

            var v = context.Employees.FirstOrDefault(i => i.ID == id);
            if (v == null)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(ErrorMessage ?? "This name is already exist in DB.");
        }
    }
}
