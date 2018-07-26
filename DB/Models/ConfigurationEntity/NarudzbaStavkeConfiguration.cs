using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace DB.Models.ConfigurationEntity
{
    public class NarudzbaStavkeConfiguration : EntityTypeConfiguration<NarudzbaStavke>
    {
        public NarudzbaStavkeConfiguration()
        {
            this.HasKey<int>(k => k.NarudzbaStavkaID);

            this.Property(p => p.Kolicina)
                .IsRequired();

            this.HasRequired<Proizvodi>(p => p.Proizvodi).WithMany(p => p.NarudzbaStavkes).HasForeignKey<int>(fk => fk.ProizvodID);
        }
    }
}