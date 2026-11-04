using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class GymDbContext : DbContext
    {
        public GymDbContext(DbContextOptions<GymDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers => Set<ApplicationUser>();
        public DbSet<Member> Members => Set<Member>();
        public DbSet<Trainer> Trainers => Set<Trainer>();
        public DbSet<WorkoutClass> WorkoutClasses => Set<WorkoutClass>();
        public DbSet<MembershipPlan> MembershipPlans => Set<MembershipPlan>();
        public DbSet<Subscription> Subscriptions => Set<Subscription>();
        public DbSet<ClassReservation> ClassReservations => Set<ClassReservation>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MembershipPlan>()
                .Property(p => p.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Trainer>()
                .Property(t => t.Salary)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Member>()
                .HasOne(m => m.User)
                .WithOne(u => u.Member)
                .HasForeignKey<Member>(m => m.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Trainer>()
                .HasOne(t => t.User)
                .WithOne(u => u.Trainer)
                .HasForeignKey<Trainer>(t => t.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WorkoutClass>()
                .HasOne(w => w.Trainer)
                .WithMany(t => t.WorkoutClasses)
                .HasForeignKey(w => w.TrainerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Subscription>()
                .HasOne(s => s.Member)
                .WithMany(m => m.Subscriptions)
                .HasForeignKey(s => s.MemberId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Subscription>()
                .HasOne(s => s.MembershipPlan)
                .WithMany(p => p.Subscriptions)
                .HasForeignKey(s => s.MembershipPlanId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ClassReservation>()
                .HasOne(r => r.Member)
                .WithMany(m => m.Reservations)
                .HasForeignKey(r => r.MemberId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ClassReservation>()
                .HasOne(r => r.WorkoutClass)
                .WithMany(w => w.Reservations)
                .HasForeignKey(r => r.WorkoutClassId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ClassReservation>()
                .HasOne(r => r.MembershipPlan)
                .WithMany(p => p.Reservations)
                .HasForeignKey(r => r.MembershipPlanId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}