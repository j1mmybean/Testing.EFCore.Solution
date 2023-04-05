using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL.Core
{
	public class RoomEntity
	{
		public int RoomID { get; set; }
		public int CinemaID { get; set; }
		public string RoomName { get; set; }


		public RoomEntity( int cinemaID, string roomName)
		{
			CinemaID = cinemaID;
			RoomName = roomName;
		}
	}
}
