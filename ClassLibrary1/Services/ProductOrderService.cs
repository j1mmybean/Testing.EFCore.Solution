using ISpan.Inseparable.BLL.Dtos;
using ISpan.Inseparable.BLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL
{
	public class ProductOrderService
	{
		public readonly IProductOrderRepository repo;

		public ProductOrderService(IProductOrderRepository repo)
		{
			this.repo = repo;
		}

		public void Create(ProductOrderCreateDto dto)
		{
			var entity =dto.ToEntity();

			repo.Create(entity);
		}

		public void Update(ProductOrderUpdateDto dto)
		{
			var entity = dto.ToEntity();

			repo.Update(entity);
		}
	}
}
