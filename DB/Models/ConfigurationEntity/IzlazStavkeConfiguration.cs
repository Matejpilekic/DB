using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace DB.Models.ConfigurationEntity
{
    public class IzlazStavkeConfiguration : EntityTypeConfiguration<IzlazStavke>
    {
        public IzlazStavkeConfiguration()
        {
            this.HasKey<int>(k => k.IzlazStavkaID);
        }
    }
}