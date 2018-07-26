using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace DB.Models.ConfigurationEntity
{
    public class NarudzbeConfiguration : EntityTypeConfiguration<Narudzbe>
    {
        public NarudzbeConfiguration()
        {
            this.HasKey<int>(k => k.NarudzbeID);

            this.Property(p => p.Status).IsRequired();

            this.HasRequired<Kupci>(k => k.Kupci).WithMany(k => k.Narudzbes).HasForeignKey<int>(fk => fk.KupacID);

            this.HasMany<NarudzbaStavke>(n => n.NarudzbaStavkes).WithRequired(n => n.Narudzbe).HasForeignKey<int>(fk => fk.NarudzbaID);
        }
    }
}