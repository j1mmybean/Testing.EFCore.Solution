using ISpan.Inseparable.BLL.Core;
using ISpan.Inseparable.BLL.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.SqlDataLayer
{
	public class ProductCategoryRepository :IProductCategoryRepository
	{
		public void Create(ProductCategoryEntity entity)
		{
			InseparableEntities InseparableDb = new InseparableEntities();
			ProductCategories category = new ProductCategories();

			category.ProductCategoryName=entity.ProductCategoryName;

			try
			{
				InseparableDb.ProductCategories.Add(category);
				InseparableDb.SaveChanges();
			}catch(SqlException ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public ProductCategoryEntity GetByName(string name)
		{
			InseparableEntities InseparableDb = new InseparableEntities();
			var getName = InseparableDb.ProductCategories.SingleOrDefault(pc => pc.ProductCategoryName == name);

			return getName ==null? null: new ProductCategoryEntity(getName.ProductCategoryName);
		}

		public IQueryable<ProductCategories> Search(String productCategoryName)
		{
			InseparableEntities InseparableDb = new InseparableEntities();
			IQueryable<ProductCategories> search = InseparableDb.ProductCategories;

			if (string.IsNullOrEmpty(productCategoryName) == false) search = search.Where(pc => pc.ProductCategoryName.Contains(productCategoryName));
			return search;
		}

		public void Update(ProductCategoryEntity entity)
		{
			InseparableEntities InseparableDb = new InseparableEntities();

			var edit = InseparableDb.ProductCategories.Single(pc=>pc.ProductCategoryID==entity.ProductCategoryID);

			edit.ProductCategoryName = entity.ProductCategoryName;

			try
			{
				InseparableDb.SaveChanges();
			}catch(SqlException ex) { throw new Exception(ex.Message);
			}
		}

		public void Delete(int Id)
		{
			InseparableEntities InseparableDb = new InseparableEntities();

			var delete = InseparableDb.ProductCategories.SingleOrDefault(p => p.ProductCategoryID == Id);
			try
			{
				InseparableDb.ProductCategories.Remove(delete);
				InseparableDb.SaveChanges();
			}
			catch (SqlException ex) { throw new Exception(ex.Message); }
		}
	}
}
