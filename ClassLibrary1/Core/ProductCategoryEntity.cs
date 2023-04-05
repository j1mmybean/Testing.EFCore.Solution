using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL.Core
{
	public class ProductCategoryEntity
	{
		public int ProductCategoryID { get; set; }
		public string ProductCategoryName { get; set; }

		//必填
		public ProductCategoryEntity(string productCategoryName)
		{
			ProductCategoryName = productCategoryName;
		}
	}
}
