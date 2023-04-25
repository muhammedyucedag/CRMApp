using CrmApplication.Entites.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmApplication.Entites
{
    [Table("Products")]
    public class Product : EntityBase
    {
        [Required(ErrorMessage = "Ürün adı alanını boş geçemezsiniz.")]
        [DisplayName("Ürün Adı")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Ürün fiyatı alanını boş geçemezsiniz.")]
        [DisplayName("Birim Fiyatı")]
        public decimal UnitPrice { get; set; }

        [Required(ErrorMessage = "KDV oran alanını boş geçemezsiniz.")]
        [DisplayName("KDV Oranı")]
        public int VatRate { get; set; }

        [DisplayName("Ürün Resmi")]
        public string? ImageUrl { get; set; }

        [Required(ErrorMessage = "Stok miktarı alanını boş geçemezsiniz.")]
        [DisplayName("Stok Miktarı")]
        public int StockAmount { get; set; }
    }
}
