using System.ComponentModel.DataAnnotations;
using System.ComponentModel;



namespace QuickKartCoreMvcApp.Models
{
    public class Users
    {
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Invalid email address.")]
        [DisplayName("Email id")]
        [Required(ErrorMessage = "EmailId is mandatory")]
        public string EmailId { get; set; }
        [StringLength(maximumLength: 10)]
        [DisplayName("User password")]
        [Required(ErrorMessage = "Password is mandatory.")]
        public string UserPassword { get; set; }



        [ScaffoldColumn(false)]
        public Nullable<byte> RoleId { get; set; }
        [RegularExpression("M|F", ErrorMessage = "Gender should be M or F")]
        [Required(ErrorMessage = "Gender is mandatory.")]
        public string Gender { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Date of birth")]
        [Required(ErrorMessage = "DOB is madatory")]
        public System.DateTime DateOfBirth { get; set; }


        [Required(ErrorMessage = "Address is mandatory")]
        public string Address { get; set; }

    }
}
