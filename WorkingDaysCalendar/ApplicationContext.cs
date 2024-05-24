using Microsoft.EntityFrameworkCore;
using WorkingDaysCalendar.Entities;

namespace WorkingDaysCalendar
{
	public class ApplicationContext : DbContext
	{
		public DbSet<Calendar> Calendars { get; set; } = null!;

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			IConfigurationRoot configuration = new ConfigurationBuilder()
			.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
			.AddJsonFile("appsettings.json")
			.Build();
			optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
		}
	}
}
