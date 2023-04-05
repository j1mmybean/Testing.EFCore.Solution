using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL.Core
{
	public class SeatEntity
	{
		public int SeatID { get; set; }
		public int RoomID { get; set; }
		public string SeatRow { get; set; }
		public int SeatColumn { get; set; }


		public SeatEntity( int roomID, string seatRow, int seatColumn)
		{
			RoomID = roomID;
			SeatRow = seatRow;
			SeatColumn = seatColumn;
		}
	}
}
