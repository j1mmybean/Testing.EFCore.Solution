using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL.Core
{
	public class ProductEntity
	{
		public int ProductId { get; set; }
		public string ProductName { get; set; }
		public int? ProductCategoryId { get; set; }
		public int? ProductUnitprice { get; set; }
		public int? ProductStock { get; set; }
		public byte[] ProductPicture { get; set; }
		public int? CinemaID { get; set; }

		//必填項目
		public ProductEntity(string productName, int? categoryId, int? price, int? stock, int? cinemaId)
		{
			ProductName = productName;
			ProductCategoryId = categoryId;
			ProductUnitprice = price;
			ProductStock = stock;
			CinemaID = cinemaId;
		}

	}
}