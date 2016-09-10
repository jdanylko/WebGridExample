using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebGridExample.Models
{
    [Serializable]
    public class User: IValidatableObject
    {
        public int Id { get; set; } // Id (Primary key)
        public string UserName { get; set; } // UserName
        public DateTime LastLogin { get; set; } // LastLogin
        public string FirstName { get; set; } // FirstName
        public string LastName { get; set; } // LastName

        public User()
        {
            LastLogin = System.DateTime.Now;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var list = new List<ValidationResult>();

            if (UserName.Length > 10)
            {
                var item = new ValidationResult("You cannot have a UserName with more than 10 characters",
                    new[] { "UserName" });
                list.Add(item);
            }

            return list;
        }
    }
}