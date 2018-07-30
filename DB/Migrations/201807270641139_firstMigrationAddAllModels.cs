namespace DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstMigrationAddAllModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dobavljacis",
                c => new
                    {
                        DobavljacId = c.Int(nullable: false, identity: true),
                        Naziv = c.String(nullable: false, maxLength: 255),
                        KontaktOsoba = c.String(nullable: false, maxLength: 255),
                        Adresa = c.String(nullable: false, maxLength: 255),
                        Telefon = c.String(nullable: false, maxLength: 255),
                        Fax = c.String(maxLength: 255),
                        Web = c.String(maxLength: 255),
                        Email = c.String(),
                        ZiroRacun = c.Int(nullable: false),
                        Napomena = c.String(maxLength: 255),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DobavljacId);
            
            CreateTable(
                "dbo.Ulazis",
                c => new
                    {
                        UlaziID = c.Int(nullable: false, identity: true),
                        BrojFakture = c.String(nullable: false, maxLength: 255),
                        Datum = c.DateTime(nullable: false),
                        IznosRacuna = c.Single(nullable: false),
                        PDV = c.Int(nullable: false),
                        Napomena = c.String(),
                        SkladisteID = c.Int(nullable: false),
                        KorisnikID = c.Int(nullable: false),
                        DobavljacID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UlaziID)
                .ForeignKey("dbo.Dobavljacis", t => t.DobavljacID, cascadeDelete: true)
                .ForeignKey("dbo.Skladistas", t => t.SkladisteID, cascadeDelete: true)
                .ForeignKey("dbo.Korisnici", t => t.KorisnikID, cascadeDelete: true)
                .Index(t => t.SkladisteID)
                .Index(t => t.KorisnikID)
                .Index(t => t.DobavljacID);
            
            CreateTable(
                "dbo.Korisnici",
                c => new
                    {
                        KorisnikID = c.Int(nullable: false, identity: true),
                        Ime = c.String(nullable: false, maxLength: 255),
                        Prezime = c.String(nullable: false, maxLength: 255),
                        Email = c.String(nullable: false, maxLength: 255),
                        Telefon = c.String(nullable: false, maxLength: 255),
                        KorisnickoIme = c.String(nullable: false, maxLength: 255),
                        LozinkaHash = c.String(nullable: false, maxLength: 255),
                        LozinkaSalt = c.String(nullable: false, maxLength: 255),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.KorisnikID);
            
            CreateTable(
                "dbo.Izlazis",
                c => new
                    {
                        IzlazID = c.Int(nullable: false, identity: true),
                        BrojRacuna = c.Int(nullable: false),
                        Datum = c.DateTime(nullable: false),
                        KorisnikID = c.Int(nullable: false),
                        Zakljucen = c.Boolean(nullable: false),
                        IznosBezPDV = c.Single(nullable: false),
                        IznosSaPDV = c.Single(nullable: false),
                        NaruzdbaID = c.Int(nullable: false),
                        SkladisteID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IzlazID)
                .ForeignKey("dbo.Narudzbes", t => t.NaruzdbaID, cascadeDelete: true)
                .ForeignKey("dbo.Skladistas", t => t.SkladisteID, cascadeDelete: true)
                .ForeignKey("dbo.Korisnici", t => t.KorisnikID, cascadeDelete: true)
                .Index(t => t.KorisnikID)
                .Index(t => t.NaruzdbaID)
                .Index(t => t.SkladisteID);
            
            CreateTable(
                "dbo.IzlazStavkes",
                c => new
                    {
                        IzlazStavkaID = c.Int(nullable: false, identity: true),
                        IzlazID = c.Int(nullable: false),
                        ProizvodID = c.Int(nullable: false),
                        Kolicina = c.Int(nullable: false),
                        Cijena = c.Single(nullable: false),
                        Popust = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IzlazStavkaID)
                .ForeignKey("dbo.Proizvodis", t => t.ProizvodID, cascadeDelete: true)
                .ForeignKey("dbo.Izlazis", t => t.IzlazID, cascadeDelete: true)
                .Index(t => t.IzlazID)
                .Index(t => t.ProizvodID);
            
            CreateTable(
                "dbo.Proizvodis",
                c => new
                    {
                        ProizvodID = c.Int(nullable: false, identity: true),
                        Naziv = c.String(nullable: false, maxLength: 255),
                        Sifra = c.String(nullable: false, maxLength: 255),
                        Cijena = c.Single(nullable: false),
                        VrstaID = c.Int(nullable: false),
                        JedinicaMjereID = c.Int(nullable: false),
                        Slika = c.String(nullable: false, maxLength: 255),
                        SlikaThumb = c.String(nullable: false, maxLength: 255),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProizvodID)
                .ForeignKey("dbo.JediniceMjeres", t => t.JedinicaMjereID, cascadeDelete: true)
                .ForeignKey("dbo.VrsteProizvodas", t => t.VrstaID, cascadeDelete: true)
                .Index(t => t.VrstaID)
                .Index(t => t.JedinicaMjereID);
            
            CreateTable(
                "dbo.JediniceMjeres",
                c => new
                    {
                        JediniceMjereID = c.Int(nullable: false, identity: true),
                        Naziv = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.JediniceMjereID);
            
            CreateTable(
                "dbo.NarudzbaStavkes",
                c => new
                    {
                        NarudzbaStavkaID = c.Int(nullable: false, identity: true),
                        NarudzbaID = c.Int(nullable: false),
                        ProizvodID = c.Int(nullable: false),
                        Kolicina = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NarudzbaStavkaID)
                .ForeignKey("dbo.Narudzbes", t => t.NarudzbaID, cascadeDelete: true)
                .ForeignKey("dbo.Proizvodis", t => t.ProizvodID, cascadeDelete: true)
                .Index(t => t.NarudzbaID)
                .Index(t => t.ProizvodID);
            
            CreateTable(
                "dbo.Narudzbes",
                c => new
                    {
                        NarudzbeID = c.Int(nullable: false, identity: true),
                        BrojNarudzbe = c.Int(nullable: false),
                        KupacID = c.Int(nullable: false),
                        Datum = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Otkazano = c.DateTime(),
                    })
                .PrimaryKey(t => t.NarudzbeID)
                .ForeignKey("dbo.Kupcis", t => t.KupacID, cascadeDelete: true)
                .Index(t => t.KupacID);
            
            CreateTable(
                "dbo.Kupcis",
                c => new
                    {
                        KupacID = c.Int(nullable: false, identity: true),
                        Ime = c.String(nullable: false, maxLength: 255),
                        Prezime = c.String(nullable: false, maxLength: 255),
                        DatumRegistracije = c.DateTime(nullable: false),
                        Email = c.String(nullable: false, maxLength: 255),
                        KorisnickoIme = c.String(nullable: false, maxLength: 255),
                        LozinkaHash = c.String(nullable: false, maxLength: 255),
                        LozinkaSalt = c.String(nullable: false, maxLength: 255),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.KupacID);
            
            CreateTable(
                "dbo.Ocjenes",
                c => new
                    {
                        OcjenaID = c.Int(nullable: false, identity: true),
                        ProizvodID = c.Int(nullable: false),
                        KupacID = c.Int(nullable: false),
                        Datum = c.DateTime(nullable: false),
                        Ocjena = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OcjenaID)
                .ForeignKey("dbo.Proizvodis", t => t.ProizvodID, cascadeDelete: true)
                .ForeignKey("dbo.Kupcis", t => t.KupacID, cascadeDelete: true)
                .Index(t => t.ProizvodID)
                .Index(t => t.KupacID);
            
            CreateTable(
                "dbo.UlazStavkes",
                c => new
                    {
                        UlazStavkeID = c.Int(nullable: false, identity: true),
                        UlazID = c.Int(nullable: false),
                        ProizvodID = c.Int(nullable: false),
                        Kolicina = c.Int(nullable: false),
                        Cijena = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.UlazStavkeID)
                .ForeignKey("dbo.Proizvodis", t => t.ProizvodID, cascadeDelete: true)
                .ForeignKey("dbo.Ulazis", t => t.UlazID, cascadeDelete: true)
                .Index(t => t.UlazID)
                .Index(t => t.ProizvodID);
            
            CreateTable(
                "dbo.VrsteProizvodas",
                c => new
                    {
                        VrstaID = c.Int(nullable: false, identity: true),
                        Naziv = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.VrstaID);
            
            CreateTable(
                "dbo.Skladistas",
                c => new
                    {
                        SkladisteID = c.Int(nullable: false, identity: true),
                        Naziv = c.String(nullable: false, maxLength: 255),
                        Adresa = c.String(nullable: false, maxLength: 255),
                        Opis = c.String(),
                    })
                .PrimaryKey(t => t.SkladisteID);
            
            CreateTable(
                "dbo.KorisniciUloges",
                c => new
                    {
                        KorisnikUlogaID = c.Int(nullable: false, identity: true),
                        KorisnikID = c.Int(nullable: false),
                        UlogaID = c.Int(nullable: false),
                        DatumIzmjene = c.DateTime(),
                    })
                .PrimaryKey(t => t.KorisnikUlogaID)
                .ForeignKey("dbo.Korisnici", t => t.KorisnikID, cascadeDelete: true)
                .ForeignKey("dbo.Uloges", t => t.UlogaID, cascadeDelete: true)
                .Index(t => t.KorisnikID)
                .Index(t => t.UlogaID);
            
            CreateTable(
                "dbo.Uloges",
                c => new
                    {
                        UlogaID = c.Int(nullable: false, identity: true),
                        Naziv = c.String(nullable: false, maxLength: 255),
                        Opis = c.String(),
                    })
                .PrimaryKey(t => t.UlogaID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UlazStavkes", "UlazID", "dbo.Ulazis");
            DropForeignKey("dbo.Ulazis", "KorisnikID", "dbo.Korisnici");
            DropForeignKey("dbo.KorisniciUloges", "UlogaID", "dbo.Uloges");
            DropForeignKey("dbo.KorisniciUloges", "KorisnikID", "dbo.Korisnici");
            DropForeignKey("dbo.Izlazis", "KorisnikID", "dbo.Korisnici");
            DropForeignKey("dbo.Izlazis", "SkladisteID", "dbo.Skladistas");
            DropForeignKey("dbo.Ulazis", "SkladisteID", "dbo.Skladistas");
            DropForeignKey("dbo.Izlazis", "NaruzdbaID", "dbo.Narudzbes");
            DropForeignKey("dbo.IzlazStavkes", "IzlazID", "dbo.Izlazis");
            DropForeignKey("dbo.Proizvodis", "VrstaID", "dbo.VrsteProizvodas");
            DropForeignKey("dbo.UlazStavkes", "ProizvodID", "dbo.Proizvodis");
            DropForeignKey("dbo.NarudzbaStavkes", "ProizvodID", "dbo.Proizvodis");
            DropForeignKey("dbo.NarudzbaStavkes", "NarudzbaID", "dbo.Narudzbes");
            DropForeignKey("dbo.Narudzbes", "KupacID", "dbo.Kupcis");
            DropForeignKey("dbo.Ocjenes", "KupacID", "dbo.Kupcis");
            DropForeignKey("dbo.Ocjenes", "ProizvodID", "dbo.Proizvodis");
            DropForeignKey("dbo.Proizvodis", "JedinicaMjereID", "dbo.JediniceMjeres");
            DropForeignKey("dbo.IzlazStavkes", "ProizvodID", "dbo.Proizvodis");
            DropForeignKey("dbo.Ulazis", "DobavljacID", "dbo.Dobavljacis");
            DropIndex("dbo.KorisniciUloges", new[] { "UlogaID" });
            DropIndex("dbo.KorisniciUloges", new[] { "KorisnikID" });
            DropIndex("dbo.UlazStavkes", new[] { "ProizvodID" });
            DropIndex("dbo.UlazStavkes", new[] { "UlazID" });
            DropIndex("dbo.Ocjenes", new[] { "KupacID" });
            DropIndex("dbo.Ocjenes", new[] { "ProizvodID" });
            DropIndex("dbo.Narudzbes", new[] { "KupacID" });
            DropIndex("dbo.NarudzbaStavkes", new[] { "ProizvodID" });
            DropIndex("dbo.NarudzbaStavkes", new[] { "NarudzbaID" });
            DropIndex("dbo.Proizvodis", new[] { "JedinicaMjereID" });
            DropIndex("dbo.Proizvodis", new[] { "VrstaID" });
            DropIndex("dbo.IzlazStavkes", new[] { "ProizvodID" });
            DropIndex("dbo.IzlazStavkes", new[] { "IzlazID" });
            DropIndex("dbo.Izlazis", new[] { "SkladisteID" });
            DropIndex("dbo.Izlazis", new[] { "NaruzdbaID" });
            DropIndex("dbo.Izlazis", new[] { "KorisnikID" });
            DropIndex("dbo.Ulazis", new[] { "DobavljacID" });
            DropIndex("dbo.Ulazis", new[] { "KorisnikID" });
            DropIndex("dbo.Ulazis", new[] { "SkladisteID" });
            DropTable("dbo.Uloges");
            DropTable("dbo.KorisniciUloges");
            DropTable("dbo.Skladistas");
            DropTable("dbo.VrsteProizvodas");
            DropTable("dbo.UlazStavkes");
            DropTable("dbo.Ocjenes");
            DropTable("dbo.Kupcis");
            DropTable("dbo.Narudzbes");
            DropTable("dbo.NarudzbaStavkes");
            DropTable("dbo.JediniceMjeres");
            DropTable("dbo.Proizvodis");
            DropTable("dbo.IzlazStavkes");
            DropTable("dbo.Izlazis");
            DropTable("dbo.Korisnici");
            DropTable("dbo.Ulazis");
            DropTable("dbo.Dobavljacis");
        }
    }
}
