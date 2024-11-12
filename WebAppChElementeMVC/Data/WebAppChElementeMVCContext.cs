using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAppChElementeMVC.Models;

namespace WebAppChElementeMVC.Data
{
    public class WebAppChElementeMVCContext : DbContext
    {
        public WebAppChElementeMVCContext (DbContextOptions<WebAppChElementeMVCContext> options)
            : base(options)
        {
        }

        public DbSet<WebAppChElementeMVC.Models.Element> Element { get; set; } = default!;
        public DbSet<WebAppChElementeMVC.Models.Gruppe> Gruppe { get; set; } = default!;
        public DbSet<WebAppChElementeMVC.Models.Periode> Periode { get; set; } = default!;
        public DbSet<WebAppChElementeMVC.Models.Zustand> Zustand { get; set; } = default!;
    }
}
