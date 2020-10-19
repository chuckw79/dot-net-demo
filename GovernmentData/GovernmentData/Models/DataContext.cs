using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GovernmentData.Models
{
    public class DataContext : DbContext
    {
        public DbSet<AwardRecipient> AwardRecipients { get; set; }
    }
}