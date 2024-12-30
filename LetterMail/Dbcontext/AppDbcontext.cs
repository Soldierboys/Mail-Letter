using LetterMail.Components.Pages;
using LetterMail.Models;
using Microsoft.EntityFrameworkCore;


public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<CertificationLetter> CertificationLetters { get; set; }
    public DbSet<AppointmentLetter> AppointmentLetters { get; set; }
    public DbSet<RelievingLetter> RelievingLetters { get; set; }
    public DbSet<SalaryIncrement> SalaryIncrements { get; set; }
    public DbSet<LetterMail.Models.ExperienceLetter> ExperienceLetters { get; set; }

}
