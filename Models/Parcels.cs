﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace World_Wide_Parcel.Models { 
//This class contains the information about Parcel means it tells about its ID,date od delivery and some other main points and also include foreign key//
    public class Parcels
    {
        public int Id { get; set; }
        [Required]
        public string Delivery_address { get; set; }

        public string Parcel_weight { get; set; }
        [Required]
        public string Content_type { get; set; }
        public Decimal Shipping_cost { get; set; }

        public int SendersId { get; set; }
        public Senders Senders { get; set; }

        public int CompaniesId { get; set; }
        public Companies Companies { get; set; }

        public int RecieversId { get; set; }
        public Recievers Recievers { get; set; }
    }
}
