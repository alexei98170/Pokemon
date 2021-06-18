using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pokemon.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string Name{ get; set; }
        public string Email { get; set; }
        public DateTime OrderDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yy H:mm:ss}", ApplyFormatInEditMode = true)]
        public string PhoneNumber{ get; set; }
    }
}
