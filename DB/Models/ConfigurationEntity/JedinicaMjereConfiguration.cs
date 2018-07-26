using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace DB.Models.ConfigurationEntity
{
    public class JedinicaMjereConfiguration : EntityTypeConfiguration<JediniceMjere>
    {
        public JedinicaMjereConfiguration()
        {
            this.HasKey<int>(k => k.JediniceMjereID);

            this.Property(p => p.Naziv)
                .HasMaxLength(255)
                .IsRequired();

        }
    }
}