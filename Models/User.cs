using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gustavo_MVC_CRUD.Models {

    [Table("User")]
    public class User {
      
            public User() { }

            public User
            (
              int id,
              string name,
              string company,
              string email,
              string personalphone,
              string commercialphone
            ) {
                Id = id;
                Name = name;
                Company = company;
                Email = email;
                PersonalPhone = personalphone;
                CommercialPhone = commercialphone;
            }

            [Display(Name = "Id")]
            public int Id { get; set; }

            [Display(Name = "Name")]
            [Required(ErrorMessage = "{0} required")]
            [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} size should be between {2} and {1}")]
            public string Name { get; set; }

            [Display(Name = "Company")]
            public string Company { get; set; }

            
            [EmailAddress(ErrorMessage = "Enter a valid email")]
            [DataType(DataType.EmailAddress)]
            [Display(Name = "Email")]
            public string Email { get; set; }
            
            [Display(Name = "Personal_Phone")]
            [StringLength(15,MinimumLength = 11, ErrorMessage = "Enter a valid number")]
            public string PersonalPhone { get; set; }

            [Display(Name = "Comercial_Phone")]
            [StringLength(15, MinimumLength = 11, ErrorMessage = "Enter a valid number")]
            public string CommercialPhone { get; set; }
        }
    }
