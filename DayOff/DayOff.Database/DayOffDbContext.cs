using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayOff.Database
{
    public class DayOffDbContext : IdentityDbContext<IdentityUser>
    {
        public DayOffDbContext(DbContextOptions<DayOffDbContext> options)
            : base(options)
        {

        }
    }
}
