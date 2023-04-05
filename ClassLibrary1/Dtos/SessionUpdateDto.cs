using ISpan.Inseparable.BLL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL.Dtos
{
	public class SessionUpdateDto
	{
		public int SessionId { get; set; }
		public int? MovieId { get; set; }
		public int? RoomId { get; set; }
		public int? CinemaID { get; set; }
		public System.DateTime SessionDate { get; set; }
		public System.TimeSpan SessionTime { get; set; }
		public int? TicketPrice { get; set; }
	}

	public static class SessionUpdateDtoExtension
	{
		public static SessionEntity ToEntity(this SessionUpdateDto dto)
		{
			return new SessionEntity(dto.MovieId, dto.RoomId, dto.CinemaID, dto.SessionDate, dto.SessionTime, dto.TicketPrice)
			{
				SessionId=dto.SessionId,
			};
		}
	}
}
