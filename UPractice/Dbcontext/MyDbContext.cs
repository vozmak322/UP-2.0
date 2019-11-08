using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPractice.Dbcontext
{
    public class MyDbcontext : DbContext
    {
        public MyDbcontext() : base("MyDb") { }
        public DbSet<Chair> Chairs { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
    }
}
