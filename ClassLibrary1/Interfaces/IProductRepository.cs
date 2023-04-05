using ISpan.Inseparable.BLL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL.Interface
{
	public interface IProductRepository
	{
		void Create(ProductEntity entity);
		void Update(ProductEntity entity);
		ProductEntity GetByCinema(int cinemaId, string name);
	}
}