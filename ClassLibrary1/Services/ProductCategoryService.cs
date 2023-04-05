using ISpan.Inseparable.BLL.Dtos;
using ISpan.Inseparable.BLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace ISpan.Inseparable.BLL
{
	public class ProductCategoryService
	{
		public readonly IProductCategoryRepository repo;

		public ProductCategoryService(IProductCategoryRepository repo)
		{
			this.repo = repo;
		}

		public void Create(ProductCategoryCreateDto dto)
		{
			var entity = dto.ToEntity();

			//驗證是否唯一
			var entityInDb = repo.GetByName(dto.ProductCategoryName);

			if (entityInDb != null) throw new Exception("該類別已存在!");

			repo.Create(entity);
		}

		public void Update(ProductCategoryUpdateDto dto)
		{
			var entity = dto.ToEntity();

			//驗證是否唯一
			var entityInDb = repo.GetByName(dto.ProductCategoryName);

			if (entityInDb != null && entityInDb.ProductCategoryID != dto.ProductCategoryID) throw new Exception("該類別已存在!");

			repo.Update(entity);
		}
	}
}
