using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NMK.Models;


namespace NMK.Data
{
    public class NMKDbContext : DbContext
    {
        public NMKDbContext (DbContextOptions<NMKDbContext> options)
            : base(options)
        {
        }

    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Admission> Admissions { get; set; }
    
    }
}