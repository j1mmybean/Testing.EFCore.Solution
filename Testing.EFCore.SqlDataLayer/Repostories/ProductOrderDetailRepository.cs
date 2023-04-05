using ISpan.Inseparable.BLL.Core;
using ISpan.Inseparable.BLL.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.SqlDataLayer
{
	public class ProductOrderDetailRepository:IProductOrderRepository
	{
		public IQueryable<ProductOrderDetails> Search(int? orderId,int? memberId)
		{
			InseparableEntities inseparableDb = new InseparableEntities();
			IQueryable<ProductOrderDetails> search = inseparableDb.ProductOrderDetails;

			if (orderId != null) search = search.Where(po => po.OrderID == orderId);
			if (memberId != null) search = search.Where(t => t.Orders.MemberID == memberId);

			return search;
		}
		public ProductOrderDetails GetProductOrderDetails(int Id,int Item_no)
		{
			InseparableEntities inseparableDb = new InseparableEntities();
			var get = inseparableDb.ProductOrderDetails.Where(po=>po.OrderID==Id).SingleOrDefault(po=>po.ProductItem_no==Item_no);
			return get;
		}

		public void Create(ProductOrderEntity entity)
		{
			InseparableEntities inseparableDb = new InseparableEntities();
			ProductOrderDetails P = new ProductOrderDetails();

			P.ProductItem_no = entity.ProductItem_no;
			P.OrderID = entity.OrderID;
			P.ProductID=entity.ProductID;
			P.ProductName=entity.ProductName;
			P.ProductQty=entity.ProductQty;
			P.ProductUnitprice=entity.ProductUnitprice;
			P.ProductSubtotal =entity.ProductSubtotal;
			P.ProductDiscount=entity.ProductDiscount;

			try
			{
				inseparableDb.ProductOrderDetails.Add(P);
				inseparableDb.SaveChanges();
			}catch(SqlException ex) { throw new Exception(ex.Message); }
		}

		public void Update(ProductOrderEntity entity)
		{
			InseparableEntities inseparableDb = new InseparableEntities();
			var edit = inseparableDb.ProductOrderDetails.Where(p => p.OrderID == entity.OrderID).SingleOrDefault(p => p.ProductItem_no == entity.ProductItem_no);

			edit.ProductID = entity.ProductID;
			edit.ProductName = entity.ProductName;
			edit.ProductQty = entity.ProductQty;
			edit.ProductUnitprice = entity.ProductUnitprice;
			edit.ProductSubtotal = entity.ProductSubtotal;
			edit.ProductDiscount = entity.ProductDiscount;

			try
			{
				inseparableDb.SaveChanges();
			}catch(SqlException ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void Delete(int Id,int item_no)
		{
			InseparableEntities inseparableDb = new InseparableEntities();
			var delete = inseparableDb.ProductOrderDetails.Where(p => p.OrderID == Id).SingleOrDefault(p => p.ProductItem_no == item_no);

			try
			{
				inseparableDb.ProductOrderDetails.Remove(delete);
				inseparableDb.SaveChanges();
			}catch(SqlException ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
