using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class MainDbContext : DbContext
    {
        protected MainDbContext()
        {
        }
        public MainDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<File> Files { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<File>(p =>
            {
                p.HasKey(e => new {
                    FileID = e.FileId,
                });
                p.Property(e => e.FileName).IsRequired().HasMaxLength(100);
                p.Property(e => e.FileExtension).IsRequired().HasMaxLength(4);
                p.Property(e => e.FileSize).IsRequired();
                p.HasOne(e => e.Team).WithMany(e => e.Files).HasForeignKey(e => e.TeamId);
            //seedowanie
            p.HasData(
                new File { FileId = 1, FileName = "Blabla", FileExtension = "txt", FileSize = 35 });
            });

            modelBuilder.Entity<Member>(d =>
            {
                d.HasKey(e => e.MemberId);
                d.Property(e => e.MemberName).IsRequired().HasMaxLength(20);
                d.Property(e => e.MemberSurname).IsRequired().HasMaxLength(50);
                d.Property(e => e.MemberNickName).HasMaxLength(20);
                d.HasOne(e => e.Organization).WithMany(e => e.Members).HasForeignKey(e => e.OrganizationId);
                //seedowanie
                d.HasData(
                    new Member { MemberId = 2, MemberName = "Adam", MemberSurname = "Nowak", MemberNickName = "an" });
            });

            modelBuilder.Entity<Membership>(p =>
            {
                p.HasKey(e => new {
                    MemberID = e.MemberId,
                    TeamID = e.TeamId
                });
                p.Property(e => e.MembershipDate).IsRequired();
                p.HasOne(e => e.Member).WithMany(e => e.Memberships).HasForeignKey(e => e.MemberId);
                p.HasOne(e => e.Team).WithMany(e => e.Memberships).HasForeignKey(e => e.TeamId);
                p.HasData(
                    new Membership { MemberId = 1, TeamId = 1, MembershipDate = DateTime.Parse("2022-01-01") });
            });
            modelBuilder.Entity<Organization>(m =>
            {
                m.HasKey(e => e.OrganizationId);
                m.Property(e => e.OrganizationName).IsRequired().HasMaxLength(100);
                m.Property(e => e.OrganizationDomain).IsRequired().HasMaxLength(50);
                m.HasData(
                    new Organization { OrganizationId = 1, OrganizationName = "AB", OrganizationDomain = "www.ab.pl"});
            });
            modelBuilder.Entity<Team>(p =>
            {
                p.HasKey(e => e.TeamId);
                p.Property(e => e.TeamName).IsRequired().HasMaxLength(50);
                p.Property(e => e.TeamDescription).HasMaxLength(500);
                p.HasOne(e => e.Organization).WithMany(e => e.Teams).HasForeignKey(e => e.OrganizationId);
                p.HasData(
                    new Team { TeamId = 1, TeamName = "asd", TeamDescription = "agksagdk" });
            });
        }
    }
}
