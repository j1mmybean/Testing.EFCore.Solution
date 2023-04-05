using ISpan.Inseparable.BLL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL.Dtos
{
	public class ProductCategoryCreateDto
	{
		public int ProductCategoryID { get; set; }
		public string ProductCategoryName { get; set; }
	}
	public static class ProductCategoryCreateDtoExtension
	{
		public static ProductCategoryEntity ToEntity(this ProductCategoryCreateDto dto)
		{
			return new ProductCategoryEntity(dto.ProductCategoryName);
		}
	}
}
