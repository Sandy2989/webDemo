using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DemoApi.ViewModel;

namespace DemoApi.Data
{
    public class DemoApiContext : DbContext
    {
        public DemoApiContext (DbContextOptions<DemoApiContext> options)
            : base(options)
        {
        }

        public DbSet<DemoApi.ViewModel.PersonViewModel> PersonViewModel { get; set; }
    }
}
