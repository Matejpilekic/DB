using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace DB.Models.ConfigurationEntity
{
    public class IzlaziConfiguration : EntityTypeConfiguration<Izlazi>
    {
        public IzlaziConfiguration()
        {
            this.HasKey<int>(k => k.IzlazID);

            this.Property(p => p.Zakljucen).IsRequired();

            this.HasMany<IzlazStavke>(i => i.IzlazStavke).WithRequired(i => i.Izlazi).HasForeignKey<int>(fk => fk.IzlazID);

            this.HasRequired<Narudzbe>(n => n.Narudzbe).WithMany(a => a.Izlazis).HasForeignKey<int>(fk => fk.NaruzdbaID);

            this.HasRequired<Skladista>(s => s.Skladista).WithMany(i => i.Izlazis).HasForeignKey<int>(fk => fk.SkladisteID);
        }
    }
}