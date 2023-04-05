using ISpan.Inseparable.BLL.Core;
using ISpan.Inseparable.BLL.Dtos;
using ISpan.Inseparable.BLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL
{
	public class OrderService
	{
		public readonly IOrderRepository repo;

		public OrderService(IOrderRepository repo)
		{
			this.repo = repo;
		}

		public void Create(OrderCreateDto dto)
		{
			var entity = dto.ToEntity();
			
			repo.Create(entity);
		}

		public void Update(OrderUpdateDto dto)
		{
			var entity =dto.ToEntity();
			
			repo.Update(entity);
		}
	}
}
