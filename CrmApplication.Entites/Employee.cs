using CrmApplication.Entites.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmApplication.Entites
{
    public class Employee : EntityBase
    {
        [DisplayName("İşe Giriş Tarihi")]
        public DateTime? EnteranceDate { get; set; }


        [DisplayName("Adı Soyadı")]
        [Required(ErrorMessage = "Adı Soyadı alanını boş geçemezsiniz..")]
        public string NameSurname { get; set; }


        [DisplayName("Kimilik Numarası")]
        public string CitizenNumber { get; set; }


        [DisplayName("Maaş")]
        public int Wage { get; set; }


        [DisplayName("E-Mail")]
        [Required(ErrorMessage = "E-Mail alanını boş geçemezsiniz..")]
        public string Mail { get; set; }


        [DisplayName("Şifre")]
        [Required(ErrorMessage = "Şifre alanını boş geçemezsiniz..")]
        public string Passwonrd { get; set; }


        [DisplayName("Telefon Numarası")]
        public string? Phone { get; set; }


        [DisplayName("Durumu")]
        public bool Status { get; set; }


        [DisplayName("Yetki")]
        public string Role { get; set; }
    }
}
