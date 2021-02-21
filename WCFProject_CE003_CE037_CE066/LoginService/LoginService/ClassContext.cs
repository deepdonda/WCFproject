using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LoginService
{
    public class ClassContext:DbContext
    {
        public DbSet<Art> Arts { get; set; }
        public ClassContext() : base("constring")
        {

        }
    }
}