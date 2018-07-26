using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace DB.Models.ConfigurationEntity
{
    public class UlazStavkeConfiguration : EntityTypeConfiguration<UlazStavke>
    {
        public UlazStavkeConfiguration()
        {
            this.HasKey<int>(k => k.UlazStavkeID);

            this.HasRequired<Proizvodi>(p => p.Proizvodi).WithMany(u => u.UlazStavkes).HasForeignKey<int>(fk => fk.ProizvodID);

        }
    }
}