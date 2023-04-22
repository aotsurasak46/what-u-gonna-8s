using System.ComponentModel.DataAnnotations;
using what_u_gonna_eat.Data;

namespace what_u_gonna_eat.Models
{
    public class UniqueUsernameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var db = (ApplicationDbContext)validationContext.GetService(typeof(ApplicationDbContext));

            string username = (string)value;

            if (db.Accounts.Any(u => u.Username == username))
            {
                return new ValidationResult("Username is already taken.");
            }

            return ValidationResult.Success;
        }
    }
}
