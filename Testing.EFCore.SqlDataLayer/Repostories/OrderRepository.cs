using ISpan.Inseparable.BLL.Core;
using ISpan.Inseparable.BLL.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.SqlDataLayer
{
	public class OrderRepository :IOrderRepository
	{

		public IQueryable<Orders> Search(int? memberID,int? orderId)
		{
			InseparableEntities InseparableDb = new InseparableEntities();
			IQueryable<Orders> search = InseparableDb.Orders;

			if (memberID != null) search = search.Where(o => o.MemberID == memberID);
			if (orderId != null) search = search.Where(o => o.OrderID == orderId);
			return search;
		}
		public Orders GetOrders(int orderId)
		{
			InseparableEntities InseparableDb = new InseparableEntities();
			var get = InseparableDb.Orders.Single(o => o.OrderID == orderId);
			return get;
		}

		public void Create(OrderEntity entity)
		{
			InseparableEntities InseparableDb = new InseparableEntities();
			Orders o = new Orders();

			o.MemberID=entity.MemberID;
			o.CinemaID=entity.CinemaID;
			o.OrderDate=entity.OrderDate;
			o.ModifiedTime = entity.ModifiedTime;
			o.TotalMoney = entity.TotalMoney;

			try
			{
				InseparableDb.Orders.Add(o);
				InseparableDb.SaveChanges();
			}catch(SqlException ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void Update(OrderEntity entity)
		{
			InseparableEntities InseparableDb = new InseparableEntities();
			var edit = InseparableDb.Orders.Single(o => o.OrderID == entity.OrderID);

			edit.CinemaID = entity.CinemaID;
			edit.ModifiedTime = entity.ModifiedTime;

			try
			{
				InseparableDb.SaveChanges();
			}catch(SqlException ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void Delete(int Id)
		{
			InseparableEntities InseparableDb = new InseparableEntities();
			var delete = InseparableDb.Orders.Single(o => o.OrderID == Id);

			try
			{
				InseparableDb.Orders.Remove(delete);
				InseparableDb.SaveChanges();
			}catch(SqlException ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
