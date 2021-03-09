using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace World_Wide_Parcel.Models
//This class contains the information about Tracking page means it tells about its ID, expected date of delivery and foreign key of parcel//
{
    public class Tracking
    {
        public int Id { get; set; }
        [Required]
        public DateTime Expected_date_of_delivery { get; set; }

        public int ParcelsId { get; set; }
        public Parcels Parcels { get; set; }
    }
}
