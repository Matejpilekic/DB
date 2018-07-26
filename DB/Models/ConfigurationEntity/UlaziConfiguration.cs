using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace DB.Models.ConfigurationEntity
{
    public class UlaziConfiguration : EntityTypeConfiguration<Ulazi>
    {
        public UlaziConfiguration()
        {
            this.HasKey<int>(k => k.UlaziID);

            this.Property(p => p.BrojFakture)
                .HasMaxLength(255)
                .IsRequired();

            this.HasMany<UlazStavke>(u => u.UlazStavkes).WithRequired(u => u.Ulazi).HasForeignKey<int>(fk => fk.UlazID);

            this.HasRequired<Dobavljaci>(d => d.Dobavljaci).WithMany(u => u.Ulazis).HasForeignKey<int>(fk => fk.DobavljacID);
        }
    }
}