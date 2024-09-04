using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApplication7.Models.Data
{
    public class ApplecationDbContext:IdentityDbContext
    {
        public ApplecationDbContext(DbContextOptions<ApplecationDbContext> options)
         : base(options)
        {
        }

    }
}
