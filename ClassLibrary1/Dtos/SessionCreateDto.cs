using ISpan.Inseparable.BLL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL.Dtos
{
	public class SessionCreateDto
	{
		public int SessionId { get; set; }
		public int? MovieId { get; set; }
		public int? RoomId { get; set; }
		public int? CinemaID { get; set; }
		public System.DateTime SessionDate { get; set; }
		public System.TimeSpan SessionTime { get; set; }
		public int? TicketPrice { get; set; }
	}

	public static class SessionCreateDtoExtension
	{
		public static SessionEntity ToEntity(this SessionCreateDto dto)
		{
			return new SessionEntity(dto.MovieId, dto.RoomId, dto.CinemaID, dto.SessionDate, dto.SessionTime, dto.TicketPrice);
		}
	}
}
