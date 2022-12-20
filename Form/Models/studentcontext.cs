using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Form.Models
{
    public class studentcontext:DbContext
    {
        public DbSet<Student>students { get; set; }
    }
}