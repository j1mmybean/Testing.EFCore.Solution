using ISpan.Inseparable.BLL.Dtos;
using ISpan.Inseparable.BLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL
{
	public class TicketOrderService
	{
		public readonly ITicketOrderRepository repo;

		public TicketOrderService(ITicketOrderRepository repo)
		{
			this.repo = repo;
		}

		public void Create(TicketOrderCreateDto dto)
		{
			var entity = dto.ToEntity();

			var entityInDb = repo.GetBySeat(dto.SeatID,dto.SessionID);
			if (entityInDb != null ) throw new Exception("該場次此座位已被選走!!");

			repo.Create(entity);
		}

		public void Update(TicketOrderUpdateDto dto)
		{
			var entity = dto.ToEntity();

			var entityInDb = repo.GetBySeat(dto.SeatID, dto.SessionID);
			if (entityInDb != null && entityInDb.OrderID != dto.OrderID && entityInDb.TicketItem_no != dto.TicketItem_no) throw new Exception("該場次此座位已被選走!!");

			repo.Update(entity);
		}
	}
}
