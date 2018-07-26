using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace DB.Models.ConfigurationEntity
{
    public class KorisniciUlogaConfiguration : EntityTypeConfiguration<KorisniciUloge>
    {
        public KorisniciUlogaConfiguration()
        {
            this.HasKey<int>(k => k.KorisnikUlogaID);
            this.HasRequired<Korisnici>(k => k.Korisnici).WithMany(ku => ku.KorisniciUloge).HasForeignKey(fk => fk.KorisnikID);

            this.HasRequired<Uloge>(k => k.Uloges).WithMany(ku => ku.KorisniciUloge).HasForeignKey(fk => fk.UlogaID);
        }
    }
}