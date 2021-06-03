using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Core.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }

        [DisplayName("Adı")]
        [Required(ErrorMessage = "Zorunlu")]
        [StringLength(maximumLength: 50, ErrorMessage = "Kullanıcı adı en fazla 50 karakter olmaıldır.")]
        public string Name { get; set; }

        [DisplayName("Soyadı")]
        [Required(ErrorMessage = "Zorunlu")]
        [StringLength(maximumLength: 50, ErrorMessage = "Kullanıcı adı en fazla 50 karakter olmaıldır.")]
        public string Surname { get; set; }

        [DisplayName("Telefon")]
        [Required(ErrorMessage = "Zorunlu")]
        [Phone(ErrorMessage = "Hatalı telefon numarası")]
        public string PhoneNumber { get; set; }

        [DisplayName("Kullanıcı Adı")]
        [Required(ErrorMessage = "Zorunlu")]
        [StringLength(maximumLength: 20, ErrorMessage = "Kullanıcı adı en fazla 20 karakter olmaıldır.")]
        public string MobileUsername { get; set; }

        [DisplayName("Parola")]
        [Required(ErrorMessage = "Zorunlu")]
        [StringLength(maximumLength: 20, ErrorMessage = "Parola en 4 en fazla 20 karakter olmaıldır.", MinimumLength = 4)]
        public string MobilePassword { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
