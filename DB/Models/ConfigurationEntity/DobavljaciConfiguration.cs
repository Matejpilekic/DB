using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace DB.Models.ConfigurationEntity
{
    public class DobavljaciConfiguration : EntityTypeConfiguration<Dobavljaci>
    {
        public DobavljaciConfiguration()
        {
            this.HasKey<int>(k => k.DobavljacId);

            this.Property(n => n.Naziv)
                .IsRequired()
                .HasMaxLength(255);
            this.Property(n => n.KontaktOsoba)
                .IsRequired()
                .HasMaxLength(255);
            this.Property(n => n.Adresa)
                .IsRequired()
                .HasMaxLength(255);
            this.Property(n => n.Telefon)
                .IsRequired()
                .HasMaxLength(255);
            this.Property(n => n.Fax)
                .IsOptional()
                .HasMaxLength(255);
            this.Property(n => n.Web)
                .IsOptional()
                .HasMaxLength(255);
            this.Property(n => n.ZiroRacun)
                .IsRequired();
            this.Property(n => n.Napomena)
                .IsOptional()
                .HasMaxLength(255);
            this.Property(n => n.Status)
                .IsRequired();
        }
    }
}