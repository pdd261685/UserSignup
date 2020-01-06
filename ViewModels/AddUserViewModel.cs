using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace UserSignup.ViewModels
{
    public class AddUserViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required][EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(40,MinimumLength =6,ErrorMessage ="Pasword should have atleast 6 characters")]
        //[RegularExpression(@"^(?=.*[A - Za - z])(?=.*\d)[A - Za - z\d]{8,}$", ErrorMessage = "Need uppercase,lowercase and a digit")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Password and Confirm Password do not match")]
        [Display(Name = "Verify Password")]
        [DataType(DataType.Password)]
        public string VPassword { get; set; }

        


    }
}
