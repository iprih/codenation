using Microsoft.EntityFrameworkCore;
using Models.Configurations;
using Source.Challenge.Models.Configurations;

namespace Codenation.Challenge.Models
{
    public class CodenationContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Acceleration> Accelerations { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Challenge> Challenges { get; set; }
        public DbSet<Submission> Submissions { get; set; }
        public DbSet<User> Users { get; set; }
                        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Codenation;Trusted_Connection=True");            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CandidateConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new SubmissionConfiguration());
            modelBuilder.ApplyConfiguration(new AccelerationConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ChallengeConfiguration());

            //modelBuilder.ApplyConfiguration(new SubmissionConfiguration());
        }
    }
}