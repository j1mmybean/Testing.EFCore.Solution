using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL.Core
{
	public class TicketOrderEntity
	{
		public int TicketItem_no { get; set; }
		public int OrderID { get; set; }
		public int MovieID { get; set; }
		public int SessionID { get; set; }
		public int SeatID { get; set; }
		public int RoomID { get; set; }
		public int TicketUnitprice { get; set; }
		public decimal TicketDiscount { get; set; }
		public int TicketSubtotal { get; set; }

		public TicketOrderEntity(int ticketItem_no, int orderID, int movieID, int sessionID, int seatID, int roomID, int ticketUnitprice, decimal ticketDiscount, int ticketSubtotal)
		{
			TicketItem_no = ticketItem_no;
			OrderID = orderID;
			MovieID = movieID;
			SessionID = sessionID;
			SeatID = seatID;
			RoomID = roomID;
			TicketUnitprice = ticketUnitprice;
			TicketDiscount = ticketDiscount;
			TicketSubtotal = ticketSubtotal;
		}
	}
}
