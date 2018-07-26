using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace DB.Models.ConfigurationEntity
{
    public class OcjenaConfiguration : EntityTypeConfiguration<Ocjene>
    {
        public OcjenaConfiguration()
        {
            this.HasKey<int>(k => k.OcjenaID);

            this.Property(p => p.Datum)
                .IsRequired();
            this.Property(p => p.Ocjena)
                .IsRequired();

            this.HasRequired<Proizvodi>(p => p.Proizvodi).WithMany(p => p.Ocjenes).HasForeignKey<int>(fk => fk.ProizvodID);
        }
       
    }
}