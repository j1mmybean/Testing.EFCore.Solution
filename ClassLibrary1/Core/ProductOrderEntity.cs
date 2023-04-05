using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL.Core
{
	public class ProductOrderEntity
	{
		public int ProductItem_no { get; set; }
		public int OrderID { get; set; }
		public int ProductID { get; set; }
		public string ProductName { get; set; }
		public int ProductUnitprice { get; set; }
		public int ProductQty { get; set; }
		public decimal ProductDiscount { get; set; }
		public int ProductSubtotal { get; set; }

		public ProductOrderEntity (int productItem_no, int orderID, int productID, string productName, int productUnitprice, int productQty, decimal productDiscount, int productSubtotal)
		{
			ProductItem_no = productItem_no;
			OrderID = orderID;
			ProductID = productID;
			ProductName = productName;
			ProductUnitprice = productUnitprice;
			ProductQty = productQty;
			ProductDiscount = productDiscount;
			ProductSubtotal = productSubtotal;
		}
	}
}
