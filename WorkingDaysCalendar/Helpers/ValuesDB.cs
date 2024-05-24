using Microsoft.EntityFrameworkCore;
using WorkingDaysCalendar.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WorkingDaysCalendar.Helpers
{
	public class ValuesDB
	{
		public async Task SetValues(char[] strings, DateTime date)
		{
			using (ApplicationContext db = new ApplicationContext())
			{
				await db.Database.EnsureDeletedAsync();
				foreach (char c in strings)
				{
					Calendar calendar = new Calendar { Date = date, DayOfWeek = date.ToString("dddd"), DayType = int.Parse(c.ToString()) };

					await db.Calendars.AddAsync(calendar);

					date = date.AddDays(1);
				}

				await db.Database.EnsureCreatedAsync();
				await db.SaveChangesAsync();
			}
		}

		public async Task<string> GetDayType(string date)
		{
			using (ApplicationContext db = new ApplicationContext())
			{
				int day = db.Calendars.Where(w => w.Date == DateTime.Parse(date)).Select(s => s.DayType).FirstOrDefaultAsync().Result;

				switch (day)
				{
					case 0: return "рабочий";
					case 1: return "выходной";
					case 2: return "сокращённый";
					default: return null;
				}
			}
		}
	}
}
