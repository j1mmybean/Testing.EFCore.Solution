using ISpan.Inseparable.BLL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL.Dtos
{
	public class TicketOrderCreateDto
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
	}
	public static class TicketOrderCreateDtoExtension
	{
		public static TicketOrderEntity ToEntity(this TicketOrderCreateDto dto)
		{
			return new TicketOrderEntity(dto.TicketItem_no, dto.OrderID, dto.MovieID, dto.SessionID, dto.SeatID, dto.RoomID, dto.TicketUnitprice, dto.TicketDiscount, dto.TicketSubtotal);
		}
	}
}
