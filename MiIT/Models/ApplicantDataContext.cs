using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MiIT.Models
{
    public class ApplicantDataContext : IdentityDbContext
    {

        public DbSet<Applicant> Applicant { get; set; }

        public ApplicantDataContext(DbContextOptions<ApplicantDataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
