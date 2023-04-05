using ISpan.Inseparable.BLL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL.Dtos
{
	public class ProductUpdateDto
	{
		public int ProductId { get; set; }
		public string ProductName { get; set; }
		public int? ProductCategoryId { get; set; }
		public int? ProductUnitprice { get; set; }
		public int? ProductStock { get; set; }
		public byte[] ProductPicture { get; set; }
		public int? CinemaID { get; set; }
	}

	public static class ProductUpdateDtoExtension
	{
		public static ProductEntity ToEntity(this ProductUpdateDto dto)
		{
			return new ProductEntity(dto.ProductName, dto.ProductCategoryId, dto.ProductUnitprice, dto.ProductStock, dto.CinemaID)
			{
				ProductId = dto.ProductId,
				ProductPicture = dto.ProductPicture,
			};
		}
	}

}