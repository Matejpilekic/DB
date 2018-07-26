using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace DB.Models.ConfigurationEntity
{
    public class ProizvodiConfiguration : EntityTypeConfiguration<Proizvodi>
    {
        public ProizvodiConfiguration()
        {
            this.HasKey<int>(k => k.ProizvodID);

            this.Property(n => n.Naziv)
                .IsRequired()
                .HasMaxLength(255);
            this.Property(n => n.Sifra)
                .IsRequired()
                .HasMaxLength(255);
            this.Property(n => n.Cijena)
                .IsRequired();
            this.Property(n => n.Slika)
                .IsRequired()
                .HasMaxLength(255);
            this.Property(n => n.SlikaThumb)
                .IsRequired()
                .HasMaxLength(255);
            this.Property(n => n.Status)
                .IsRequired();

            this.HasRequired<JediniceMjere>(j => j.JediniceMjere).WithMany(p => p.Proizvodis).HasForeignKey<int>(fk => fk.JedinicaMjereID);

            this.HasRequired<VrsteProizvoda>(v => v.VrsteProizvoda).WithMany(p => p.Proizvodis).HasForeignKey<int>(fk => fk.VrstaID);

            this.HasMany<IzlazStavke>(i => i.IzlazStavkes).WithRequired(i => i.Proizvodi).HasForeignKey<int>(fk => fk.ProizvodID);
        }
    }
}