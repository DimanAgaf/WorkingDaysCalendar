using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestSharp;
using WorkingDaysCalendar.Entities;
using WorkingDaysCalendar.Helpers;

namespace WorkingDaysCalendar.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CalendarController : ControllerBase
	{
		private GetRestRequest _getRestRequest;
		private ValuesDB _valuesDB;

		public CalendarController(GetRestRequest getRestRequest, ValuesDB valuesDB)
		{
			_getRestRequest = getRestRequest;
			_valuesDB = valuesDB;
		}

		/// <summary>
		/// Метод для определения типа дня.
		/// </summary>
		/// <param name="date">Искомая дата.</param>
		/// <returns>Ok or BadRequest</returns>
		[HttpGet]
		public async Task<IActionResult> Get(string date)
		{
			try
			{
				string dayType = await _valuesDB.GetDayType(date);

				if (dayType == null)
					return BadRequest("День отсутствует!");

				return Ok(dayType);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		/// <summary>
		///	Метод заполнения БД.
		/// </summary>
		/// <returns>Ok or BadRequest</returns>
		[HttpPost]
		public async Task<IActionResult> Post()
		{
			try
			{
				char[] chars = await _getRestRequest.ExecuteAsync();

				DateTime date = DateTime.Parse("01.01.2023");

				await _valuesDB.SetValues(chars, date);

				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
