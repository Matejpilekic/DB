using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace DB.Models.ConfigurationEntity
{
    public class VrstaProizvodaConfiguration : EntityTypeConfiguration<VrsteProizvoda>
    {
        public VrstaProizvodaConfiguration()
        {
            this.HasKey<int>(k => k.VrstaID);

            this.Property(p => p.Naziv)
                .HasMaxLength(255)
                .IsRequired();
        }
    }
}