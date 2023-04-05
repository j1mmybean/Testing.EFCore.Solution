using ISpan.Inseparable.BLL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL.Dtos
{
	public class ProductOrderCreateDto
	{
		public int ProductItem_no { get; set; }
		public int OrderID { get; set; }
		public int ProductID { get; set; }
		public string ProductName { get; set; }
		public int ProductUnitprice { get; set; }
		public int ProductQty { get; set; }
		public decimal ProductDiscount { get; set; }
		public int ProductSubtotal { get; set; }
	}
	public static class ProductOrderCreateDtoExtension { 
	public static ProductOrderEntity ToEntity(this ProductOrderCreateDto dto)
		{
			return new ProductOrderEntity(dto.ProductItem_no,dto.OrderID,dto.ProductID,dto.ProductName,dto.ProductUnitprice,dto.ProductQty,dto.ProductDiscount,dto.ProductSubtotal);
		}
	}
}
