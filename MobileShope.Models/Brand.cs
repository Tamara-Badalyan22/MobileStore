using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shop.Models
{
   public class Brand
    {
        [Key]
        public int ID { set; get; }
        [Required(ErrorMessage ="Please enter Name")]
        public string Name { set; get; }
        public ICollection<Phone> Phones { get; set; }
        [DefaultValue(true)]
        public bool Status { set; get; }
    }
}
