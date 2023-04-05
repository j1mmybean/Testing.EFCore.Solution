using ISpan.Inseparable.BLL.Core;
using ISpan.Inseparable.BLL.Interface;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.SqlDataLayer
{
	public class TicketOrderDetailRepository:ITicketOrderRepository
	{

		public IQueryable<TicketOrderDetails> Search(int? orderId,int? memberId)
		{
			InseparableEntities InseparableDb = new InseparableEntities();
			IQueryable<TicketOrderDetails> search = InseparableDb.TicketOrderDetails;

			if (orderId != null) search = search.Where(t => t.OrderID == orderId);
			if (memberId != null) search = search.Where(t => t.Orders.MemberID == memberId);
			return search;
		}

		public TicketOrderDetails GetTicketOrderDetails(int item_no,int orderId)
		{
			InseparableEntities InseparableDb = new InseparableEntities();
			var get = InseparableDb.TicketOrderDetails.Where(t=>t.OrderID==orderId).Single(t => t.TicketItem_no==item_no);
			return get;
		}

		public void Create(TicketOrderEntity entity)
		{
			InseparableEntities InseparableDb = new InseparableEntities();
			TicketOrderDetails T = new TicketOrderDetails();

			T.TicketItem_no=entity.TicketItem_no;
			T.OrderID=entity.OrderID;
			T.MovieID = entity.MovieID;
			T.RoomID = entity.RoomID;
			T.SessionID = entity.SessionID;
			T.SeatID= entity.SeatID;
			T.TicketUnitprice=entity.TicketUnitprice;
			T.TicketDiscount= entity.TicketDiscount;
			T.TicketSubtotal=entity.TicketSubtotal;

			try
			{
				InseparableDb.TicketOrderDetails.Add(T);
				InseparableDb.SaveChanges();
			}catch(SqlException ex) { throw new Exception(ex.Message); }

		}

		public void Update(TicketOrderEntity entity)
		{
			InseparableEntities InseparableDb = new InseparableEntities();
			var edit =InseparableDb.TicketOrderDetails.Where(t=>t.OrderID==entity.OrderID).Single(t=>t.TicketItem_no==entity.TicketItem_no);

			edit.MovieID = entity.MovieID;
			edit.RoomID = entity.RoomID;
			edit.SessionID = entity.SessionID;
			edit.SeatID = entity.SeatID;
			edit.TicketUnitprice = entity.TicketUnitprice;
			edit.TicketDiscount = entity.TicketDiscount;
			edit.TicketSubtotal = entity.TicketSubtotal;

			try { InseparableDb.SaveChanges(); }catch(SqlException ex) { throw new Exception(ex.Message); }
		}
		public void Delete(int orderId,int item_no)
		{
			InseparableEntities InseparableDb = new InseparableEntities();
			var delete= InseparableDb.TicketOrderDetails.Where(t => t.OrderID == orderId).Single(t => t.TicketItem_no == item_no);

			try
			{
				InseparableDb.TicketOrderDetails.Remove(delete);
				InseparableDb.SaveChanges();
			}catch(SqlException ex) { throw new Exception(ex.Message); }
		}
		public TicketOrderEntity GetBySeat(int seatId,int sessionId)
		{
			InseparableEntities InseparableDb = new InseparableEntities();
			var get = InseparableDb.TicketOrderDetails.Where(t => t.SessionID == sessionId).SingleOrDefault(t => t.SeatID == seatId);
			return get==null? null:new TicketOrderEntity(get.TicketItem_no,get.OrderID,get.MovieID,get.SessionID,get.SeatID,get.RoomID,get.TicketUnitprice,get.TicketDiscount,get.TicketSubtotal);
		}
	}
}
