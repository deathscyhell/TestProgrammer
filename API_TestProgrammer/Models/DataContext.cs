using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProgrammer_API.Models;

namespace API_TestProgrammer.Models
{
    public class DataContext : DbContext
    {
        public DbSet<Tbl_Employees> Empleoyees { get; set; }
        public DbSet<Tbl_Positions> Positions { get; set; }
        public DbSet<Tbl_Profiles> Profiles { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { 
        
        }
    }
}
