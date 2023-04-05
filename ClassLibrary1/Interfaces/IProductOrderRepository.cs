using ISpan.Inseparable.BLL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL.Interface
{
	public interface IProductOrderRepository
	{
		void Create(ProductOrderEntity entity);

		void Update(ProductOrderEntity entity);

	}
}
