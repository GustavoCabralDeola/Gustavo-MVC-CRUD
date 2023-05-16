namespace Gustavo_MVC_CRUD.Models {
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

            public int Id { get; set; }
            public string Name { get; set; }
            public string Company { get; set; }
            public string Email { get; set; }
            public string PersonalPhone { get; set; }
            public string CommercialPhone { get; set; }

        }
    }
