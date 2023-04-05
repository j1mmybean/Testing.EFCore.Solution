using ISpan.Inseparable.BLL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL.Interface
{
	public interface IProductCategoryRepository
	{
		void Create(ProductCategoryEntity entity);
		void Update(ProductCategoryEntity entity);

		ProductCategoryEntity GetByName(string name);
	}
}
