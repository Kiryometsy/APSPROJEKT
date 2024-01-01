using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Address
    {
        [Required]
        public required String City { get; set; }
        [Required]
        public required String Street { get; set; }
        [Required]
        public required String PostalCode { get; set; }
    }
}
