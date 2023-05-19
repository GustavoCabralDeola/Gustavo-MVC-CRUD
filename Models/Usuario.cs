using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gustavo_MVC_CRUD.Models {

    [Table("Usuario")]
    public class Usuario {
      
            public Usuario() { }

            public Usuario
            (
              int id,
              string nome,
              string empresa,
              string email,
              string telefonepessoal,
              string telefonecomercial
            ) {
                Id = id;
                Nome = nome;
                Empresa = empresa;
                Email = email;
                TelefonePessoal = telefonepessoal;
                TelefoneComercial = telefonecomercial;
            }

            [Display(Name = "Id")]
            public int Id { get; set; }

            [Display(Name = "Nome")]
            [Required(ErrorMessage = "{0} exigido")]
            [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} o tamanho deve ser entre {2} e {1}")]
            public string Nome { get; set; }

            [Display(Name = "Empresa")]
            [Required(ErrorMessage = "{0} exigido")]
            [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} o tamanho deve ser entre {2} e {1}")]
            public string Empresa { get; set; }

            [Required(ErrorMessage = "{0} exigido")]
            [EmailAddress(ErrorMessage = "Digite um email válido")]
            [DataType(DataType.EmailAddress)]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required(ErrorMessage = "{0} exigido")]    
            [Display(Name = "Telefone Pessoal")]
            [StringLength(15,MinimumLength = 11, ErrorMessage = "Digite um numero válido")]
            public string TelefonePessoal { get; set; }

            [Required(ErrorMessage = "{0} exigido")]
            [Display(Name = "Telefone Comercial")]
            [StringLength(15, MinimumLength = 11, ErrorMessage = "Digite um numero válido")]
            public string TelefoneComercial { get; set; }
        }
    }
