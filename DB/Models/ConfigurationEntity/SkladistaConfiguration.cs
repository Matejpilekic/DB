using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace DB.Models.ConfigurationEntity
{
    public class SkladistaConfiguration : EntityTypeConfiguration<Skladista>
    {
        public SkladistaConfiguration()
        {
            this.HasKey<int>(s => s.SkladisteID);

            this.Property(p => p.Naziv)
                .HasMaxLength(255)
                .IsRequired();
            this.Property(p => p.Adresa)
                .HasMaxLength(255)
                .IsRequired();

            this.HasMany<Ulazi>(u => u.Ulazi).WithRequired(s => s.Skladista).HasForeignKey<int>(s => s.SkladisteID);
        }
    }
}