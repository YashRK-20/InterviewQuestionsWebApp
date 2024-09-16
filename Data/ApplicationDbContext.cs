using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using InterviewQuestions.Models;

namespace InterviewQuestions.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<InterviewQuestions.Models.Java> Java { get; set; } = default!;
        public DbSet<InterviewQuestions.Models.CS_ASP_NET_Core> CS_ASP_NET_Core { get; set; } = default!;
        public DbSet<InterviewQuestions.Models.SQL> SQL { get; set; } = default!;
        public DbSet<InterviewQuestions.Models.WebProgramming> WebProgramming { get; set; } = default!;
    }
}
