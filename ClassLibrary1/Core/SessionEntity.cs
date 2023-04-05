using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL.Core
{
	public class SessionEntity
	{
		public int SessionId { get; set; }
		public int? MovieId { get; set; }
		public int? RoomId { get; set; }
		public int? CinemaID { get; set; }
		public System.DateTime SessionDate { get; set; }
		public System.TimeSpan SessionTime { get; set; }
		public int? TicketPrice { get; set; }

		public SessionEntity(int? movieId, int? roomId, int? cinemaID, DateTime sessionDate, TimeSpan sessionTime, int? ticketPrice)
		{
			MovieId = movieId;
			RoomId = roomId;
			CinemaID = cinemaID;
			SessionDate = sessionDate;
			SessionTime = sessionTime;
			TicketPrice = ticketPrice;
		}
	}
}
