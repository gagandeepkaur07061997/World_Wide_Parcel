using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace World_Wide_Parcel.Models
//This class contains the information about Companies means it tells about its ID, name, email.id, address, mobile number and website.//
{
    public class Companies
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email_Id { get; set; }
        public string Address { get; set; }
        [Required]
        public string Mobile_Number { get; set; }
        public string Website { get; set; }
    }
}
