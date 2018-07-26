using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using DB.Models.ConfigurationEntity;

namespace DB.Models
{
    public class Context : DbContext
    {

        public DbSet<Korisnici> Korisnicis { get; set; }
        public DbSet<KorisniciUloge> KorisniciUloges { get; set; }
        public DbSet<Uloge> Uloges { get; set; }
        public DbSet<Izlazi> Izlazis { get; set; }
        public DbSet<Ulazi> Ulazis { get; set; }
        public DbSet<Dobavljaci> Dobavljacis { get; set; }
        public DbSet<IzlazStavke> IzlazStavkes { get; set; }
        public DbSet<JediniceMjere> JediniceMjeres { get; set; }
        public DbSet<Kupci> Kupcis { get; set; }
        public DbSet<Narudzbe> Narudzbes { get; set; }
        public DbSet<NarudzbaStavke> NarudzbaStavkes { get; set; }
        public DbSet<Ocjene> Ocjenes { get; set; }
        public DbSet<Proizvodi> Proizvodis { get; set; }
        public DbSet<Skladista> Skladistas { get; set; }
        public DbSet<UlazStavke> UlazStavkes { get; set; }
        public DbSet<VrsteProizvoda> VrsteProizvodas { get; set; }



        public Context(): base()
        {
        }

        public static Context Create()
        {
            return new Context();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new KorisniciEntityConfiguration());
            modelBuilder.Configurations.Add(new UlogaConfiguration());
            modelBuilder.Configurations.Add(new KorisniciUlogaConfiguration());
            modelBuilder.Configurations.Add(new IzlaziConfiguration());
            modelBuilder.Configurations.Add(new UlaziConfiguration());
            modelBuilder.Configurations.Add(new NarudzbeConfiguration());
            modelBuilder.Configurations.Add(new KupciConfiguration());
            modelBuilder.Configurations.Add(new OcjenaConfiguration());
            modelBuilder.Configurations.Add(new NarudzbaStavkeConfiguration());
            modelBuilder.Configurations.Add(new SkladistaConfiguration());
            modelBuilder.Configurations.Add(new UlazStavkeConfiguration());
            modelBuilder.Configurations.Add(new DobavljaciConfiguration());
            modelBuilder.Configurations.Add(new ProizvodiConfiguration());
            modelBuilder.Configurations.Add(new VrstaProizvodaConfiguration());
            modelBuilder.Configurations.Add(new JedinicaMjereConfiguration());
            modelBuilder.Configurations.Add(new IzlazStavkeConfiguration());
        }
    }
}