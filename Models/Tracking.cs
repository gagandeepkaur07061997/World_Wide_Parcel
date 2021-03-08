﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace World_Wide_Parcel.Models
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
