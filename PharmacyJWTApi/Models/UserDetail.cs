using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmacyJWTApi.Models
{
    public class UserDetail
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [DisplayName("Name")]
        [StringLength(40, MinimumLength = 5)]
        [Required(ErrorMessage = "First Name can`t be blank")]
        public string UserName { get; set; }

        [DisplayName("Email")]
        [EmailAddress]
        [Required(ErrorMessage = "Email id can't be blank")]
        public string Email { get; set; }

        [DisplayName("Password")]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$")]
        [Required(ErrorMessage = "Password can`t be blank")]
        public string Password { get; set; }

        [DisplayName("PhoneNumber")]
        [RegularExpression("^[5-9][0-9]{9}$")]
        [Required(ErrorMessage = "Enter Correct Phone Number")]
        public string PhoneNumber { get; set; }

        [DisplayName("Address")]
        [StringLength(50, MinimumLength = 5)]
        [Required(ErrorMessage = "First Name can`t be blank")]
        public string Address { get; set; }

        [DisplayName("PhoneNumber")]
        public int Age { get; set; }

        [ForeignKey("RoleId")]
        public int RoleId { get; set; }
    }
}
