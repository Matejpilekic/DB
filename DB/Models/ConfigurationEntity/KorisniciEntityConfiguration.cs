using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace DB.Models.ConfigurationEntity
{
    public class KorisniciEntityConfiguration : EntityTypeConfiguration<Korisnici>
    {
        public KorisniciEntityConfiguration()
        {
            this.ToTable("Korisnici");

            this.HasKey<int>(k => k.KorisnikID);

            this.Property(p => p.Ime)
                .IsRequired()
                .HasMaxLength(255);
            this.Property(p => p.Prezime)
                .IsRequired()
                .HasMaxLength(255);
            this.Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(255);
            this.Property(p => p.Telefon)
                .IsRequired()
                .HasMaxLength(255);
            this.Property(p => p.KorisnickoIme)
                .IsRequired()
                .HasMaxLength(255);
            this.Property(p => p.LozinkaHash)
                .IsRequired()
                .HasMaxLength(255);
            this.Property(p => p.LozinkaSalt)
                .IsRequired()
                .HasMaxLength(255);
            this.Property(p => p.Status)
                .IsRequired();

            this.HasMany<Izlazi>(i => i.Izlazis).WithRequired(i => i.Korisnici).HasForeignKey<int>(fk => fk.KorisnikID);

            this.HasMany<Ulazi>(u => u.Ulazis).WithRequired(k => k.Korisnici).HasForeignKey<int>(fk => fk.KorisnikID);
        }
    }
}