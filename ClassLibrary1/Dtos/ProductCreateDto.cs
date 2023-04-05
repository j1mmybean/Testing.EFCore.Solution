using ISpan.Inseparable.BLL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL.Dtos
{
	public class ProductCreateDto
	{
		public int ProductId { get; set; }
		public string ProductName { get; set; }
		public int? ProductCategoryId { get; set; }
		public int? ProductUnitprice { get; set; }
		public int? ProductStock { get; set; }
		public byte[] ProductPicture { get; set; }
		public int? CinemaID { get; set; }
	}

	public static class ProductCreateDtoExtension
	{
		public static ProductEntity ToEntity(this ProductCreateDto dto)
		{
			return new ProductEntity(dto.ProductName, dto.ProductCategoryId, dto.ProductUnitprice, dto.ProductStock, dto.CinemaID) //必填
			{
				ProductPicture = dto.ProductPicture, //非必填
			};
		}
	}
}
