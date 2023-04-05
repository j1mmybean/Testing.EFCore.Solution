using ISpan.Inseparable.BLL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL.Dtos
{
	public class ProductCategoryUpdateDto
	{
		public int ProductCategoryID { get; set; }
		public string ProductCategoryName { get; set; }
	}

	public static class ProductCategoryUpdateDtoExtension
	{
		public static ProductCategoryEntity ToEntity(this ProductCategoryUpdateDto dto)
		{
			return new ProductCategoryEntity(dto.ProductCategoryName)
			{
				ProductCategoryID = dto.ProductCategoryID
			};
		}
	}
}
