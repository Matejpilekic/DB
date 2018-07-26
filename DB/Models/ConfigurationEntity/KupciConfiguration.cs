using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace DB.Models.ConfigurationEntity
{
    public class KupciConfiguration : EntityTypeConfiguration<Kupci>
    {
        public KupciConfiguration()
        {
            this.HasKey<int>(k => k.KupacID);

            this.Property(p => p.Ime)
                .HasMaxLength(255)
                .IsRequired();
            this.Property(p => p.Prezime)
                .HasMaxLength(255)
                .IsRequired();
            this.Property(p => p.Email)
                .HasMaxLength(255)
                .IsRequired();
            this.Property(p => p.KorisnickoIme)
                .HasMaxLength(255)
                .IsRequired();
            this.Property(p => p.LozinkaHash)
                .HasMaxLength(255)
                .IsRequired();
            this.Property(p => p.LozinkaSalt)
                .HasMaxLength(255)
                .IsRequired();
            this.Property(p => p.Status)
                .IsRequired();

            this.HasMany<Ocjene>(o => o.Ocjenes).WithRequired(k => k.Kupci).HasForeignKey(fk => fk.KupacID);
        }
    }
}