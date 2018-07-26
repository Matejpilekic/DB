using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace DB.Models.ConfigurationEntity
{
    public class UlogaConfiguration : EntityTypeConfiguration<Uloge>
    {
        public UlogaConfiguration()
        {
            this.HasKey(k => k.UlogaID);

            this.Property(p => p.Naziv)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}