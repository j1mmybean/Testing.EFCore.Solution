using ISpan.Inseparable.BLL.Dtos;
using ISpan.Inseparable.BLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL
{
	public class ProductService
	{
		public readonly IProductRepository repo;
		//商業邏輯
		public ProductService(IProductRepository repo)
		{
			this.repo = repo;
		}

		public void Create(ProductCreateDto dto)
		{
			var entity = dto.ToEntity();

			//驗證產品在各家是否唯一
			var entityInDb = repo.GetByCinema((int)entity.CinemaID, entity.ProductName);
			if (entityInDb != null) throw new Exception("此商品已存在於該店!!");

			repo.Create(entity);
		}

		public void Update(ProductUpdateDto dto)
		{
			var entity = dto.ToEntity();

			//驗證產品在各家是否唯一
			var entityInDb = repo.GetByCinema((int)entity.CinemaID, entity.ProductName);
			if (entityInDb != null && entityInDb.ProductId != entity.ProductId) throw new Exception("此商品已存在於該店!!");

			repo.Update(entity);
		}
	}
}
