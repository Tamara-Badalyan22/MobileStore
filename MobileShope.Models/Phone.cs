using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class Phone
    {
        [Key]
        public int ID { set; get; }
        [Required]
        public string Name { set; get; }
        [Required]
        public decimal Price { set; get; }
        [Required]
        public int Count { set; get; }
        [Required(ErrorMessage ="Please select Brand")]
        public int BrandID { get; set; }
        public Brand PhoneBrand { get; set; }
        [DefaultValue(true)]
        public bool Status { set; get; }
    }
}
