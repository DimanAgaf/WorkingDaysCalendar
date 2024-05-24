using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WorkingDaysCalendar.Entities
{
	public class Calendar
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public DateTime Date { get; set; }
		public string DayOfWeek { get; set; }
		public int DayType { get; set; }
	}
}
