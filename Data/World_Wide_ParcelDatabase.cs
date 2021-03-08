using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using World_Wide_Parcel.Models;

namespace World_Wide_Parcel.Data
{
    public class World_Wide_ParcelDatabase : DbContext
    {
        public World_Wide_ParcelDatabase (DbContextOptions<World_Wide_ParcelDatabase> options)
            : base(options)
        {
        }

        public DbSet<World_Wide_Parcel.Models.Companies> Companies { get; set; }

        public DbSet<World_Wide_Parcel.Models.Recievers> Recievers { get; set; }

        public DbSet<World_Wide_Parcel.Models.Senders> Senders { get; set; }

        public DbSet<World_Wide_Parcel.Models.Tracking> Tracking { get; set; }

        public DbSet<World_Wide_Parcel.Models.Parcels> Parcels { get; set; }
    }
}
