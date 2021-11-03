using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<Feedback> Feedbacks { get; set; }

        public MyDbContext()
        {

        }
        public MyDbContext(DbContextOptions<MyDbContext> options): base(options)
        {

        }
    }

}
