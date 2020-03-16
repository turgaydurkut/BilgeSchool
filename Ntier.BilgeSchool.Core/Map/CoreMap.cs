using Ntier.BilgeSchool.Core.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ntier.BilgeSchool.Core.Map
{
    public class CoreMap<T>:EntityTypeConfiguration<T> where T:CoreEntity
    {
        public CoreMap()
        {
            Property(x => x.ID).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);


            Property(x => x.Status).IsOptional();
            Property(x => x.CreatedDate).IsOptional();
            Property(x => x.CreatedComputerName).IsOptional();
            Property(x => x.CreatedIP).IsOptional();
            Property(x => x.CreatedAdUserName).IsOptional();
            Property(x => x.CreatedBy).IsOptional();


            Property(x => x.ModifiedIP).IsOptional();
            Property(x => x.ModifiedDate).IsOptional();
            Property(x => x.ModifiedComputerName).IsOptional();
            Property(x => x.ModifiedAdUserName).IsOptional();
            Property(x => x.ModifiedBy).IsOptional();
        }
    }
}
