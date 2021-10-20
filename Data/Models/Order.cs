using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Data.Models
{
    public class Order
    {
        [BindNever]
        public int id { get; set; }
        
        [Display(Name ="Имя :")]
        [StringLength(15)]
        [Required(ErrorMessage ="Имя введено некорректно")]
        public string name { get; set; }
        
        [Display(Name = "Фамилия :")]
        [StringLength(20)]
        [Required(ErrorMessage = "Фамилия введена некорректно")]
        public string surname { get; set; }
        
        [Display(Name = "Адрес :")]
        [StringLength(50)]
        [Required(ErrorMessage = "Адрес введен некорректно")]
        public string adress { get; set; }
        
        [Display(Name = "Телефон :")]
        [StringLength(12)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Телефон введен некорректно")]
        public string phone { get; set; }
        
        [Display(Name = "EMAL :")]
        [DataType(DataType.EmailAddress)]
        [StringLength(50)]
        [Required(ErrorMessage = "EMAL введен некорректно")]
        public string email { get; set; }
        
        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime orderTime { get; set; }
        public List<OrderDetail> orderDetails { get; set; }
    }
}
